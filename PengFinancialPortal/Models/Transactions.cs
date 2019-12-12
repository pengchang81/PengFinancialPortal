using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PengFinancialPortal.Models
{
    public class Transactions
    {
        public int Id { get; set; }
        public int BankAccountId { get; set; }
        public int BudgetItemId { get; set; }
        public int OwnerId { get; set; }
        public int TransactionTypeId { get; set; }
        public DateTimeOffset Created { get; set; }
        public float Amount { get; set; }
        public string Memo { get; set; }

    }
}