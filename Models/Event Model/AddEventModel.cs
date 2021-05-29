using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Yoga.Data;
using System.IO;

namespace Yoga.Models.Event_Model
{
    public class AddEventModel
    {
        public class EventModel
        {

            public int EventID { get; set; }
            public string Title { get; set; }
            public string Location { get; set; }
            public string OrganizedBy { get; set; }
            public string Photo1 { get; set; }
            public string Photo2 { get; set; }
            public Nullable<System.DateTime> Date { get; set; }
            public string DateString { get; set; }

            public string SaveEvent(HttpPostedFileBase fb, EventModel model)
            {
                string message = "";
                YogaNerPEntities1 db = new YogaNerPEntities1();
                string filePath = "";
                string fileName = "";
                string sysFileName = "";


                if (fb != null && fb.ContentLength > 0)
                {
                    filePath = HttpContext.Current.Server.MapPath("~/Admin/Content/imgs/");
                    DirectoryInfo di = new DirectoryInfo(filePath);
                    if (!di.Exists)
                    {
                        di.Create();
                    }
                    fileName = fb.FileName;
                    sysFileName = DateTime.Now.ToFileTime().ToString() + Path.GetExtension(fb.FileName);
                    fb.SaveAs(filePath + "//" + sysFileName);
                    if (!string.IsNullOrWhiteSpace(fb.FileName))
                    {
                        string afileName = HttpContext.Current.Server.MapPath("~/Admin/Content/imgs/") + "/" + sysFileName;

                    }
                    var saveEvent = new tblEvent()
                    {

                        Title = model.Title,
                        Location = model.Location,
                        OrganizedBy = model.OrganizedBy,
                        Photo1 = sysFileName,
                        Photo2 = sysFileName,
                        Date = model.Date,
                    };
                    db.tblEvents.Add(saveEvent);
                    db.SaveChanges();


                }

                return message;

            }

            //    public List<GalleryModel> Gallerylist()
            //    {
            //        YogaNerPEntities1 Db = new YogaNerPEntities1();
            //        List<GalleryModel> lstGallerylist = new List<GalleryModel>();
            //        var AddGallerylist = Db.tblGalleries.ToList();
            //        if (AddGallerylist != null)
            //        {
            //            foreach (var Gallerylist in AddGallerylist)
            //            {
            //                lstGallerylist.Add(new GalleryModel()
            //                {

            //                    ID = Gallerylist.ID,
            //                    Title = Gallerylist.Title,
            //                    Image = Gallerylist.Image,


            //                });

            //            }


            //        }
            //        return lstGallerylist;
            //    }
            //}


        }

    }
}

    
