using System.Diagnostics.CodeAnalysis;

namespace KD.Function.Customer.Infrastructure.Repositories.EntityFramework.Models
{
    [ExcludeFromCodeCoverage]
    public partial class CustomerAccount
    {
        public int Id { get; set; }
        public int IdCustomer { get; set; }
        public int IdAccount { get; set; }
        public bool IsMasterUser { get; set; }

        public virtual Account IdAccountNavigation { get; set; } = null!;
        public virtual Customer IdCustomerNavigation { get; set; } = null!;
    }
}
