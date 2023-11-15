using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKamp.Controllers
{
    public class GalleryController : Controller
    {
        // GET:
        IMageFıleManager ifm = new IMageFıleManager(new EfImageFıleDal());

        public ActionResult Index()
        {
            var files = ifm.GetList();
            return View(files);
        }
    }
}