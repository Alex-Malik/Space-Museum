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
        private readonly List<Exhibit> _exhibits; // TODO: Remove after db fix

        public ExhibitsService(DatabaseContext database)
        {
            _database = database;
            _exhibits = new List<Exhibit>
            {
                new Exhibit { ExhibitID = Guid.Parse("f9c8c1c0-0702-4c3b-8925-4561a93a8881"), Name = "ex1", Description = "ex1 description" },
                new Exhibit { ExhibitID = Guid.Parse("d322283a-8f26-4e04-a583-a5f58652f986"), Name = "ex2", Description = "ex2 description" },
                new Exhibit { ExhibitID = Guid.Parse("aac7b8c4-bc48-483b-a4bd-504cbfa41720"), Name = "ex3", Description = "ex3 description" },
                new Exhibit { ExhibitID = Guid.Parse("3dc08c38-40a2-4dbf-a247-f99902614420"), Name = "ex4", Description = "ex4 description" },
                new Exhibit { ExhibitID = Guid.Parse("d04f24b8-f0cd-4ab8-9e2a-1ad3970dd184"), Name = "ex5", Description = "ex5 description" },
            };
        }

        public Exhibit Get(Guid id)
        {
            //return _database.Exhibits.Find(id);
            return _exhibits.FirstOrDefault(x => x.ExhibitID == id);
        }

        public IEnumerable<Exhibit> Get()
        {
            //return _database.Exhibits.ToList();
            return _exhibits;
        }

        public IEnumerable<Exhibit> GetOrderedByName()
        {
            //return _database.Exhibits.OrderBy(x => x.Name).ToList();
            return _exhibits.OrderBy(x => x.Name);
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
            IQueryable<Exhibit> query =
                from ev in _database.Articles
                where ev.ArticleID == articleID
                select ev.Exhibits into exs
                from ex in exs
                select ex;
            return query.ToList();
        }

        public IEnumerable<Exhibit> GetBySearchString(string value)
        {
            //return _database.Exhibits.ToList();
            return _exhibits
                .Where(x => x.Name.Contains(value) || x.Description.Contains(value));
        }
    }
}