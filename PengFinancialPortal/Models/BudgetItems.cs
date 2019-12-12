using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PengFinancialPortal.Models
{
    public class BudgetItems
    {
        public int Id { get; set; }
        public DateTime Created { get; set; }
        public string Name { get; set; }
        public float TargetAmount { get; set; }
        public float CurrentAmount { get; set; }
    }
}