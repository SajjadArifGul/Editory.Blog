using Editory.Blog.Entities;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Editory.Blog.Data
{
    public class AppContext : IdentityDbContext<AppUser>
    {
        public AppContext() : base("name=ConnectionString_OK")
        {
            Database.SetInitializer<AppContext>(new AppDataInitializer());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); // This needs to go before the other rules!

            modelBuilder.Entity<AppUser>().ToTable("Users");
            modelBuilder.Entity<IdentityRole>().ToTable("Roles");
            modelBuilder.Entity<IdentityUserRole>().ToTable("UserRoles");
            modelBuilder.Entity<IdentityUserClaim>().ToTable("UserClaims");
            modelBuilder.Entity<IdentityUserLogin>().ToTable("UserLogins");
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Configuration> Configurations { get; set; }
        public DbSet<Picture> Pictures { get; set; }
        public DbSet<PostPicture> PostPictures { get; set; }

        public static AppContext Create()
        {
            return new AppContext();
        }
    }
}
