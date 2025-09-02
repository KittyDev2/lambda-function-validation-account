using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace KD.Function.Customer.Infrastructure.Repositories.EntityFramework.Models
{
    [ExcludeFromCodeCoverage]
    public partial class EconomicActivity
    {
        public EconomicActivity()
        {
            CustomerEconomicActivities = new HashSet<CustomerEconomicActivity>();
        }

        public int Id { get; set; }
        public long Code { get; set; }
        public string Description { get; set; }

        public virtual ICollection<CustomerEconomicActivity> CustomerEconomicActivities { get; set; }
    }
}
