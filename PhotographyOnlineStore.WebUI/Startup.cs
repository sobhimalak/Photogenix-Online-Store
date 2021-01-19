using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PhotographyOnlineStore.WebUI.Startup))]
namespace PhotographyOnlineStore.WebUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
