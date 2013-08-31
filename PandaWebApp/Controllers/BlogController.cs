using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PandaDataAccessLayer.Entities;
using PandaWebApp.Engine;
using PandaWebApp.Engine.Binders;
using PandaWebApp.FormModels;
using PandaWebApp.ViewModels;

namespace PandaWebApp.Controllers
{
    public class BlogController : ModelCareController
    {
        [HttpGet]
        public ActionResult Posts()
        {
            //TODO: get list of blogs by UserId
            //Guid id = new Guid("428efc0e-27a8-4cf7-a036-88228253a2cd");
            var listOfPosts = DataAccessLayer.TopRandom<BlogPost>(200);
            if (listOfPosts == null)
            {
                return HttpNotFound("Posts not found");
            }

            var posts = new List<Blog.Entry>();
            foreach (var blogPost in listOfPosts)
            {
                var post = new Blog.Entry();
                post.CreatedDate = blogPost.CreationDate;
                post.FullText = blogPost.FullText;
                post.Title = blogPost.Title;
                post.Id = blogPost.Id;
                posts.Add(post);
            }
            return View(posts);
        }



        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Create(Blog.Entry model)
        {
            if (ModelState.IsValid)
            {
                model.CreatedDate = DateTime.Now;
                var binder = new CreateBlogToBlogPost();
                var entry = new BlogPost();
                binder.Load(model, entry);
                DataAccessLayer.Create<BlogPost>(entry);
                DataAccessLayer.DbContext.SaveChanges();
                return RedirectToAction("./Posts");
            }
            return View(model);
        }
        

        [HttpGet]
        public ActionResult ViewPost(Guid id)
        {
            var post = DataAccessLayer.GetById<BlogPost>(id);
            if (post == null)
            {
                return HttpNotFound("Post not found");
            }

            var blogEntry = new Blog.Entry();
            blogEntry.Title = post.Title;
            blogEntry.FullText = post.FullText;
            blogEntry.CreatedDate = post.CreationDate;
            blogEntry.ModifyDate = post.ModifyDate;

            return View(blogEntry);
        }
    }
}
