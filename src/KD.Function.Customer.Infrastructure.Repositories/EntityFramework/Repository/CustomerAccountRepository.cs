using KD.Function.Customer.Infrastructure.Repositories.EntityFramework.BaseRepository;
using KD.Function.Customer.Infrastructure.Repositories.EntityFramework.Interface;
using KD.Function.Customer.Infrastructure.Repositories.EntityFramework.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace KD.Function.Customer.Infrastructure.Repositories.EntityFramework.Repository
{
    [ExcludeFromCodeCoverage]
    public class CustomerAccountRepository : GenericRepository<CustomerAccount>, ICustomerAccountRepository
    {
        private readonly ILogger<CustomerAccount> _logger;

        public CustomerAccountRepository(DataContext context, ILogger<CustomerAccount> logger) : base(context)
        {
            _logger = logger;
        }

        public async Task DeleteAsync(CustomerAccount customerAccount)
        {
            try
            {
                await Delete(customerAccount);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "CustomerAccount -> Repository -> DeleteAsync DELETE");
                throw;
            }
        }
    }
}
