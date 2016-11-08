using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceMuseum.Data
{
    using Migrations;

    public class DatabaseConfigurator
    {
        public static void Configure()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<DatabaseContext, Configuration>());
        }
    }
}
