using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MathHouse.Server.Startup))]
namespace MathHouse.Server
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
