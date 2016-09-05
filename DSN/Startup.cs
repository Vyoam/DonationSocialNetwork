using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DSN.Startup))]
namespace DSN
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
