using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GalaLaw.Startup))]
namespace GalaLaw
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
