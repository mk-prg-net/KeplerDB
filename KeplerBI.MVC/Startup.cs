using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(KeplerBI.MVC.Startup))]
namespace KeplerBI.MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
