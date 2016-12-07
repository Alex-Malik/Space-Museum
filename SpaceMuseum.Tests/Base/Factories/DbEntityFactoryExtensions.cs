using System;
using System.Collections.Generic;

namespace SpaceMuseum.Tests.Base.Factories
{
    using Data.Models;

    public static class DbEntityFactoryExtensions
    {
        public static Exhibit CreateExhibit(this DbEntityFactory factory, Action<Exhibit> exhibitOverrides = null)
        {
            var exhibit = factory.Create<Exhibit>(e =>
            {
                exhibitOverrides?.Invoke(e);
            });
            return exhibit;
        }

        public static IEnumerable<Exhibit> CreateExhibits(this DbEntityFactory factory, int n, Action<Exhibit> exhibitOverrides = null)
        {
            List<Exhibit> retval = new List<Exhibit>();
            for (int i = 0; i < n; i++)
            {
                retval.Add(factory.Create<Exhibit>(e =>
                {
                    exhibitOverrides?.Invoke(e);
                }));
            }
            return retval;
        }

        public static Event CreateEvent(this DbEntityFactory factory, Action<Event> eventOverrides = null)
        {
            var exhibit = factory.Create<Event>(e =>
            {
                eventOverrides?.Invoke(e);
            });
            return exhibit;
        }

        public static IEnumerable<Event> CreateEvents(this DbEntityFactory factory, int n, Action<Event> eventOverrides = null)
        {
            List<Event> retval = new List<Event>();
            for (int i = 0; i < n; i++)
            {
                retval.Add(factory.Create<Event>(e =>
                {
                    eventOverrides?.Invoke(e);
                }));
            }
            return retval;
        }

        // TODO: Add create methods for another entities
    }
}
