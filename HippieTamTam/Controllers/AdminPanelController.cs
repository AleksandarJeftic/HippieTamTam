using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HippieTamTam.Models;

namespace HippieTamTam.Controllers
{
    public class AdminPanelController : Controller
    {
        BlogDatabaseContext DbData = new BlogDatabaseContext();
        // GET: AdminPanel
        public ActionResult Index()
        {
            List<Object> LCP = new List<Object>();

            List<Post> posts = new List<Post>();
            posts = DbData.Posts.ToList();

            List<Category> cats = new List<Category>();
            cats = DbData.Categories.ToList();

            List<Layout> lays = new List<Layout>();
            lays = DbData.Layouts.ToList();

            LCP.Add(posts);
            LCP.Add(cats);
            LCP.Add(lays);

            if (Session["AdminID"] !=null)
            {
                return View(LCP);
            }
            else
            {
                return RedirectToAction("Login", "AdminPanel");
            }
        }

        
        public ActionResult Login()
        {
            var admin = DbData.Admins.FirstOrDefault();
            return View(admin);
        }

        [HttpPost]
        public ActionResult Login(Admin admin)
        {
            if (admin!=null && DbData.Admins.Any(a => a.AdminUsername == admin.AdminUsername) && DbData.Admins.Any(a=>a.AdminPassword==admin.AdminPassword))
            {
                Session["AdminID"] = admin.AdminID;
                return RedirectToAction("Index", "AdminPanel");
            }
            else
            {
            return View();

            }
        }
        
        public ActionResult Create(FormCollection form)
        {

            int id = int.Parse(form["CreateDDL"]);
            if (id.GetType() == typeof(int) && id != 0)
            {
                var layout = DbData.Layouts.Where(l => l.LayoutID == id).SingleOrDefault();

                return View("Create", "~/Views/Shared/Afirmacije/" + layout.LayoutName + "c.cshtml");
            }
            else
                return RedirectToAction("Index", "AdminPanel");
        }

        
        public ActionResult CreatePost(Post p)
        {
            return RedirectToAction("Index", "AdminPanel");
        }
    }
}