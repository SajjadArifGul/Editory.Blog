using Editory.Blog.Services;
using Editory.Blog.Shared.Helpers;
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

            LoadConfigurations();
        }

        public static void LoadConfigurations(bool replaceExistingValues = false)
        {
            var update = false;

            if (replaceExistingValues)
            {
                //replace and update all existing values of configurations.
                update = true;
            }
            else
            {
                if (ConfigurationsHelper.ConfigurationsDictionary.Keys.Count <= 0)
                {
                    //configurations dont have any keys which means its not loaded in memory, so load configurations.
                    update = true;
                }
            }

            if (update)
            {
                ConfigurationsHelper.UpdateConfigurations(ConfigurationsService.Instance.GetAllConfigurations());
            }
        }
    }
}
