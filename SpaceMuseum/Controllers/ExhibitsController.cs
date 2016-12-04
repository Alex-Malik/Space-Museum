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

        // GET: Exhibits
        public ActionResult Index()
        {
            return View();
        }
    }
}