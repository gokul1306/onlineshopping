using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Easybuy.Models;

namespace Easybuy.Controllers
{
    public class LoginController : Controller
    {
        DbModels sp = new DbModels();
        [HttpGet]
        public ActionResult signup(int id=0)
        {
            register usermodel = new register();
            return View(usermodel);
        }
        [HttpPost]
        public ActionResult signup(register usermodel)
        {
            using (DbModels db = new DbModels())
            {
                if(db.registers.Any( x => x.username == usermodel.username))
                {
                    ViewBag.Duplicatemessage = "Username Already Exist";
                    return View("signup",usermodel);
                }
                db.registers.Add(usermodel);
                db.SaveChanges();
            }
            ModelState.Clear();
            ViewBag.SuccessMessage = "Registered Successful";
                return View("signup",new register());
        }
        
        public ActionResult login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult login(register log)
        {
            var res = sp.registers.Where(x => x.username == log.username && x.password == log.password).Count();
            if(res > 0)
            {
                return RedirectToAction("userhome");
            }
            else
            {
                return View();
            }
            
        }


        public ActionResult userhome()
        {
            return View();
        }
    }
}