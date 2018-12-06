using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Owin;
using System.Web.Http;

[assembly: OwinStartupAttribute(typeof(MRT.Startup))]
namespace MRT
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);

            //var config = new HttpConfiguration();
            //app.UseWebApi(config);

            // Can change from AllowAll to send detailed policy info
            app.UseCors(CorsOptions.AllowAll);
        }
    }
}
