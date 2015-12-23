using ForeverAlone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccess;


namespace ForeverAlone.Controllers
{
    public class MyProfileController : Controller
    {
        private UserRepository _userRepository;

        public MyProfileController()
        {
            _userRepository = new UserRepository();
        }

        // GET: User
        public ActionResult MyProfile()
        {
            var loggedInUser = _userRepository.GetFirst();
            var myPage = new MyProfileModel
            {
                Username = loggedInUser.Username,
                City = loggedInUser.City
            };
            return View(myPage);
        }
    }
}