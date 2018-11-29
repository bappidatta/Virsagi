using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Virsagi.Web.Startup))]
namespace Virsagi.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
