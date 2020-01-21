using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Editory.Blog.Entities
{
    public class Post : BaseEntity
    {
        public int CategoryID { get; set; }
        public virtual Category Category { get; set; }

        public string Title { get; set; }
        public string Summary { get; set; }
        public string Description { get; set; }
        public bool IsFeatured { get; set; }
        public int Status { get; set; }
        public DateTime DateTime { get; set; }
        public string URL { get; set; }

        public int ThumbnailPictureID { get; set; }
        public List<PostPicture> PostPictures { get; set; }
    }

    public enum PostStatus
    {
        Draft = 1,
        Published = 2,
    }
}
