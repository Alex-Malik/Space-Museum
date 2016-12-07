using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceMuseum.Data.Models
{
    public class Event
    {
        public Event()
        {
            Images = new List<Image>();
            Exhibits = new List<Exhibit>();
        }

        public Guid EventID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsPassed { get; set; }

        public virtual ICollection<Image> Images { get; set; }
        public virtual ICollection<Exhibit> Exhibits { get; set; }
    }
}
