using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using KD.Function.Customer.ValidationAccounts.Infrastructure.Repositories.EntityFramework.BaseRepository;
using KD.Function.Customer.ValidationAccounts.Infrastructure.Repositories.EntityFramework.Interface;
using Microsoft.Extensions.Logging;

namespace KD.Function.Customer.ValidationAccounts.Infrastructure.Repositories.EntityFramework.Repository
{
    [ExcludeFromCodeCoverage]
    public class CustomerRepository : GenericRepository<Models.Customer>, ICustomerRepository
    {
        private readonly ILogger<Models.Customer> _logger;

        public CustomerRepository(DataContext context, ILogger<Models.Customer> logger) : base(context)
        {
            _logger = logger;
        }

        public async Task DeleteAsync(Models.Customer customer)
        {
            try
            {
                await Delete(customer);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Customer -> Repository -> DeleteAsync DELETE");
                throw;
            }
        }
    }
}
