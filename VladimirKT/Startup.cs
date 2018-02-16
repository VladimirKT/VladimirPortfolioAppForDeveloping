using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(VladimirKT.Startup))]
namespace VladimirKT
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
