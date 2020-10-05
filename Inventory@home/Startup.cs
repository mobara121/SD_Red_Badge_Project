using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Inventory_home.Startup))]
namespace Inventory_home
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
