using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Capstone5.Startup))]
namespace Capstone5
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
