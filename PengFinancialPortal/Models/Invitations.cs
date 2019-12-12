using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PengFinancialPortal.Models
{
    public class Invitations
    {
        public int Id { get; set; }
        public int HouseholdId { get; set; }
        public bool IsValid { get; set; }
        public DateTime Created { get; set; }
        public int TTL { get; set; }
        public string RecipientEmail { get; set; }
        public int Code { get; set; }
    }

}