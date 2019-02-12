using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PasswordResetDashboard.Startup))]
namespace PasswordResetDashboard
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
