using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PengFinancialPortal.Models
{
    public class Households
    {
        public int Id { get; set; }
        public string Name {get; set;}
        public string Greeting { get; set; }
        public DateTime Created { get; set; }

    }
}