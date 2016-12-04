using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceMuseum.Tests.Base.Factories
{
    using Data.Models;
    using Utils;

    public class DbEntityDefenitions
    {
        public static void Define()
        {
            DbEntityFactory.Define<User>(x =>
            {
                x.UserID = Guid.NewGuid();
                x.Username = Moniker.UserName;
                // TODO: Add another fields for User's definition
            });

            // TODO: Add definitions for another entities
        }
    }
}
