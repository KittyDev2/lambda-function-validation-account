using System.Collections.Generic;
using System.Threading.Tasks;
using KD.Function.Customer.ValidationAccounts.Infrastructure.Repositories.EntityFramework.Models;

namespace KD.Function.Customer.ValidationAccounts.Infrastructure.Repositories.EntityFramework.Interface
{
    public interface IAccountRepository
    {
        Task<IEnumerable<Account>> GetUnvalidatedAccountsAsync();
        Task DeleteAsync(Account account);
    }
}
