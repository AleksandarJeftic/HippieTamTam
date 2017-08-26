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


        // ADMIN PANEL MAIN PAGE
        public ActionResult Index()
        {


            LaysCatsPosts LCP = new LaysCatsPosts {
                Posts= DbData.Posts.ToList(),
                Categories = DbData.Categories.ToList(),
                Layouts= DbData.Layouts.ToList()
            };

           
            if (Session["AdminID"] !=null)
            {
                
                return View(LCP);
            }
            else
            {
                return RedirectToAction("Login", "AdminPanel");
            }
        }

        // ADMIN PANEL LOGIN PAGE
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
        //CASCADING DROPDOWN LISTS
        private IEnumerable<SelectListItem> GetCategories()
        {
           return DbData.Categories.Select(c => new SelectListItem { Text = c.CategoryName, Value = c.CategoryID.ToString() });

        }

        [HttpGet]
        public ActionResult GetLayouts(int id)
        {
            var data = DbData.Layouts.Where(d => d.CategoryID == id).Select(d => new { Text = d.LayoutName, Value = d.LayoutID });
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        // CREATE OPTIONS 
        public ActionResult Create(FormCollection form)
        {
            int idL = int.Parse(form["CategoryID"]);
            int idC = int.Parse(form["LayoutID"]);

            var post = new Post
            {
                LayoutID = idL,
                CategoryID=idC
            };

            LaysCatsPost LCP = new LaysCatsPost {
                Categories= DbData.Categories.ToList(),
                Layouts= DbData.Layouts.ToList(),
                Post=post

            };
            
            if (idC.GetType() == typeof(int) && idC != 0 && idL.GetType() == typeof(int) && idL != 0)
            {
                var layout = DbData.Layouts.Where(l => l.LayoutID == idL).SingleOrDefault();

                return View("Create", "~/Views/Shared/Afirmacije/" + layout.LayoutName + "c.cshtml",LCP);
            }
            else
                return RedirectToAction("Index", "AdminPanel");
        }

        
        // CREATE POST ACTION METHOD
        public ActionResult CreatePost(LaysCatsPost lcp, HttpPostedFileBase uploadImage,HttpPostedFileBase uploadBigImage)
        {
            
            if (lcp.Post.LayoutID == 1)
            {
                string pic = Path.GetFileName(uploadImage.FileName);
                string path = Path.Combine(System.Web.Hosting.HostingEnvironment.MapPath("~/Images"), pic);
                uploadImage.SaveAs(path);
                path = "../../Images/" + pic;

                var post = new Post
                {
                    PostTitle = lcp.Post.PostTitle,
                    PostBackground = path.ToString(),
                    PostBackgroundColor = lcp.Post.PostBackgroundColor,
                    PostSubhead1 = lcp.Post.PostSubhead1,
                    PostText1 = lcp.Post.PostText1,
                    PostText2 = lcp.Post.PostText2,
                    PostQuote1 = lcp.Post.PostQuote1,
                    CategoryID = lcp.Post.CategoryID,
                    LayoutID = lcp.Post.LayoutID,
                    PostDateCreated = DateTime.Now,
                    PostAuthor = lcp.Post.PostAuthor
                };
                DbData.Posts.Add(post);
                DbData.SaveChanges();
            }
            else if (lcp.Post.LayoutID==2)
            {
                string pic = Path.GetFileName(uploadImage.FileName);
                string path = Path.Combine(System.Web.Hosting.HostingEnvironment.MapPath("~/Images"), pic);
                uploadImage.SaveAs(path);
                path = "../../Images/" + pic;

                string picB = Path.GetFileName(uploadBigImage.FileName);
                string pathB = Path.Combine(System.Web.Hosting.HostingEnvironment.MapPath("~/Images"), picB);
                uploadBigImage.SaveAs(pathB);
                pathB = "../../Images/" + picB;

                var post = new Post
                {
                    PostTitle = lcp.Post.PostTitle,
                    PostBackground = path.ToString(),
                    PostBackgroundColor = lcp.Post.PostBackgroundColor,
                    PostSubhead1 = lcp.Post.PostSubhead1,
                    PostText1 = lcp.Post.PostText1,
                    PostBigImage1=pathB.ToString(),
                    PostBigImageText1=lcp.Post.PostBigImageText1,
                    CategoryID = lcp.Post.CategoryID,
                    LayoutID = lcp.Post.LayoutID,
                    PostDateCreated = DateTime.Now,
                    PostAuthor = lcp.Post.PostAuthor
                };
            DbData.Posts.Add(post);
            DbData.SaveChanges();
            }

            return RedirectToAction("Index", "MainPage");
        }
    }
}