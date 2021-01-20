using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebAPIFakultet.Startup))]
namespace WebAPIFakultet
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
