using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HippieTamTam.Controllers
{
    public class BlogPostController : Controller
    {
        // GET: BlogPost
        public ActionResult Post()
        {
            return View();
        }
    }
}