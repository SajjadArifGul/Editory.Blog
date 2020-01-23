using Editory.Blog.Areas.Dashboard.ViewModels;
using Editory.Blog.Entities;
using Editory.Blog.Services;
using Editory.Blog.Shared.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Editory.Blog.Areas.Dashboard.Controllers
{
    public class PostsController : DashboardBaseController
    {
        public ActionResult Index(int? postStatus, string searchTerm, int? pageNo, int? pageSize, bool isPartial = false)
        {
            pageNo = pageNo ?? 1;
            pageSize = pageSize ?? ConfigurationsHelper.DashboardRecordsSizePerPage;

            PostsListingViewModels model = new PostsListingViewModels();

            model.PageTitle = "Posts";
            model.PageDescription = "Posts Listing Page";

            model.PostStatus = postStatus;
            model.SearchTerm = searchTerm;

            model.Posts = PostsService.Instance.SearchPosts(postStatus, searchTerm, pageNo.Value, pageSize.Value);

            var totalPosts = PostsService.Instance.SearchPostsCount(postStatus, searchTerm);

            model.Pager = new Pager(totalPosts, pageNo.Value, pageSize.Value);

            if (isPartial)
            {
                return PartialView("_Listing", model);
            }
            else
            {
                return View(model);
            }
        }

        [HttpGet]
        public ActionResult Action(int? ID)
        {
            var model = new PostActionViewModel();

            Post post = null;

            model.Categories = CategoriesService.Instance.GetAllCategories();

            if (ID.HasValue)
            {
                model.PageTitle = "Edit Post";
                model.PageDescription = "Edit Post";

                post = PostsService.Instance.GetPostByID(ID.Value);
            }
            else
            {
                model.PageTitle = "Create Post";
                model.PageDescription = "Create New Post";

                post = new Post();
            }

            if (post == null)
                return HttpNotFound();

            model.ID = post.ID;
            model.CategoryID = post.CategoryID;
            model.Title = post.Title;
            model.Summary = post.Summary;
            model.Description = post.Description;
            model.IsFeatured = post.IsFeatured;
            model.Status = post.Status;
            model.DateTime = post.DateTime;
            model.URL = post.URL;
            model.ThumbnailPictureID = post.ThumbnailPictureID;
            model.PostPicturesList = post.PostPictures;

            return View(model);
        }
        
        [HttpPost, ValidateInput(false)]
        public ActionResult Action(PostActionViewModel model)
        {
            if (model.ID > 0)
            {
                var post = PostsService.Instance.GetPostByID(model.ID);

                if (post == null)
                    return HttpNotFound();

                post.ID = model.ID;
                post.CategoryID = model.CategoryID;
                post.URL = model.URL;
                post.Title = model.Title;
                post.Summary = model.Summary;
                post.Description = model.Description;
                post.isFeatured = model.isFeatured;
                post.PostStatus = model.PostStatus;
                post.DateTime = model.DateTime;
                post.ModifiedOn = DateTime.Now;

                if (!string.IsNullOrEmpty(model.PostPictures))
                {
                    var pictureIDs = model.PostPictures
                                                .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                                                .Select(ID => int.Parse(ID)).ToList();

                    if (pictureIDs.Count > 0)
                    {
                        post.PostPictures.Clear();
                        post.PostPictures.AddRange(pictureIDs.Select(x => new PostPicture() { PostID = post.ID, PictureID = x }).ToList());

                        post.ThumbnailPictureID = model.ThumbnailPicture != 0 ? model.ThumbnailPicture : pictureIDs.First();
                    }
                }

                PostsService.Instance.UpdatePost(post);
            }
            else
            {
                var post = new Post();

                post.CategoryID = model.CategoryID;
                post.URL = model.URL;
                post.Title = model.Title;
                post.Summary = model.Summary;
                post.Description = model.Description;
                post.isFeatured = model.isFeatured;
                post.PostStatus = model.PostStatus;
                post.DateTime = model.DateTime;
                post.ModifiedOn = DateTime.Now;

                if (!string.IsNullOrEmpty(model.PostPictures))
                {
                    var pictureIDs = model.PostPictures
                                                .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                                                .Select(ID => int.Parse(ID)).ToList();

                    if (pictureIDs.Count > 0)
                    {
                        post.PostPictures = new List<PostPicture>();
                        post.PostPictures.AddRange(pictureIDs.Select(x => new PostPicture() { PostID = post.ID, PictureID = x }).ToList());

                        post.ThumbnailPictureID = model.ThumbnailPicture != 0 ? model.ThumbnailPicture : pictureIDs.First();
                    }
                }

                PostsService.Instance.SavePost(post);
            }

            return RedirectToAction("Index");
        }

    }
}