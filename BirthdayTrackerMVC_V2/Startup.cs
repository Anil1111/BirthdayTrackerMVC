using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BirthdayTrackerMVC_V2.Startup))]
namespace BirthdayTrackerMVC_V2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
