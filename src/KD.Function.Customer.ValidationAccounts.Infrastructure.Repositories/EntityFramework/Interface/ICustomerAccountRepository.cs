using System.Threading.Tasks;
using KD.Function.Customer.ValidationAccounts.Infrastructure.Repositories.EntityFramework.Models;

namespace KD.Function.Customer.ValidationAccounts.Infrastructure.Repositories.EntityFramework.Interface
{
    public interface ICustomerAccountRepository
    {
        Task DeleteAsync(CustomerAccount customerAccount);
    }
}
