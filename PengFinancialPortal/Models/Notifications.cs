using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PengFinancialPortal.Models
{
    public class Notifications
    {
        public int Id { get; set;}
        public int Household { get; set; }
        public string RecipientId { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public DateTime Created { get; set; }
        public bool IsRead { get; set; }
    }
}