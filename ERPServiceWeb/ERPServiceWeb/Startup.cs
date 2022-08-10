using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ERPServiceWeb.Startup))]
namespace ERPServiceWeb
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
