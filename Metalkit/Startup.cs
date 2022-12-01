using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Metalkit.Startup))]
namespace Metalkit
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
