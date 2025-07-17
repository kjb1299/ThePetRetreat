using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ThePetRetreat.Startup))]
namespace ThePetRetreat
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
