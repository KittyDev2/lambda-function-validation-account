using System.Diagnostics.CodeAnalysis;

namespace KD.Function.Customer.Infrastructure.Repositories.EntityFramework.Models
{
    [ExcludeFromCodeCoverage]
    public partial class CustomerEconomicActivity
    {
        public int Id { get; set; }
        public string TypeEconomicActivity { get; set; }
        public int IdEconomicActivity { get; set; }
        public int IdCustomer { get; set; }

        public virtual Customer IdCustomerNavigation { get; set; }
        public virtual EconomicActivity IdEconomicActivityNavigation { get; set; }
    }
}
