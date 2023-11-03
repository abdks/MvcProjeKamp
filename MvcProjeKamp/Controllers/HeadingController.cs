using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class HeadingController : Controller
    {

        HeadingManager hm = new HeadingManager(new EfHeadingDal());
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        WriterManager wm = new WriterManager(new EfWriterDal());


        public ActionResult Index()
        {
            var values = hm.GetList();
            return View(values);
        }
        [HttpGet]
        public ActionResult AddHeader()
        {
            List<SelectListItem> category = (from x in cm.GetList()
                                             select new SelectListItem
                                             {
                                                 Text = x.CategoryName,
                                                 Value = x.CategoryID.ToString()
                                             }).ToList();
            List<SelectListItem> writer = (from x in wm.GetList()
                                           select new SelectListItem
                                           {
                                               Text = x.WriterName + " " + x.WriterSurname,
                                               Value = x.WriterID.ToString()
                                           }).ToList();
            ViewBag.category = category;
            ViewBag.writer = writer;

            return View();
        }


        [HttpPost]
        public ActionResult AddHeader(Heading p)
        {
            p.HeadingDate = DateTime.Parse((DateTime.Now.ToShortDateString()));
            hm.HeadingAdd(p);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateHeader(int id)
        {
            List<SelectListItem> category = (from x in cm.GetList()
                                             select new SelectListItem
                                             {
                                                 Text = x.CategoryName,
                                                 Value = x.CategoryID.ToString()
                                             }).ToList();
            ViewBag.category = category;
            var values = hm.GetByID(id);
            return View(values);
        }

        [HttpPost]
        public ActionResult UpdateHeader(Heading p)
        {
            List<SelectListItem> category = (from x in cm.GetList()
                                             select new SelectListItem
                                             {
                                                 Text = x.CategoryName,
                                                 Value = x.CategoryID.ToString()
                                             }).ToList();
            ViewBag.category = category;
            var value = hm.GetByID(p.HeadingID);
            value.HeadingName = p.HeadingName;
            value.CategoryID = p.CategoryID;
            hm.HeadingUpdate(value);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteHeader(int id)
        {
            var values = hm.GetByID(id);
            if (values.HeadingStatus == true)
            {
                values.HeadingStatus = false;
                hm.HeadingUpdate(values);
            }
            else if (values.HeadingStatus == false)
            {
                values.HeadingStatus = true;
                hm.HeadingUpdate(values);
            }


            return RedirectToAction("Index");
        }


    }
}