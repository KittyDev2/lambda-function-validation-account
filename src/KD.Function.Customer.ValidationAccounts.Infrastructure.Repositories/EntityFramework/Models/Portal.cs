using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace KD.Function.Customer.ValidationAccounts.Infrastructure.Repositories.EntityFramework.Models
{
    [ExcludeFromCodeCoverage]
    public partial class Portal
    {
        public Portal()
        {
            CustomerPortals = new HashSet<CustomerPortal>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public string Logo { get; set; }
        public bool Status { get; set; }

        public virtual ICollection<CustomerPortal> CustomerPortals { get; set; }
    }
}
