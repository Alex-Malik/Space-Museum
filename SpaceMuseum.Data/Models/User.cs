using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceMuseum.Data.Models
{
    public class User
    {
        public Guid UserID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public virtual ICollection<Role> Roles { get; set; }
    }
}
