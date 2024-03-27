using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Todo_MVC.Models;

namespace Todo_MVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            
            return View();
        }

        public void SignUp(User user)
        {
            DBConnect.AddUser(user);
        }

        [HttpPost]
        public ActionResult Login(User user)
        {
            long id = DBConnect.Login(user);
            if (id != -1)
            {
                Session.Add("userId", id);
                Session.Add("username", user.Username);

                return RedirectToRoute("Todo");
            }
            return View("Index");
            
        }
    }
}