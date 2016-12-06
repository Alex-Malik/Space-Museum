using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceMuseum.Tests.Base.Factories
{
    using Data.Models;
    using Utils;

    public class DbEntityDefinitions
    {
        public static void Define()
        {
            DbEntityFactory.Define<Exhibit>(x =>
            {
                x.ExhibitID = Guid.NewGuid();
                x.Name = Moniker.Title;
                x.Description = Moniker.ForThing;
                // TODO: Add another fields for Exhibit's definition
            });

            DbEntityFactory.Define<Event>(x =>
            {
                x.EventID = Guid.NewGuid();
                x.Name = Moniker.Title;
                x.Description = Moniker.ForThing;
                // TODO: Add another fields for Event's definition
            });

            // TODO: Add definitions for another entities
        }
    }
}
