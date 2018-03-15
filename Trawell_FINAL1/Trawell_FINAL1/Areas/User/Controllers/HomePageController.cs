using System.Collections.Generic;
using System.Web.Mvc;
using Trawell_FINAL1.Models;

namespace Trawell_FINAL1.Areas.User.Controllers
{
    public class HomePageController : Controller
    {
        ViewModel vm = new ViewModel();

        private Trawell_DbaseEntities1 db = new Trawell_DbaseEntities1();

        // GET: User/HomePage
        public ActionResult Index()
        {
            
            vm.Sliders = db.Sliders;
            vm.Slogans = db.Slogans;

            return View(vm);
        }
    }
}