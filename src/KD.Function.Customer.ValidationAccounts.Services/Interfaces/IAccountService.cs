using System.Threading.Tasks;

namespace KD.Function.Customer.ValidationAccounts.Services.Interfaces
{
    public interface IAccountService
    {
        Task<bool> ExecuteValidationAccount();
    }
}
