using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PengFinancialPortal.Startup))]
namespace PengFinancialPortal
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
