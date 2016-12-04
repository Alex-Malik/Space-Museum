using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpaceMuseum.Services
{
    using Data;

    public class EventsService
    {
        private readonly DatabaseContext _database;

        public EventsService(DatabaseContext database)
        {
            _database = database;
        }
    }
}