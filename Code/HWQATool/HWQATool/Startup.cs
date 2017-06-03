using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HWQATool.Startup))]
namespace HWQATool
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
