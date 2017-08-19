using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HippieTamTam.Models;

namespace HippieTamTam.Controllers
{
    public class MainPageController : Controller
    {
        BlogDatabaseContext DbData = new BlogDatabaseContext();
        // GET: MainPage
        public ActionResult Index()
        {
            List<Post> Posts = DbData.Posts.ToList();
            return View(Posts);
        }
    }
}