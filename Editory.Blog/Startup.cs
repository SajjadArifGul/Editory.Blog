using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Editory.Blog.Startup))]
namespace Editory.Blog
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
