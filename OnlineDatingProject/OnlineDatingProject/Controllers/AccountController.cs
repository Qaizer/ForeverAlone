using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccess;
using OnlineDatingProject.Models;

namespace OnlineDatingProject.Controllers
{
    public class AccountController : Controller
    {
        // GET: UserAccount
        public ActionResult Index()
        {
            return View();
        }

        // GET: Register
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(AccountModel userInput)
        {
            if (ModelState.IsValid)
            {
                using (var context = new ForeverAloneDBEntities())
                {
                    User newUser = new User
                    {
                        Email = userInput.Email,
                        Password = userInput.Password,
                        Username = userInput.Username,
                        Gender = userInput.Gender,
                        Birthdate = userInput.Birthdate,
                        City = userInput.City,
                    };


                    context.User.Add(newUser);
                    context.SaveChanges();
                }
                ModelState.Clear();
                ViewBag.Message = userInput.Username + " " + "successfully registered!";
            }
            return View();
        }

        //Login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(AccountModel userModel)
        {
            using (var context = new ForeverAloneDBEntities())
            {
                var user = context.User.Where(u => u.Email == userModel.Email && u.Password == userModel.Password).FirstOrDefault();
                if (user != null)
                {
                    Session["UserID"] = user.UserID.ToString();
                    Session["Username"] = user.Username.ToString();
                    return RedirectToAction("LoggedIn");
                }
                else
                {
                    ModelState.AddModelError("", "Email or password is incorrect.");
                }
            }
            return View();
        }

        public ActionResult LoggedIn()
        {
            if (Session["UserID"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }

        }
    }
}