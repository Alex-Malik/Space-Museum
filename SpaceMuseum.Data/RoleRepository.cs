using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceMuseum.Data
{
    using Models;

    public class RoleRepository : IRepository<Role>
    {
        public bool Delete(Role role)
        {
            throw new NotImplementedException();
        }

        public Role Get()
        {
            throw new NotImplementedException();
        }

        public IQueryable<Role> Query()
        {
            throw new NotImplementedException();
        }

        public bool Save(Role role)
        {
            throw new NotImplementedException();
        }
    }
}
