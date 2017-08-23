using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HippieTamTam.Models;
using System.IO;

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

            var lays = DbData.Layouts.ToList();
            var cats = DbData.Categories.ToList();
            var post = new Post
            {
                LayoutID = id
            };
            LaysCatsPost lcp = new LaysCatsPost();
            lcp.Categories = cats;
            lcp.Layouts = lays;
            lcp.Post = post;

            
            
            if (id.GetType() == typeof(int) && id != 0)
            {
                var layout = DbData.Layouts.Where(l => l.LayoutID == id).SingleOrDefault();

                return View("Create", "~/Views/Shared/Afirmacije/" + layout.LayoutName + "c.cshtml",lcp);
            }
            else
                return RedirectToAction("Index", "AdminPanel");
        }

        
        public ActionResult CreatePost(LaysCatsPost lcp, HttpPostedFileBase uploadImage)
        {
            string pic = Path.GetFileName(uploadImage.FileName);
            string path = Path.Combine(System.Web.Hosting.HostingEnvironment.MapPath("~/Images"), pic);
            uploadImage.SaveAs(path);

            path = "../../Images/" + pic;

            var post = new Post
            {
                PostTitle = lcp.Post.PostTitle,
                PostBackground = path.ToString(),
                PostBackgroundColor= lcp.Post.PostBackgroundColor,
                PostSubhead1= lcp.Post.PostSubhead1,
                PostText1= lcp.Post.PostText1,
                PostText2= lcp.Post.PostText2,
                PostQuote1= lcp.Post.PostQuote1,
                CategoryID= lcp.Post.CategoryID,
                LayoutID=lcp.Post.LayoutID,
                PostDateCreated= DateTime.Now,
                PostAuthor= lcp.Post.PostAuthor
            };

            DbData.Posts.Add(post);
            DbData.SaveChanges();
            return RedirectToAction("Index", "AdminPanel");
        }
    }
}