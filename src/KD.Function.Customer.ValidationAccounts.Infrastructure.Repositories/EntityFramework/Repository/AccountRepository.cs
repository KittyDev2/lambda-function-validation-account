using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using KD.Function.Customer.ValidationAccounts.Infrastructure.Repositories.EntityFramework.BaseRepository;
using KD.Function.Customer.ValidationAccounts.Infrastructure.Repositories.EntityFramework.Interface;
using KD.Function.Customer.ValidationAccounts.Infrastructure.Repositories.EntityFramework.Models;

namespace KD.Function.Customer.ValidationAccounts.Infrastructure.Repositories.EntityFramework.Repository
{
    [ExcludeFromCodeCoverage]
    public class AccountRepository : GenericRepository<Account>, IAccountRepository
    {
        public AccountRepository(DataContext context) : base(context) { }

        public async Task<IEnumerable<Account>> GetUnvalidatedAccountsAsync()
        {
            return await Get(a => a.ValidationDate == null && DateTime.Now > a.CreationDate.AddMinutes(1440),
                includes: includes => includes.CustomerAccounts);
        }

        public async Task DeleteAsync(Account account)
        {
            await Delete(account);
        }
    }
}
