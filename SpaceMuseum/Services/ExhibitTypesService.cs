using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpaceMuseum.Services
{
    using Data;
    using Data.Models;

    public class ExhibitTypesService
    {
        private readonly DatabaseContext _database;

        public ExhibitTypesService(DatabaseContext database)
        {
            _database = database;
        }

        public ExhibitType Get(Guid id)
        {
            return _database.ExhibitTypes.Find(id);
        }

        public IEnumerable<ExhibitType> Get()
        {
            return _database.ExhibitTypes.ToList();
        }

        public IEnumerable<ExhibitType> GetOrderedByName()
        {
            return _database.ExhibitTypes.OrderBy(x => x.Name).ToList();
        }
    }
}