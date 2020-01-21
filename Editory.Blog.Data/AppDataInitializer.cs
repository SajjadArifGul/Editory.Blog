using Editory.Blog.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Editory.Blog.Data
{
    public class AppDataInitializer : CreateDatabaseIfNotExists<AppDataContext>
    {
        protected override void Seed(AppDataContext context)
        {
            try
            {
                SeedRoles(context);
                SeedUsers(context);

                SeedCategories(context);
                SeedConfigurations(context);
            }
            catch (Exception ex)
            {
                throw new Exception("Could not seed data during initializion.", ex);
            }
        }

        public void SeedRoles(AppDataContext context)
        {
            List<IdentityRole> rolesInDealDouble = new List<IdentityRole>();

            rolesInDealDouble.Add(new IdentityRole() { Name = "Administrator" });
            rolesInDealDouble.Add(new IdentityRole() { Name = "Moderator" });
            rolesInDealDouble.Add(new IdentityRole() { Name = "User" });

            var rolesStore = new RoleStore<IdentityRole>(context);
            var rolesManager = new RoleManager<IdentityRole>(rolesStore);

            foreach (IdentityRole role in rolesInDealDouble)
            {
                if (!rolesManager.RoleExists(role.Name))
                {
                    var result = rolesManager.Create(role);

                    if (result.Succeeded) continue;
                }
            }
        }

        public void SeedUsers(AppDataContext context)
        {
            var usersStore = new UserStore<AppUser>(context);
            var usersManager = new UserManager<AppUser>(usersStore);

            AppUser admin = new AppUser();
            admin.FullName = "Admin";
            admin.Email = "admin@email.com";
            admin.UserName = "admin";
            admin.PhoneNumber = "(312)555-0690";
            admin.Address = "404 Block D, Adm Street";
            admin.City = "Adminsburg";
            admin.Country = "Adminstria";
            admin.ZipCode = "123456";
            admin.RegisteredOn = DateTime.Now;
            var password = "admin123";

            if (usersManager.FindByEmail(admin.Email) == null)
            {
                var result = usersManager.Create(admin, password);

                if (result.Succeeded)
                {
                    //add necessary roles to admin
                    usersManager.AddToRole(admin.Id, "Administrator");
                    usersManager.AddToRole(admin.Id, "Moderator");
                    usersManager.AddToRole(admin.Id, "User");
                }
            }
        }
        
        public void SeedCategories(AppDataContext context)
        {
            Category Uncategorized = new Category()
            {
                Name = "Uncategorized",
                SanitizedName = "uncategorized",
                Description = "Things that are not categorized. uncategorised, unclassified - not arranged in any specific grouping.",
                CreatedOn = DateTime.Now
            };

            context.Categories.Add(Uncategorized);

            context.SaveChanges();
        }

        public void SeedConfigurations(AppDataContext context)
        {
            Configuration ApplicationName = new Configuration()
            {
                Key = "ApplicationName",
                Value = "Editory",
                ConfigurationType = (int)ConfigurationTypes.Site,
                CreatedOn = DateTime.Now
            };

            Configuration AddressLine1 = new Configuration()
            {
                Key = "AddressLine1",
                Value = "",
                ConfigurationType = (int)ConfigurationTypes.Site,
                CreatedOn = DateTime.Now
            };

            Configuration AddressLine2 = new Configuration()
            {
                Key = "AddressLine2",
                Value = "",
                ConfigurationType = (int)ConfigurationTypes.Site,
                CreatedOn = DateTime.Now
            };

            Configuration PhoneNumber = new Configuration()
            {
                Key = "PhoneNumber",
                Value = "",
                ConfigurationType = (int)ConfigurationTypes.Site,
                CreatedOn = DateTime.Now
            };

            Configuration MobileNumber = new Configuration()
            {
                Key = "MobileNumber",
                Value = "",
                ConfigurationType = (int)ConfigurationTypes.Site,
                CreatedOn = DateTime.Now
            };

            Configuration Email = new Configuration()
            {
                Key = "Email",
                Value = "contact@email.com",
                ConfigurationType = (int)ConfigurationTypes.Site,
                CreatedOn = DateTime.Now
            };

            Configuration FacebookURL = new Configuration()
            {
                Key = "FacebookURL",
                Value = "",
                ConfigurationType = (int)ConfigurationTypes.SocialLinks,
                CreatedOn = DateTime.Now
            };

            Configuration TwitterUsername = new Configuration()
            {
                Key = "TwitterUsername",
                Value = "",
                ConfigurationType = (int)ConfigurationTypes.SocialLinks,
                CreatedOn = DateTime.Now
            };

            Configuration TwitterURL = new Configuration()
            {
                Key = "TwitterURL",
                Value = "",
                ConfigurationType = (int)ConfigurationTypes.SocialLinks,
                CreatedOn = DateTime.Now
            };

            Configuration WhatsAppNumber = new Configuration()
            {
                Key = "WhatsAppNumber",
                Value = "",
                ConfigurationType = (int)ConfigurationTypes.SocialLinks,
                CreatedOn = DateTime.Now
            };

            Configuration InstagramURL = new Configuration()
            {
                Key = "InstagramURL",
                Value = "",
                ConfigurationType = (int)ConfigurationTypes.SocialLinks,
                CreatedOn = DateTime.Now
            };

            Configuration YouTubeURL = new Configuration()
            {
                Key = "YouTubeURL",
                Value = "",
                ConfigurationType = (int)ConfigurationTypes.SocialLinks,
                CreatedOn = DateTime.Now
            };

            Configuration LinkedInURL = new Configuration()
            {
                Key = "LinkedInURL",
                Value = "",
                ConfigurationType = (int)ConfigurationTypes.SocialLinks,
                CreatedOn = DateTime.Now
            };

            Configuration DashboardRecordsSizePerPageConfig = new Configuration()
            {
                Key = "DashboardRecordsSizePerPage",
                Value = "10",
                ConfigurationType = (int)ConfigurationTypes.Other,
                CreatedOn = DateTime.Now
            };

            Configuration FrontendRecordsSizePerPageConfig = new Configuration()
            {
                Key = "FrontendRecordsSizePerPage",
                Value = "6",
                ConfigurationType = (int)ConfigurationTypes.Other,
                CreatedOn = DateTime.Now
            };

            Configuration RelatedRecordsSizePerPageConfig = new Configuration()
            {
                Key = "RelatedRecordsSizePerPageConfig",
                Value = "3",
                ConfigurationType = (int)ConfigurationTypes.Other,
                CreatedOn = DateTime.Now
            };

            context.Configurations.AddRange(
                   new List<Configuration> {
                       ApplicationName,
                       AddressLine1,
                       AddressLine2,
                       PhoneNumber,
                       MobileNumber,
                       Email,
                       FacebookURL,
                       TwitterUsername,
                       TwitterURL,
                       WhatsAppNumber,
                       InstagramURL,
                       YouTubeURL,
                       LinkedInURL,
                       DashboardRecordsSizePerPageConfig,
                       FrontendRecordsSizePerPageConfig,
                       RelatedRecordsSizePerPageConfig
                   });

            context.SaveChanges();
        }
    }
}
