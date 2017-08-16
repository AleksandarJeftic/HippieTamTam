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
            string s = "quo1";
            return View("Post","~/Views/Shared/_sub1-txt1-txt2-"+s+".cshtml");
        }
    }
}