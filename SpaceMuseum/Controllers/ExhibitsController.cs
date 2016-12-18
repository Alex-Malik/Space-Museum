using SpaceMuseum.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SpaceMuseum.Controllers
{
    public class ExhibitsController : Controller
    {
        private readonly ExhibitsService _exhibits;

        public ExhibitsController(ExhibitsService exhibits)
        {
            _exhibits = exhibits;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View(_exhibits.GetOrderedByName());
        }

        [HttpGet]
        public ActionResult Details(Guid? id)
        {
            if (id.HasValue)
                return View(_exhibits.Get(id.Value));
            else
                return HttpNotFound();
        }
    }
}