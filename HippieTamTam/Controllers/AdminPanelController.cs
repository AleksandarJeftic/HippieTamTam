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
            if (Session["AdminID"] !=null)
            {
                return View();
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
    }
}