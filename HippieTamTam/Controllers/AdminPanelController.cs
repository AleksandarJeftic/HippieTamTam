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

        [HttpGet]
        public ActionResult GetPosts(int id)
        {
            var data = DbData.Posts.Where(p => p.CategoryID == id).Select(p => new { Text = p.PostTitle, Value = p.PostID });
            return Json(data, JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public ActionResult GetLayouts(int id)
        {
            var data = DbData.Layouts.Where(d => d.CategoryID == id).Select(d => new { Text = d.LayoutName, Value = d.LayoutID });
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        // CREATE OPTIONS 
        public ActionResult Create(LaysCatsPosts lcposts)
        {
            int idC = lcposts.SelectedCategory;
            int idL = lcposts.SelectedLayout;

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
            
           
                var category = DbData.Categories.Where(c => c.CategoryID == idC).SingleOrDefault();
                var layout = DbData.Layouts.Where(l => l.LayoutID == idL).SingleOrDefault();

                if (category.CategoryName=="Afirmacije")
                    {
                        return View("Create", "~/Views/Shared/Afirmacije/" + layout.LayoutName + "c.cshtml",LCP);
                    }
                else if(category.CategoryName=="Pesme")
                    {
                        return View("Create", "~/Views/Shared/Pesme/" + layout.LayoutName + "c.cshtml", LCP);
                    }
                else
                    {
                        return RedirectToAction("Index", "AdminPanel");
                    }
            
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
            else
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
                    PostText3=lcp.Post.PostText3,
                    PostText4=lcp.Post.PostText4,
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

        public ActionResult Delete(LaysCatsPosts lcp) {
            var post = DbData.Posts.Where(p => p.PostID == lcp.SelectedPost).SingleOrDefault();

            DbData.Entry(post).State= System.Data.Entity.EntityState.Deleted;
            DbData.SaveChanges();

            return RedirectToAction("Index", "MainPage");
        }

        
    }
}