using System.Collections.Generic;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace PengFinancialPortal.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DisplayName { get; set; }
        public string AvatarPath { get; set; }
        public ApplicationUser()
        {                  
            Notifications = new HashSet<Notifications>();
            BankAccounts = new HashSet<BankAccounts>();
            Households = new HashSet<Households>();
            Transactions = new HashSet<Transactions>();
            BudgetItems = new HashSet<BudgetItems>();
        }

        public virtual ICollection<Notifications> Notifications { get; set; }
        public virtual ICollection<BankAccounts> BankAccounts { get; set; }
        public virtual ICollection<Households> Households { get; set; }
        public virtual ICollection<Transactions> Transactions { get; set; }
        public virtual ICollection<BudgetItems> BudgetItems { get; set; }


               
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<PengFinancialPortal.Models.BankAccounts> BankAccounts { get; set; }

        public System.Data.Entity.DbSet<PengFinancialPortal.Models.Households> Households { get; set; }

        public System.Data.Entity.DbSet<PengFinancialPortal.Models.BudgetItems> BudgetItems { get; set; }

        public System.Data.Entity.DbSet<PengFinancialPortal.Models.Budgets> Budgets { get; set; }

        public System.Data.Entity.DbSet<PengFinancialPortal.Models.Invitations> Invitations { get; set; }

        public System.Data.Entity.DbSet<PengFinancialPortal.Models.Notifications> Notifications { get; set; }

        public System.Data.Entity.DbSet<PengFinancialPortal.Models.Transactions> Transactions { get; set; }
    }
}