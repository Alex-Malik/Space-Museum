using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpaceMuseum.Services
{
    using Data;
    using Data.Models;

    public class ExhibitsService
    {
        private readonly DatabaseContext _database;

        public ExhibitsService(DatabaseContext database)
        {
            _database = database;
        }

        public Exhibit Get(Guid id)
        {
            return _database.Exhibits.Find(id);
        }

        public IEnumerable<Exhibit> Get()
        {
            return _database.Exhibits.ToList();
        }

        public IEnumerable<Exhibit> GetOrderedByName()
        {
            return _database.Exhibits.OrderBy(x => x.Name).ToList();
        }

        public IEnumerable<Exhibit> GetMostRecent(int count)
        {
            //DateTime monthAgo = DateTime.Now.Date.AddMonths(-1);
            //IQueryable<Exhibit> query = from e in _database.Exhibits
            //                            where e.Created >= monthAgo
            //                            select e;
            //return query.ToList();
            throw new NotImplementedException();
        }

        public IEnumerable<Exhibit> GetByEvent(Guid eventID)
        {
            IQueryable<Exhibit> query =
                from ev in _database.Events
                where ev.EventID == eventID
                select ev.Exhibits into exs
                from ex in exs
                select ex;
            return query.ToList();
        }

        public IEnumerable<Exhibit> GetByArticle(Guid articleID)
        {
            throw new NotImplementedException();
        }
    }
}