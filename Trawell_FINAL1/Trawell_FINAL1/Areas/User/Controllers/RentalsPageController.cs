using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Trawell_FINAL1.Models;

namespace Trawell_FINAL1.Areas.User.Controllers
{
    public class RentalsPageController : Controller
    {

        ViewModel vm = new ViewModel();

        private Trawell_DbaseEntities1 db = new Trawell_DbaseEntities1();
        // GET: User/RentalsPage
        public ActionResult Index()
        {
            vm.Rentals = db.Rentals;
          
            return View(vm);
        }
    }
}