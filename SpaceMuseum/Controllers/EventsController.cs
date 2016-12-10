using SpaceMuseum.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SpaceMuseum.Controllers
{
    public class EventsController : Controller
    {
        private readonly EventsService _events;

        public EventsController(EventsService events)
        {
            _events = events;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View(_events.Get());
        }

        [HttpGet]
        public ActionResult Details(string id)
        {
            if (String.IsNullOrEmpty(id))
                return HttpNotFound("The given event is not found");
            else
                return View(_events.Get(Guid.Parse(id)));
        }
    }
}