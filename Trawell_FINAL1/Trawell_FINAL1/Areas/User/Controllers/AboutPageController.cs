using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Trawell_FINAL1.Models;

namespace Trawell_FINAL1.Areas.User.Controllers
{
    public class AboutPageController : Controller
    {
        private Trawell_DbaseEntities1 db = new Trawell_DbaseEntities1();
        private ViewModel vm = new ViewModel();

        // GET: User/AboutPage
        public ActionResult Index()
        {
            vm.abouts = db.Abouts;

            return View(vm);
        }
    }
}