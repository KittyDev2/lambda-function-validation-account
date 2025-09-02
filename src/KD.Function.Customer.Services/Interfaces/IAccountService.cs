using System.Threading.Tasks;

namespace KD.Function.Customer.Services.Interfaces
{
    public interface IAccountService
    {
        Task<bool> ExecuteValidationAccount();
    }
}
