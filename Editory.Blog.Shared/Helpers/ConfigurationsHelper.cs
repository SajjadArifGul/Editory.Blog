using Editory.Blog.Entities;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Editory.Blog.Shared.Helpers
{
    public static class ConfigurationsHelper
    {
        public static ConcurrentDictionary<string, string> ConfigurationsDictionary = new ConcurrentDictionary<string, string>();

        public static void UpdateConfigurations(List<Configuration> configurations)
        {
            if (configurations != null && configurations.Count > 0)
            {
                ConfigurationsDictionary = new ConcurrentDictionary<string, string>();

                foreach (var configuration in configurations)
                {
                    ConfigurationsDictionary.TryAdd(configuration.Key, configuration.Value);
                }
            }
        }

        public static void UpdateConfiguration(Configuration configuration)
        {
            if (configuration != null && ConfigurationsDictionary.ContainsKey(configuration.Key))
            {
                ConfigurationsDictionary[configuration.Key] = configuration.Value;
            }
        }

        public static T GetConfigValue<T>(string key)
        {
            if (!ConfigurationsDictionary.ContainsKey(key))
            {
                throw (new ApplicationException("No such Configuration found: " + key));
            }

            try
            {
                return (T)Convert.ChangeType(ConfigurationsDictionary[key], typeof(T));
            }
            catch (Exception e)
            {
                throw (new ApplicationException(string.Format("Cannot convert Configuration value to {0}", typeof(T)), e));
            }
        }

        public static string ApplicationName
        {
            get
            {
                return (GetConfigValue<string>("ApplicationName"));
            }
        }

        public static string AddressLine1
        {
            get
            {
                return (GetConfigValue<string>("AddressLine1"));
            }
        }

        public static string AddressLine2
        {
            get
            {
                return (GetConfigValue<string>("AddressLine2"));
            }
        }

        public static string PhoneNumber
        {
            get
            {
                return (GetConfigValue<string>("PhoneNumber"));
            }
        }

        public static string MobileNumber
        {
            get
            {
                return (GetConfigValue<string>("MobileNumber"));
            }
        }

        public static string Email
        {
            get
            {
                return (GetConfigValue<string>("Email"));
            }
        }

        public static string FacebookURL
        {
            get
            {
                return (GetConfigValue<string>("FacebookURL"));
            }
        }

        public static string TwitterUsername
        {
            get
            {
                return (GetConfigValue<string>("TwitterUsername"));
            }
        }

        public static string TwitterURL
        {
            get
            {
                return (GetConfigValue<string>("TwitterURL"));
            }
        }

        public static string WhatsAppNumber
        {
            get
            {
                return (GetConfigValue<string>("WhatsAppNumber"));
            }
        }

        public static string InstagramURL
        {
            get
            {
                return (GetConfigValue<string>("InstagramURL"));
            }
        }

        public static string YouTubeURL
        {
            get
            {
                return (GetConfigValue<string>("YouTubeURL"));
            }
        }

        public static string LinkedInURL
        {
            get
            {
                return (GetConfigValue<string>("LinkedInURL"));
            }
        }

        public static int DashboardRecordsSizePerPage
        {
            get
            {
                return (GetConfigValue<int>("DashboardRecordsSizePerPage"));
            }
        }

        public static int RelatedRecordsSizePerPageConfig
        {
            get
            {
                return (GetConfigValue<int>("RelatedRecordsSizePerPageConfig"));
            }
        }

        public static int FrontendRecordsSizePerPage
        {
            get
            {
                return (GetConfigValue<int>("FrontendRecordsSizePerPage"));
            }
        }
    }
}
