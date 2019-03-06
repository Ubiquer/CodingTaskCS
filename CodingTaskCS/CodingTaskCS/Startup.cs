using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CodingTaskCS.Startup))]
namespace CodingTaskCS
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
