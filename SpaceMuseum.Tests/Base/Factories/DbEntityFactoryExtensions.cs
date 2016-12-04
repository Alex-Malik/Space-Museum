using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceMuseum.Tests.Base.Factories
{
    using SpaceMuseum.Data.Models;

    public static class DbEntityFactoryExtensions
    {
        public static User CreateUser(this DbEntityFactory factory, Action<User> userOverrides = null, Action<Role> roleOverrides = null)
        {
            var role = factory.Create<Role>(r =>
            {
                roleOverrides?.Invoke(r);
                // TODO: Imlement base adding of roles
            });
            var user = factory.Create<User>(u =>
            {
                userOverrides?.Invoke(u);
                u.Roles.Add(role);
            });
            return user;
        }

        // TODO: Add create methods for another entities
    }
}
