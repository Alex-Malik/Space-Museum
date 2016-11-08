using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceMuseum.Data.Models
{
    public class Image
    {
        public Guid ImageID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string URL { get; set; }
        public string MIME { get; set; }

        public virtual ICollection<Event> Events { get; set; }
        public virtual ICollection<Exhibit> Exhibits { get; set; }
    }
}
