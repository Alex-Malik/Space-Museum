using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceMuseum.Data.Models
{
    public class Article
    {
        public Guid ArticleID { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Exhibit> Exhibits { get; set; }
    }
}
