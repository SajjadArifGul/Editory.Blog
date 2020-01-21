using Editory.Blog.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Editory.Blog.Areas.Dashboard.ViewModels
{
    public class PostsListingViewModels : DashboardPageViewModel
    {
        public List<Post> Posts { get; set; }
        public int? PostStatus { get; set; }
        public string SearchTerm { get; set; }
        public bool isPartial { get; set; }
        public Pager Pager { get; set; }
    }

    public class PostActionViewModel : DashboardPageViewModel
    {
        public int ID { get; set; }
        public int CategoryID { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public string Description { get; set; }
        public bool IsFeatured { get; set; }
        public int Status { get; set; }
        public DateTime DateTime { get; set; }
        public string URL { get; set; }
        
        public string PostPictures { get; set; }
        public int ThumbnailPictureID { get; set; }
        public List<PostPicture> PostPicturesList { get; set; }

        public Post Post { get; set; }
        public List<Category> Categories { get; set; }
    }
}