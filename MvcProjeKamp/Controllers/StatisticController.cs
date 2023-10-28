using DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKamp.Controllers
{
    
    public class StatisticController : Controller
    {
        Context _context = new Context();
      
        public ActionResult Index()
        {
            var CategoryCount = _context.Categories.Count();
            ViewBag.Kategori = CategoryCount;
            
            var Titles = _context.headings.Count(x => x.CategoryID == 3);
            ViewBag.Baslik = Titles;

            var WriterStatisc = _context.Writers.Count(x => x.WriterName.Contains("a")); // Yazar adinda "a" harfi gecen yazar sayisi
            ViewBag.WriterStatisc = WriterStatisc;

            var MaxHeadings = _context.headings.Max(x => x.Category.CategoryName);
            ViewBag.MaxHeadings = MaxHeadings;

            var statusDifference = _context.Categories.Count(c => c.CategoryStatus) - _context.Categories.Count(c => !c.CategoryStatus);
            ViewBag.StatusDifference = statusDifference;
            return View();
        }
    }
}