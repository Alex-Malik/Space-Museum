using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceMuseum.Data.Models
{
    public class Exhibit
    {
        public Exhibit()
        {
            Articles = new List<Article>();
            Images = new List<Image>();
            Events = new List<Event>();
        }

        public Guid ExhibitID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ExhibitType ExhibitType { get; set; }
        public virtual ICollection<Article> Articles { get; set; }
        public virtual ICollection<Image> Images { get; set; }
        public virtual ICollection<Event> Events { get; set; }
    }
}
