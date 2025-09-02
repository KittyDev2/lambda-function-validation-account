using System.Diagnostics.CodeAnalysis;

namespace KD.Function.Customer.ValidationAccounts.Infrastructure.Repositories.EntityFramework.Models
{
    [ExcludeFromCodeCoverage]
    public partial class CustomerPortal
    {
        public int Id { get; set; }
        public int IdPortal { get; set; }
        public int IdCustomer { get; set; }

        public virtual Customer IdCustomerNavigation { get; set; }
        public virtual Portal IdPortalNavigation { get; set; }
    }
}
