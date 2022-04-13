using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using System.IO;
using Easybuy.Models;
namespace Easybuy.Controllers
{
    public class ProductController : Controller
    {
        
        DbModels db=new DbModels();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult shirt(int? page)
        {
            int pagesize = 9, pageindex = 1;
            pageindex = page.HasValue ? Convert.ToInt32(page) : 1;
            var list = db.shirts.Where(x => x.pro_status == 1).OrderByDescending(x => x.pro_id).ToList();
            IPagedList<shirt> stu = list.ToPagedList(pageindex, pagesize);
            return View(stu);
        }
        public ActionResult pant(int? page)
        {
            int pagesize = 9, pageindex = 1;
            pageindex = page.HasValue ? Convert.ToInt32(page) : 1;
            var list = db.pants.Where(x => x.pro_status == 1).OrderByDescending(x => x.pro_id).ToList();
            IPagedList<pant> stu = list.ToPagedList(pageindex, pagesize);
            return View(stu);
        }
        public ActionResult tshirt(int? page)
        {
            int pagesize = 9, pageindex = 1;
            pageindex = page.HasValue ? Convert.ToInt32(page) : 1;
            var list = db.tshirts.Where(x => x.pro_status == 1).OrderByDescending(x => x.pro_id).ToList();
            IPagedList<tshirt> stu = list.ToPagedList(pageindex, pagesize);
            return View(stu);
        }



    }
}