﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceMuseum.Data.Models
{
    public class Exhibit
    {
        public Guid ExhibitID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int ExhibitTypeID { get; set; }
        public int? ArticleID { get; set; }

        public Article Article { get; set; }
        public ExhibitType ExhibitType { get; set; }
        public virtual ICollection<Image> Images { get; set; }
        public virtual ICollection<Event> Events { get; set; }
    }
}
