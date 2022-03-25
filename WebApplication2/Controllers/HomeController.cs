using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (!LoginModel.isInit)
            {
                LoginModel.isInit = true;
                LoginModel.ValidKeys = new Dictionary<string, string>();
                LoginModel.ValidKeys.Add("admin", "1234");
            }
            return View();
        }

        [HttpPost]
        public ActionResult Index(LoginModel model)
        {
            bool f = false;
            if (string.IsNullOrEmpty(model.Login))
            {
                f = true;
                ModelState.AddModelError("Login", "Login can't be empty");
            }
            if (string.IsNullOrEmpty(model.Password))
            {
                f=true;
                ModelState.AddModelError("Password", "Password can't be empty");
            }
            if (!f)
            {
                string buf = null;
                LoginModel.ValidKeys.TryGetValue(model.Login.ToLower(), out buf);
                if (buf==null || !buf.Equals(model.Password)) {
                        ModelState.AddModelError("Login", "Incorrect pair login and password");
                    }
                }
            if(!ModelState.IsValid) return View(model);
            ViewBag.Login = model.Login;
            ViewBag.Password = model.Password;
            return View("Success");
        }

        public ActionResult Data()
        {
            ViewBag.Text = "";
            return View();
        }

        [HttpPost]
        public ActionResult Data(string color, string colors, string[] countires)
        {
            string buf = color + " " + colors + " ";
            if(countires!=null) foreach (string i in countires) buf = buf + i + "";
            ViewBag.Text = buf;

            return View();
        }
    }
}