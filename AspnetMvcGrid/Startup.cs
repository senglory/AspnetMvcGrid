using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AspnetMvcGrid.Startup))]
namespace AspnetMvcGrid
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
