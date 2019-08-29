using BootstrapWithClientDev.Bussiness_access_Layer;
using BootstrapWithClientDev.Models;
using BootstrapWithClientDev.repository;
using System;
using System.Web.Mvc;
using System.Web.Security;

namespace BootstrapWithClientDev.Controllers
{
    public class HomeController : Controller
    {
        BAL ObjBal = new BAL(new reposit());
        [AllowAnonymous]
        public ActionResult Index()
        {
            if(Request.IsAuthenticated)
            {
                return RedirectToAction("Profile");
            }
            return View();
        }
        [AllowAnonymous]
        public ActionResult About()
        {
            if (Request.IsAuthenticated)
            {
                return RedirectToAction("Profile");
            }
            return View();
        }
        [AllowAnonymous]
        public ActionResult Contact()
        {
            if (Request.IsAuthenticated)
            {
                return RedirectToAction("Profile");
            }
            return View();
        }
        [AllowAnonymous]
        [HttpGet]
        public ActionResult Register()
        {
            //if (Request.IsAuthenticated)
            //{
            //    return RedirectToAction("Profile");
            //}
            ViewBag.DeptNo = ObjBal.DeptEf();
            return View();
        }
        [HttpPost]
        public ActionResult Register(Employee emp)
        {
            if (ModelState.IsValid)
            {
                ObjBal.insertEmployeeEf(emp);
                return RedirectToAction("Login");
            }

            ViewBag.DeptNo = ObjBal.DeptEf();
            return View();
        }
        [AllowAnonymous]
        [HttpGet]
        public ActionResult Login()
        {
            if (Request.IsAuthenticated)
            {
                return RedirectToAction("Profile");
            }
            return View();
        }
       
        [HttpPost]
        public ActionResult Login(LoginModel login, string BtnLogin)
        {
            try
            {
                if (BtnLogin == "Login")
                {
                    if (ModelState.IsValid)
                    {
                        Employee emp = ObjBal.CheckUserNamePassword(login);
                        if (ObjBal.CheckUserNamePassword(login) != null)
                        {
                            FormsAuthentication.SetAuthCookie(emp.Ename, false);
                            return RedirectToAction("Profile");
                        }
                    }
                }
               
            }
            catch(Exception)
            {

            }
            return View();
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
        [Authorize]
        //[AllowAnonymous]
        public ActionResult Profile()
        {
            return View();
        }
        [Authorize]
        public ActionResult Show()
        {
            return View(ObjBal.EmpDataEf());
        }
        [Authorize]
        public ActionResult Details(int id)
        {
            return View(ObjBal.SingleEmployee(id));
        }
        [Authorize]
        public ActionResult Edit()
        {
            return View();
        }
        [Authorize]
        [HttpGet]
        public ActionResult Delete(int id)
        {
            ViewBag.DeptNo = ObjBal.DeptEf();
            return View(ObjBal.EmpDataEf(id));
        }
    }

}