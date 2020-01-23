using Editory.Blog.Data;
using Editory.Blog.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Editory.Blog.Services
{
    public class SharedService
    {
        #region Define as Singleton
        private static SharedService _Instance;

        public static SharedService Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new SharedService();
                }

                return (_Instance);
            }
        }

        private SharedService()
        {
        }
        #endregion

        public int SavePicture(Picture picture)
        {
            AppDataContext context = new AppDataContext();

            context.Pictures.Add(picture);

            context.SaveChanges();

            return picture.ID;
        }
    }
}
