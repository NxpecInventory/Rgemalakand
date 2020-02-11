using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RGECMS.Startup))]
namespace RGECMS
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            app.CreatePerOwinContext<ApplicationRoleManager>(ApplicationRoleManager.Create);
        }
    }
}
