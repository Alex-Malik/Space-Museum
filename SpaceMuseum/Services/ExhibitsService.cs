using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpaceMuseum.Services
{
    using Data;

    public class ExhibitsService
    {
        private readonly DatabaseContext _database;

        public ExhibitsService(DatabaseContext database)
        {
            _database = database;
        }
    }
}