using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HireFire.Web.Mvc.Startup))]
namespace HireFire.Web.Mvc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
