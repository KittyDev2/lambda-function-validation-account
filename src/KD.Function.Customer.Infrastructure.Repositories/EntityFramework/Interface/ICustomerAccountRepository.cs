using KD.Function.Customer.Infrastructure.Repositories.EntityFramework.Models;
using System.Threading.Tasks;

namespace KD.Function.Customer.Infrastructure.Repositories.EntityFramework.Interface
{
    public interface ICustomerAccountRepository
    {
        Task DeleteAsync(CustomerAccount customerAccount);
    }
}
