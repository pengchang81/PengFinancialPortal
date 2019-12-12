using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PengFinancialPortal.Models
{
    public class Budgets
    {
        public int Id { get; set; }
        public int Household { get; set; }
        public int OwnerId { get; set; }
        public DateTimeOffset Created { get; set; }
        public string Name { get; set; }
        public float TargetAmount { get; set; }
        public float CurrentAmount { get; set; }


    }
}