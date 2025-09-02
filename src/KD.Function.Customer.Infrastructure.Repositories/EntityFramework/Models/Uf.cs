using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace KD.Function.Customer.Infrastructure.Repositories.EntityFramework.Models
{
    [ExcludeFromCodeCoverage]
    public partial class Uf
    {
        public Uf()
        {
            Cities = new HashSet<City>();
            CustomerAddresses = new HashSet<CustomerAddress>();
        }

        public int Id { get; set; }
        public string Abbreviation { get; set; }
        public string Name { get; set; }

        public virtual ICollection<City> Cities { get; set; }
        public virtual ICollection<CustomerAddress> CustomerAddresses { get; set; }
    }
}
