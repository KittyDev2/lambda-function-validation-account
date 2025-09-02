using System;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using KD.AwsSecretManager;
using KD.Function.Customer.Infrastructure.Repositories.EntityFramework.BaseRepository;
using KD.Function.Customer.Infrastructure.Repositories.EntityFramework.Interface;
using KD.Function.Customer.Infrastructure.Repositories.EntityFramework.Repository;
using KD.Function.Customer.Services;
using KD.Function.Customer.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;



namespace KD.Function.Customer;

[ExcludeFromCodeCoverage]
public class Startup
{
    private const string AwsSecretNamesEnv = "AWS_SECRET_NAMES";
    
    private IServiceScopeFactory _serviceScopeFactory;
    private IServiceCollection _services;
    private IConfiguration _configuration;
    
    private Startup()
    {
    }
    
    private static void ConfigureAwsSecretManager(ConfigurationBuilder configurationBuilder)
    {
        var environment = Environment.GetEnvironmentVariable("DOTNET_ENVIRONMENT");
        
        if (environment?.Equals("Development", StringComparison.InvariantCultureIgnoreCase) == true)
        {
            return;
        }
        
        var secretNamesValue = Environment.GetEnvironmentVariable(AwsSecretNamesEnv);
        var secretNames = secretNamesValue?.Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries) ?? [];
        configurationBuilder.UseAwsSecretManager(secretNames);
    }
    
    private Startup LoadConfiguration() 
    {
        _services = new ServiceCollection();
        
        var configurationBuilder = new ConfigurationBuilder();
        
        ConfigureAwsSecretManager(configurationBuilder);
        
        _configuration = configurationBuilder
            .AddEnvironmentVariables()
            .Build();
        
        return this;
    }
    
    private Startup BuildServiceScopeFactory()
    {
        var serviceProvider = _services.BuildServiceProvider();
        _serviceScopeFactory = serviceProvider.GetRequiredService<IServiceScopeFactory>();
        return this;
    }
    
    private Startup ConfigureServices()
    {
        // set configuration
        _services.AddSingleton(_configuration);

        // configure serilog
        var logger = Log.Logger = new LoggerConfiguration().Enrich.FromLogContext()
            .WriteTo.Console()
            .CreateLogger();

        _services.AddLogging(lb => lb.AddSerilog(logger));

        // configure dependency injection service, repository and ApiRest
        _services.AddScoped<IAccountService, AccountService>();
        _services.AddScoped<ICustomerRepository, CustomerRepository>();
        _services.AddScoped<IAccountRepository, AccountRepository>();
        _services.AddScoped<ICustomerAccountRepository, CustomerAccountRepository>();

        // configure entity framework
        _services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlServer(Environment.GetEnvironmentVariable("DB_CONN_STRING"),
                    sqlOptions => sqlOptions.MigrationsAssembly(typeof(Startup).GetTypeInfo().Assembly.GetName().Name));
            }, ServiceLifetime.Scoped);

        return this;
    }
    
    public static IServiceScopeFactory ConfigureAndGetServiceScopeFactory()
    {
        return new Startup()
            .LoadConfiguration()
            .ConfigureServices()
            .BuildServiceScopeFactory()
            ._serviceScopeFactory;
    }
}