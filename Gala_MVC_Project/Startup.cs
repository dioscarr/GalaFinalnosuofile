
using Microsoft.Owin;
using Owin;
using System.Configuration;
using System.Web.Configuration;

[assembly: OwinStartupAttribute(typeof(Gala_MVC_Project.Startup))]
namespace Gala_MVC_Project
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);

        }

        private void conStringResolver()
        {
            Configuration config = WebConfigurationManager.OpenMachineConfiguration("~");
            ConnectionStringsSection ConnSection = (ConnectionStringsSection)config.GetSection("conn");
            ConnSection.SectionInformation.ProtectSection("DataProtectionConfigurationProvider");
            config.Save();
        }
    }
}


