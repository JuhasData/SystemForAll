using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WorldManagement.Startup))]
namespace WorldManagement
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
