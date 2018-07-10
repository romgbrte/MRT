using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MRT.Startup))]
namespace MRT
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
