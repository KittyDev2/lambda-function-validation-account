using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace KD.Function.Customer.ValidationAccounts.Infrastructure.Repositories.EntityFramework.Models
{
    [ExcludeFromCodeCoverage]
    public partial class Customer
    {
        public Customer()
        {
            CustomerAccounts = new HashSet<CustomerAccount>();
            CustomerAddresses = new HashSet<CustomerAddress>();
            CustomerEconomicActivities = new HashSet<CustomerEconomicActivity>();
            CustomerPortals = new HashSet<CustomerPortal>();
        }

        public int Id { get; set; }
        public string CorporateName { get; set; }
        public string FantasyName { get; set; }
        public string Document { get; set; }
        public string Ie { get; set; }
        public DateTime? DateFoundation { get; set; }
        public string Owner { get; set; }
        public string LandlinePhone { get; set; }
        public string CellPhone { get; set; }
        public string Email { get; set; }
        public string CorporateEmail { get; set; }
        public bool? IntegrateOnpremise { get; set; }

        public virtual ICollection<CustomerAccount> CustomerAccounts { get; set; }
        public virtual ICollection<CustomerAddress> CustomerAddresses { get; set; }
        public virtual ICollection<CustomerEconomicActivity> CustomerEconomicActivities { get; set; }
        public virtual ICollection<CustomerPortal> CustomerPortals { get; set; }
    }
}
