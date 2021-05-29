using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using Yoga.Models;

namespace Yoga.Admin.Add_Gallery
{
    public class YogaGalleryController : Controller
    {
        // GET: YogaGallery
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AddEvent()
        {
            return View();
        }

        public ActionResult SaveGallery(GalleryModel model)
        {
            try
            {
                HttpPostedFileBase fb = null;
                for (int i = 0; i < Request.Files.Count; i++)
                {
                    fb = Request.Files[i];

                }
                return Json(new { models = new GalleryModel().SaveGallery(fb, model) }, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {

                {
                    return Json(new { model = ex.Message }, JsonRequestBehavior.AllowGet);
                }

            }



        }



    }
}