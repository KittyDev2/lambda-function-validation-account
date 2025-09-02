using System.Diagnostics.CodeAnalysis;

namespace KD.Function.Customer.ValidationAccounts.Infrastructure.Repositories.EntityFramework.Models
{
    [ExcludeFromCodeCoverage]
    public partial class CustomerAddress
    {
        public int Id { get; set; }
        public int IdCustomer { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string Complement { get; set; }
        public string Neighborhood { get; set; }
        public string Zipcode { get; set; }
        public int IdUf { get; set; }
        public int IdCity { get; set; }

        public virtual City IdCityNavigation { get; set; }
        public virtual Customer IdCustomerNavigation { get; set; }
        public virtual Uf IdUfNavigation { get; set; }
    }
}
