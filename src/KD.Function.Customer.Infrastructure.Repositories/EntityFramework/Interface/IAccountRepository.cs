using KD.Function.Customer.Infrastructure.Repositories.EntityFramework.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KD.Function.Customer.Infrastructure.Repositories.EntityFramework.Interface
{
    public interface IAccountRepository
    {
        Task<IEnumerable<Account>> GetUnvalidatedAccountsAsync();
        Task DeleteAsync(Account account);
    }
}
