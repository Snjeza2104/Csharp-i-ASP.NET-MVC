using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Fakultet2.StartupOwin))]

namespace Fakultet2
{
    public partial class StartupOwin
    {
        public void Configuration(IAppBuilder app)
        {
            //AuthStartup.ConfigureAuth(app);
        }
    }
}
