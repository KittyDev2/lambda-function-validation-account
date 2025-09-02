using System.Threading.Tasks;

namespace KD.Function.Customer.ValidationAccounts.Infrastructure.Repositories.EntityFramework.Interface
{
    public interface ICustomerRepository
    {
        Task DeleteAsync(Models.Customer customer);
    }
}
