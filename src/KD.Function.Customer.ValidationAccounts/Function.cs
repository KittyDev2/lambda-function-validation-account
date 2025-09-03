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