using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace KD.Function.Customer.Infrastructure.Repositories.EntityFramework.Models
{
    [ExcludeFromCodeCoverage]
    public partial class City
    {
        public City()
        {
            CustomerAddresses = new HashSet<CustomerAddress>();
            IdUfNavigation = new Uf();
        }

        public int Id { get; set; }
        public long? Code { get; set; }
        public string Name { get; set; }
        public int IdUf { get; set; }

        public virtual Uf IdUfNavigation { get; set; }
        public virtual ICollection<CustomerAddress> CustomerAddresses { get; set; }
    }
}
