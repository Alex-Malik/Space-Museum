using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceMuseum.Data
{
    using Models;

    public class UserRepository : IRepository<User>
    {
        public bool Delete(User user)
        {
            throw new NotImplementedException();
        }

        public User Get()
        {
            throw new NotImplementedException();
        }

        public IQueryable<User> Query()
        {
            throw new NotImplementedException();
        }

        public bool Save(User user)
        {
            throw new NotImplementedException();
        }
    }
}
