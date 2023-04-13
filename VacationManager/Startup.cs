using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(VacationManager.Startup))]
namespace VacationManager
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
