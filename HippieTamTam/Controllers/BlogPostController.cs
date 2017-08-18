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
        // GET: BlogPost
        public ActionResult Post()
        {

            BlogDatabaseContext DbData = new BlogDatabaseContext();

            var Post = DbData.Posts.FirstOrDefault();
            var layout = DbData.Posts.FirstOrDefault().Layout.LayoutName;
            
            return View("Post","~/Views/Shared/"+layout+".cshtml",Post);
        }
    }
}