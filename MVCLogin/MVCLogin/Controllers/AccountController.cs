using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCLogin.Models;

namespace MVCLogin.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            using (OurDbContext db = new OurDbContext())
            {
                return View(db.userAccount.ToList());
            }

        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(UserAccount account)
        {
            
                if (ModelState.IsValid)
                {
                    using (OurDbContext db = new OurDbContext())
                    {
                    var isUserAlreadyExists = db.userAccount.Any(x => x.Username == account.Username);
                    if (isUserAlreadyExists)
                    {
                        ModelState.AddModelError("Username", "User with this username already exists");
                        return View(account);
                    }

                        db.userAccount.Add(account);
                        db.SaveChanges();
                    }
                    ModelState.Clear();
                    ViewBag.Message = account.FirstName + " " + account.LastName + " Successfully registered.";
                }

                return View();

            
        
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UserAccount user)
        {

            

            using (OurDbContext db = new OurDbContext())
            {
                var usr = db.userAccount.FirstOrDefault(u => u.Username == user.Username && u.Password == user.Password);

                if (usr != null)
                {
                    Session["UserID"] = usr.UserID.ToString();
                    Session["Username"] = usr.Username.ToString();
                    Session["IsAdmin"] = usr.IsAdmin.ToString();

                    return RedirectToAction("Index","Files");
                }
                else
                {
                    ModelState.AddModelError("", "Username or password is incorrect");

                }
            }
            return View();
        }

        public ActionResult LoggedIn()
        {
            if (Session["UserId"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }

           
        }

        public ActionResult LogOut()
        {
           
                Session["UserID"] = null;
            Session["IsAdmin"] = null;
                return RedirectToAction("Login");
     
        }
    }
}