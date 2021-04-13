using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(bookies.Startup))]
namespace bookies
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
