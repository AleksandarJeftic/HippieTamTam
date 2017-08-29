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
        public ActionResult CreatePost(LaysCatsPost lcp, HttpPostedFileBase uploadImage,HttpPostedFileBase uploadBigImage1)
        {
            var images = new List<HttpPostedFileBase>();
            images.Add(uploadImage);
            images.Add(uploadBigImage1);

            var paths = new List<string>();
            for (int i = 0; i < 6; i++)
            {
            paths.Add(null);
            }
            

            for (int i = 0;i<images.Count && images[i] != null; i++)
            {

            string pic = Path.GetFileName(images[i].FileName);
            string path = Path.Combine(System.Web.Hosting.HostingEnvironment.MapPath("~/Images"), pic);
            images[i].SaveAs(path);
            paths[i] = "../../Images/" + pic;
            }

                var post = new Post
                {
                    PostTitle = lcp.Post.PostTitle,
                    PostBackground = paths[0],
                    PostBackgroundColor = lcp.Post.PostBackgroundColor,
                    PostSubhead1 = lcp.Post.PostSubhead1,
                    PostSubhead2 = lcp.Post.PostSubhead2,
                    PostSubhead3 = lcp.Post.PostSubhead3,
                    PostSubhead4 = lcp.Post.PostSubhead4,
                    PostSubhead5 = lcp.Post.PostSubhead5,
                    PostText1 = lcp.Post.PostText1,
                    PostText2 = lcp.Post.PostText2,
                    PostText3 = lcp.Post.PostText3,
                    PostText4 = lcp.Post.PostText4,
                    PostText5 = lcp.Post.PostText5,
                    PostText6 = lcp.Post.PostText6,
                    PostText7 = lcp.Post.PostText7,
                    PostText8 = lcp.Post.PostText8,
                    PostText9 = lcp.Post.PostText9,
                    PostText10 = lcp.Post.PostText10,
                    PostQuote1 = lcp.Post.PostQuote1,
                    PostQuote2 = lcp.Post.PostQuote2,
                    PostQuote3 = lcp.Post.PostQuote3,
                    PostQuote4 = lcp.Post.PostQuote4,
                    PostQuote5 = lcp.Post.PostQuote5,
                    PostVideo1 = lcp.Post.PostVideo1,
                    PostVideo2 = lcp.Post.PostVideo2,
                    PostVideo3 = lcp.Post.PostVideo3,
                    PostVideo4 = lcp.Post.PostVideo4,
                    PostBigImage1 = paths[1],
                    PostBigImage2 = paths[2],
                    PostBigImage3 = paths[3],
                    PostBigImage4 = paths[4],
                    PostBigImage5 = paths[5],
                    PostBigImageText1 = lcp.Post.PostBigImageText1,
                    PostBigImageText2 = lcp.Post.PostBigImageText2,
                    PostBigImageText3 = lcp.Post.PostBigImageText3,
                    PostBigImageText4 = lcp.Post.PostBigImageText4,
                    PostBigImageText5 = lcp.Post.PostBigImageText5,
                    PostSmallImage1 = lcp.Post.PostSmallImage1,
                    PostSmallImage2 = lcp.Post.PostSmallImage2,
                    PostSmallImage3 = lcp.Post.PostSmallImage3,
                    PostSmallImage4 = lcp.Post.PostSmallImage4,
                    PostSmallImage5 = lcp.Post.PostSmallImage5,
                    CategoryID = lcp.Post.CategoryID,
                    LayoutID = lcp.Post.LayoutID,
                    PostDateCreated = DateTime.Now,
                    PostAuthor = lcp.Post.PostAuthor
                };
                DbData.Posts.Add(post);
                DbData.SaveChanges();

            return RedirectToAction("Index", "MainPage");
       }
            
        

        public ActionResult Delete(LaysCatsPosts lcp) {

            var post = DbData.Posts.Where(p => p.PostID == lcp.SelectedPost).SingleOrDefault();

            DbData.Entry(post).State= System.Data.Entity.EntityState.Deleted;
            DbData.SaveChanges();

            return RedirectToAction("Index", "AdminPanel");
            }

        
    }
}
