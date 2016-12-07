using SpaceMuseum.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpaceMuseum.Models
{
    public class HomeViewModel
    {
        public IEnumerable<Event> Events { get; set; }
        public IEnumerable<Exhibit> Exhibits { get; set; }

    }
}