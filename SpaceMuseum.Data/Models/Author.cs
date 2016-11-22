using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceMuseum.Data.Models
{
    public class Author
    {
        public Guid AuthorID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
