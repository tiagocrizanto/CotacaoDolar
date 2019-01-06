using Hangfire;
using Hangfire.Dashboard;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(CotacaoDolar.Startup))]
namespace CotacaoDolar
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);

            GlobalConfiguration.Configuration.UseSqlServerStorage("CotacaoDolar");
            app.UseHangfireDashboard("/hangfire");
            app.UseHangfireServer();
        }
    }
}
