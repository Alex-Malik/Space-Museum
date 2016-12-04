using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpaceMuseum.Services
{
    using Data;
    using Data.Models;

    public class EventsService
    {
        private readonly DatabaseContext _database;

        public EventsService(DatabaseContext database)
        {
            _database = database;
        }

        public IEnumerable<Event> Get()
        {
            return _database.Events.AsEnumerable();
        }

        public IEnumerable<Event> GetMostRecent(int count)
        {
            //DateTime monthAgo = DateTime.Now.Date.AddMonths(-1);
            //IQueryable<Exhibit> query = from e in _database.Exhibits
            //                            where e.Created >= monthAgo
            //                            select e;
            //return query.AsEnumerable();
            throw new NotImplementedException();
        }

        public IEnumerable<Event> GetByExhibit(Guid exhibitID)
        {
            IQueryable<Event> query =
                from ex in _database.Exhibits
                where ex.ExhibitID == exhibitID
                select ex.Events into evs
                from ev in evs
                select ev;
            return query.AsEnumerable();
        }

        public IEnumerable<Event> GetByArticle(Guid articleID)
        {
            throw new NotImplementedException();
        }
    }
}