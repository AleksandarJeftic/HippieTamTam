using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HippieTamTam.Models;

namespace HippieTamTam.Controllers
{
    public class BlogPostController : Controller
    {
        BlogDatabaseContext DbData = new BlogDatabaseContext();
        // GET: BlogPost
        public ActionResult Post(int id)
        {
            var Post = DbData.Posts.Where(p=>p.PostID==id).SingleOrDefault();
            var layout = Post.Layout.LayoutName;

            if (Post.Category.CategoryName=="Afirmacije")
            {
                return View("Post", "~/Views/Shared/Afirmacije/" + layout + ".cshtml", Post);
            }
            else
            {
                return View("Post", "~/Views/Shared/Pesme/" + layout + ".cshtml", Post);
            }
            
        }
    }
}