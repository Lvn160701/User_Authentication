using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(UserAuthentication.Startup))]
namespace UserAuthentication
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
