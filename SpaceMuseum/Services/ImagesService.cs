using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpaceMuseum.Services
{
    using Data;
    using Data.Models;

    public class ImagesService
    {
        private readonly DatabaseContext _database;

        public ImagesService(DatabaseContext database)
        {
            _database = database;
        }

        public Image Get(Guid id)
        {
            return _database.Images.Find(id);
        }

        public IEnumerable<Image> Get()
        {
            return _database.Images.ToList();
        }

        public IEnumerable<Image> GetOrderedByName()
        {
            return _database.Images.OrderBy(x => x.Name).ToList();
        }

        public IEnumerable<Image> GetByExhibit(Guid exhibitID)
        {
            IQueryable<Image> query =
                from ex in _database.Exhibits
                where ex.ExhibitID == exhibitID
                select ex.Images into evs
                from ev in evs
                select ev;
            return query.AsEnumerable();
        }
    }
}