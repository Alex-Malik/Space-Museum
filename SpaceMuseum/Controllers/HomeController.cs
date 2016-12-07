using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SpaceMuseum.Controllers
{
    using Models;
    using Services;

    public class HomeController : Controller
    {
        private readonly EventsService _events;
        private readonly ExhibitsService _exhibits;
        
        public HomeController(EventsService events, ExhibitsService exhibits)
        {
            _events = events;
            _exhibits = exhibits;
        }

        // GET: Home
        public ActionResult Index()
        {
            return View(new HomeViewModel
            {
                Events = _events.Get(),
                Exhibits = _exhibits.Get()
            });
        }
    }
}