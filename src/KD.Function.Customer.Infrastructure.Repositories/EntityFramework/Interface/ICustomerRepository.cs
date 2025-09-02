using System.Threading.Tasks;

namespace KD.Function.Customer.Infrastructure.Repositories.EntityFramework.Interface
{
    public interface ICustomerRepository
    {
        Task DeleteAsync(Models.Customer customer);
    }
}
