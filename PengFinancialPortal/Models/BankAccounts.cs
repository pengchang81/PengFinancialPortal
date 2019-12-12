using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PengFinancialPortal.Enums;

namespace PengFinancialPortal.Models
{
    public class BankAccounts
    {
        public int Id { get; set; }
        public int HouseholdId { get; set; }
        public int OwnerId { get; set; }
        public DateTime Created { get; set; }
        public string Name { get; set; }
        public AccountType AccountType { get; set; }
        public float StartingBalance { get; set; }
        public float CurrentBalance { get; set; }
        public virtual Households Household { get; set; }
        public virtual ApplicationUser Owner { get; set; }

        public BankAccounts()
        {
            Transactions = new HashSet<Transactions>();
        }

        public virtual ICollection<Transactions> Transactions { get; set; }

    }
}