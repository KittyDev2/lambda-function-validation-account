using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace KD.Function.Customer.ValidationAccounts.Infrastructure.Repositories.EntityFramework.Models
{
    [ExcludeFromCodeCoverage]
    public partial class Account
    {
        public Account()
        {
            CustomerAccounts = new HashSet<CustomerAccount>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int IdPortal { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? ValidationDate { get; set; }
        public string Cpf { get; set; }
        public bool Active { get; set; }

        public virtual ICollection<CustomerAccount> CustomerAccounts { get; set; }
    }
}
