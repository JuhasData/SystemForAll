using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(SystemForAll.Location.Startup))]

namespace SystemForAll.Location
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
