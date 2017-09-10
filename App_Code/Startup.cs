using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CECS.Startup))]
namespace CECS
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
