using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpaceMuseum.Services
{
    using Data;
    using Data.Models;

    public class ArticlesService
    {
        private readonly DatabaseContext _database;

        public ArticlesService(DatabaseContext database)
        {
            _database = database;
        }

        public Article Get(Guid id)
        {
            return _database.Articles.Find(id);
        }

        public IEnumerable<Article> Get()
        {
            return _database.Articles.ToList();
        }

        public IEnumerable<Article> GetOrderedByName()
        {
            return _database.Articles.OrderBy(x => x.Name).ToList();
        }

        public IEnumerable<Article> GetByExhibit(Guid exhibitID)
        {
            IQueryable<Article> query =
                from ex in _database.Exhibits
                where ex.ExhibitID == exhibitID
                select ex.Articles into exs
                from ex in exs
                select ex;
            return query.ToList();
        }
    }
}