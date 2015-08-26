using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TaskProject.Startup))]
namespace TaskProject
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
