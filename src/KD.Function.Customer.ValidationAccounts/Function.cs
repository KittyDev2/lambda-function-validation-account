using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using Amazon.Lambda.Core;
using KD.Function.Customer.ValidationAccounts.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]
namespace KD.Function.Customer.ValidationAccounts;

[ExcludeFromCodeCoverage]
public class Function
{
    private readonly IServiceScopeFactory _serviceScopeFactory;
    
    public Function()
    {
        _serviceScopeFactory = Startup.ConfigureAndGetServiceScopeFactory();
    }

    // [FunctionName("ValidationAccounts")]
    // public async Task Run([TimerTrigger("* */30 * * * *")] TimerInfo myTimer)
    // {
    //     try
    //     {
    //         _logger.LogInformation($"ValidationAccounts TimerTrigger activated: {myTimer}");
    //
    //         var result = await _accountService.ExecuteValidationAccount();
    //
    //         if (result == true)
    //             _logger.LogInformation($"Account(s) validation finished: {DateTime.Now}");
    //     }
    //     catch (Exception ex)
    //     {
    //         _logger.LogError(ex, "Error: Unable to validate accounts process!");
    //     }
    // }
    
    [LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]
    public async Task FunctionHandler(object input, ILambdaContext context)
    {
        try
        {
            var scope = _serviceScopeFactory.CreateScope();
            var service = scope.ServiceProvider.GetRequiredService<IAccountService>();
            var result = await service.ExecuteValidationAccount();

            if (result)
                Log.Information("Account(s) validation finished: {Date}", DateTime.Now);
        }
        catch (Exception ex)
        {
            Log.Error(ex, "Error: Unable to validate accounts process!");
        }
    }
}