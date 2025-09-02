using System;
using System.Threading.Tasks;
using KD.Function.Customer.ValidationAccounts.Infrastructure.Repositories.EntityFramework.Interface;
using KD.Function.Customer.ValidationAccounts.Services.Interfaces;
using Microsoft.Extensions.Logging;

namespace KD.Function.Customer.ValidationAccounts.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly ICustomerAccountRepository _customerAccountRepository;

        private readonly ILogger<AccountService> _logger;

        public AccountService(IAccountRepository accountRepository,
            ICustomerRepository customerRepository,
            ICustomerAccountRepository customerAccountRepository,
            ILogger<AccountService> logger)
        {
            _accountRepository = accountRepository;
            _customerRepository = customerRepository;
            _customerAccountRepository = customerAccountRepository;
            _logger = logger;
        }

        public async Task<bool> ExecuteValidationAccount()
        {
            try
            {
                var accounts = await _accountRepository.GetUnvalidatedAccountsAsync();

                foreach (var account in accounts)
                {
                    foreach (var customerAccount in account.CustomerAccounts)
                    {
                        await _customerAccountRepository.DeleteAsync(customerAccount);
                        await _customerRepository.DeleteAsync(new Infrastructure.Repositories.EntityFramework.Models.Customer()
                            { Id = customerAccount.IdCustomer });
                    }

                    //account.CustomerAccounts = null;
                    await _accountRepository.DeleteAsync(account);
                }

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Function.Customer -> AccountService -> ExecuteValidationAccount");
                throw;
            }
        }
    }
}