using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(basketballMVC.Startup))]
namespace basketballMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
