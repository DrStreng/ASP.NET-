using System.Linq;
using System.Web.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class AccountController : Controller
    {
        MyDbUserEntities1 db = new MyDbUserEntities1();
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(Table user)
        {
            if (ModelState.IsValid)
            {
                var v = db.Table.Where(a => a.Login.Equals(user.Login)).FirstOrDefault();
                if(v != null)
                {
                    ViewBag.Message1 = "User Zajęty";
                    return View(user);
                }
                else
                {
                    user.Role = "User";
                    db.Table.Add(user);
                    db.SaveChanges();
                    ViewBag.Message = "pomyslna rejestracja";
                }
            }
            return View(user);
        }
        // POST: Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Table user)
        {
            if (ModelState.IsValid)
            {
                    var v = db.Table.Where(a => a.Login.Equals(user.Login) && a.Password.Equals(user.Password)).FirstOrDefault();
                    if (v != null)
                    {
                        Session["LoginUserID"] = v.Id.ToString();
                        Session["Zalogowany"] = v.Login.ToString();
                        
                        if(v.Role.ToString() == "Admin")
                        {
                            Session["Admin"] = v.Role.ToString();
                            return RedirectToAction("HomeAdmin");
                        }
                        else
                        {
                            return RedirectToAction("HomeUser");
                        }
                    }
            }
            return View(user);
        }

        public ActionResult HomeUser()
        {
            if (Session["LoginUserID"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
        public ActionResult HomeAdmin()
        {
            if (Session["Admin"] != null)
            {
                return RedirectToAction("Index","Home");
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
        public ActionResult LogOut()
        {
            Session.Clear();
            return RedirectToAction("Index","Home");
        }

    }
}