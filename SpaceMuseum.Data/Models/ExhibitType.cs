using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceMuseum.Data.Models
{
    public class ExhibitType
    {
        public Guid ExhibitTypeID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
