using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Editory.Blog.Entities
{
    public class PostPicture : BaseEntity
    {
        public int PostID { get; set; }

        public int PictureID { get; set; }
        public virtual Picture Picture { get; set; }
    }
}
