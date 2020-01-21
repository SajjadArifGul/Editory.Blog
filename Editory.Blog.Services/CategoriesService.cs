using Editory.Blog.Data;
using Editory.Blog.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Editory.Blog.Services
{
    public class CategoriesService
    {
        #region Define as Singleton
        private static CategoriesService _Instance;

        public static CategoriesService Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new CategoriesService();
                }

                return (_Instance);
            }
        }

        private CategoriesService()
        {
        }
        #endregion

        public List<Category> GetAllCategories()
        {
            AppDataContext context = new AppDataContext();

            return context.Categories.OrderBy(x => x.ID).ToList();
        }

        public List<Category> GetFeaturedCategories(int recordSize = 5)
        {
            AppDataContext context = new AppDataContext();

            return context.Categories.Where(x => x.isFeatured).OrderBy(x => x.ID).Take(recordSize).ToList();
        }

        public List<Category> GetAllParentCategories()
        {
            AppDataContext context = new AppDataContext();

            return context.Categories.Where(x => !x.ParentCategoryID.HasValue).OrderBy(x => x.ID).ToList();
        }

        public Category GetCategoryByID(int ID)
        {
            using (var context = new AppDataContext())
            {
                return context.Categories.Find(ID);
            }
        }

        public Category GetCategoryByName(string sanitizedCategoryName)
        {
            AppDataContext context = new AppDataContext();

            return context.Categories.FirstOrDefault(x => x.SanitizedName.Equals(sanitizedCategoryName));
        }

        public void SaveCategory(Category category)
        {
            AppDataContext context = new AppDataContext();

            context.Categories.Add(category);

            context.SaveChanges();
        }

        public void UpdateCategory(Category category)
        {
            AppDataContext context = new AppDataContext();

            context.Entry(category).State = System.Data.Entity.EntityState.Modified;

            context.SaveChanges();
        }

        public bool DeleteCategory(int ID)
        {
            using (var context = new AppDataContext())
            {
                var category = context.Categories.Find(ID);

                context.Categories.Remove(category);

                return context.SaveChanges() > 0;
            }
        }

        public List<Category> SearchCategories(int? parentCategoryID, string searchTerm, int? pageNo, int pageSize)
        {
            AppDataContext context = new AppDataContext();

            var categories = context.Categories.AsQueryable();

            if (parentCategoryID.HasValue && parentCategoryID.Value > 0)
            {
                categories = categories.Where(x => x.ParentCategoryID == parentCategoryID.Value);
            }

            if (!string.IsNullOrEmpty(searchTerm))
            {
                categories = categories.Where(x => x.Name.ToLower().Contains(searchTerm.ToLower()));
            }

            pageNo = pageNo ?? 1;
            var skipCount = (pageNo.Value - 1) * pageSize;

            return categories.OrderBy(x => x.ID).Skip(skipCount).Take(pageSize).ToList();
        }

        public int GetCategoriesCount(int? parentCategoryID, string searchTerm)
        {
            AppDataContext context = new AppDataContext();

            var categories = context.Categories.AsQueryable();

            if (parentCategoryID.HasValue && parentCategoryID.Value > 0)
            {
                categories = categories.Where(x => x.ParentCategoryID == parentCategoryID.Value);
            }

            if (!string.IsNullOrEmpty(searchTerm))
            {
                categories = categories.Where(x => x.Name.ToLower().Contains(searchTerm.ToLower()));
            }

            return categories.Count();
        }
    }
}
