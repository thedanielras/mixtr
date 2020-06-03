using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Mixtr.Startup))]
namespace Mixtr
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
