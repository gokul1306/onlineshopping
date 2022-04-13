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
    public class AddController : Controller
    {
        DbModels rp = new DbModels();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Create(shirt cvm, HttpPostedFileBase imgfile)
        {
            string path = uploadimgfile(imgfile);
            if (path.Equals("-1"))
            {
                ViewBag.error = "Image could not be uploaded....";
            }
            else
            {
                shirt cat = new shirt();
                cat.pro_name = cvm.pro_name;
                cat.pro_image = path;
                cat.pro_price = cvm.pro_price;
                cat.pro_status = 1;
                rp.shirts.Add(cat);
                rp.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();
        }
        public ActionResult rest()
        {
            return View();
        }


        [HttpPost]
        public ActionResult rest(pant cvm, HttpPostedFileBase imgfile)
        {
            string path = uploadimgfile(imgfile);
            if (path.Equals("-1"))
            {
                ViewBag.error = "Image could not be uploaded....";
            }
            else
            {
                pant cat = new pant();
                cat.pro_name = cvm.pro_name;
                cat.pro_image = path;
                cat.pro_price = cvm.pro_price;
                cat.pro_status = 1;
                rp.pants.Add(cat);
                rp.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();
        }
        public ActionResult plus()
        {
            return View();
        }


        [HttpPost]
        public ActionResult plus(tshirt cvm, HttpPostedFileBase imgfile)
        {
            string path = uploadimgfile(imgfile);
            if (path.Equals("-1"))
            {
                ViewBag.error = "Image could not be uploaded....";
            }
            else
            {
                tshirt cat = new tshirt();
                cat.pro_name = cvm.pro_name;
                cat.pro_image = path;
                cat.pro_price = cvm.pro_price;
                cat.pro_status = 1;
                rp.tshirts.Add(cat);
                rp.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();
        }
        public string uploadimgfile(HttpPostedFileBase file)
        {
            Random r = new Random();
            string path = "-1";
            int random = r.Next();
            if (file != null && file.ContentLength > 0)
            {
                string extension = Path.GetExtension(file.FileName);
                if (extension.ToLower().Equals(".jpg") || extension.ToLower().Equals(".jpeg") || extension.ToLower().Equals(".png"))
                {
                    try
                    {

                        path = Path.Combine(Server.MapPath("~/Content/upload"), random + Path.GetFileName(file.FileName));
                        file.SaveAs(path);
                        path = "~/Content/upload/" + random + Path.GetFileName(file.FileName);

                        //    ViewBag.Message = "File uploaded successfully";
                    }
                    catch (Exception )
                    {
                        path = "-1";
                    }
                }
                else
                {
                    Response.Write("<script>alert('Only jpg ,jpeg or png formats are acceptable....'); </script>");
                }
            }

            else
            {
                Response.Write("<script>alert('Please select a file'); </script>");
                path = "-1";
            }



            return path;
        }

    }
}