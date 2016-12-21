using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace SpaceMuseum.Data.Migrations
{
    using Models;
    using System.Reflection;
    using System.Xml;

    internal sealed class Configuration : DbMigrationsConfiguration<DatabaseContext>
    {
        // Basic exhibit types
        private const string ExhibitTypeMissilesID = "f59487cd-6652-4a60-a876-3cd1e4ac5303";
        private const string ExhibitTypeMissiles = "Missiles";
        private const string ExhibitTypeSpacesuitsID = "5e8a9a19-030d-44d8-9618-d7430ddcb347";
        private const string ExhibitTypeSpacesuits = "Spacesuits";
        private const string ExhibitTypeNavigationalSatelliteID = "f0b770b3-98a3-415f-8795-8abbb2d00e84";
        private const string ExhibitTypeNavigationalSatellite = "Navigational Satellite";
        private const string ExhibitTypeOtherID = "78b0623e-7780-41bf-97ec-806e82e894af";
        private const string ExhibitTypeOther = "Other";

        // Basic user roles and users
        private const string RoleAdminID = "c2d748f3-a850-494f-b0a8-e51f7d56b6d9";
        private const string RoleAdminName = "Admin";
        private const string UserAdminID = "3e18c7e5-83d6-4664-9d42-a879e6a1462a";
        private const string UserAdminUserName = "Admin";

        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(DatabaseContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            try
            {
                CreateUser(context);

                CreateExhibitTypes(context);
                //CreateExhibits(context);
                //CreateEvents(context);
                //CreateImages(context);
                
                //CreateArticles(context);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        // Creates admin's account and role
        private void CreateUser(DatabaseContext context)
        {
            IdentityRole role = new IdentityRole { Id = RoleAdminID, Name = RoleAdminName };
            IdentityUser user = new IdentityUser { Id = UserAdminID, UserName = UserAdminUserName };
            IdentityUserRole userRole = new IdentityUserRole { UserId = UserAdminID, RoleId = RoleAdminID };
            user.Roles.Add(userRole);

            // Add or update role and user in db context
            context.Roles.AddOrUpdate(r => r.Id, role);
            context.Users.AddOrUpdate(u => u.Id, user);
        }

        // Creates basic exhibit types
        private void CreateExhibitTypes(DatabaseContext context)
        {
            // Every exhibit has a type, so we will generate them here
            context.ExhibitTypes.AddOrUpdate(
                item => item.ExhibitTypeID,
                new ExhibitType { ExhibitTypeID = Guid.Parse(ExhibitTypeMissilesID), Name = ExhibitTypeMissiles, Description = ExhibitTypeMissiles },
                new ExhibitType { ExhibitTypeID = Guid.Parse(ExhibitTypeSpacesuitsID), Name = ExhibitTypeSpacesuits, Description = ExhibitTypeSpacesuits },
                new ExhibitType { ExhibitTypeID = Guid.Parse(ExhibitTypeNavigationalSatelliteID), Name = ExhibitTypeNavigationalSatellite, Description = ExhibitTypeNavigationalSatellite },
                new ExhibitType { ExhibitTypeID = Guid.Parse(ExhibitTypeOtherID), Name = ExhibitTypeSpacesuits, Description = ExhibitTypeSpacesuits }
            );
            context.SaveChanges();
        }

        // Creates exhibits
        private void CreateExhibits(DatabaseContext context)
        {
            // Get existing exhibit types
            IEnumerable<ExhibitType> exhibitTypes = context.ExhibitTypes.ToList();
            IEnumerable<Exhibit> exhibits = LoadData<Exhibit, ExhibitXmlModel>(
                x => new Exhibit
                {
                    ExhibitID = Guid.NewGuid(),
                    Name = x.Name,
                    Description = x.Description,
                    ExhibitType = exhibitTypes.FirstOrDefault(et => et.Name == x.ExhibitType.Trim('\n', '\r', ' '))
                });

            // Create or Update exhibits
            context.Exhibits.AddOrUpdate(item => item.Name, exhibits.ToArray());
            context.SaveChanges();
        }

        // Creates events
        private void CreateEvents(DatabaseContext context)
        {
            IEnumerable<Event> events = LoadData<Event, EventXmlModel>((x) => new Event
            {
                EventID = Guid.NewGuid(),
                Name = x.Name,
                Description = x.Description,
                IsPassed = x.IsPassed
            });

            // Create or Update events
            context.Events.AddOrUpdate(item => item.Name, events.ToArray());
        }

        // Creates images for exhibits and events
        private void CreateImages(DatabaseContext context)
        {
            IEnumerable<Exhibit> exhibits = context.Exhibits.AsEnumerable();
            IEnumerable<Event> events = context.Events.AsEnumerable();
            IEnumerable<Image> images = LoadData<Image, ImageXmlModel>((x) => new Image
            {
                ImageID = Guid.NewGuid(),
                Name = x.Name,
                Description = x.Description,
                URL = x.URL,
                MIME = x.MIME,
                Exhibits = exhibits.Where(ex => ex.Name == x.Name).ToList(),
                Events = events.Where(ev => "Event: " + ev.Name == x.Name).ToList()
            });

            // Create or Update images
            context.Images.AddOrUpdate(item => item.Name, images.ToArray());
        }

        // Creates articles
        private void CreateArticles(DatabaseContext context)
        {
            IEnumerable<Exhibit> exhibits = context.Exhibits.AsEnumerable();
            IEnumerable<Article> articles = LoadData<Article, ArticleXmlModel>((x) => new Article
            {
                ArticleID = Guid.NewGuid(),
                Name = x.Name,
                Description = x.Description,
                Exhibits = exhibits.Where(ex => ex.Name == x.Exhibit).ToList()
            });

            // Create or Update articles
            context.Articles.AddOrUpdate(item => item.Name, articles.ToArray());
        }

        // Loads list of TXmlModels from embedded xml resource file and maps it a given TEntry
        private IEnumerable<TEntry> LoadData<TEntry, TXmlModel>(Func<TXmlModel, TEntry> mapper)
        {
            // Open stream to xml with data for a given TEntry, which is part of assembly resources
            using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("SpaceMuseum.Data.Migrations.Test.Data." + typeof(TEntry).Name + "s.xml"))
            {
                // Create xml reader and deserializer for given TXmlModel as an array
                XmlReader reader = XmlReader.Create(stream);
                XmlSerializer serializer = new XmlSerializer(typeof(TXmlModel[]));
                if (serializer.CanDeserialize(reader))
                {
                    // Deserialize xml models and map to given entry
                    IEnumerable<TXmlModel> xmlModels = (TXmlModel[])serializer.Deserialize(reader);
                    IEnumerable<TEntry> entries = xmlModels.Select(mapper);
                    return entries;
                }
                else
                    return Enumerable.Empty<TEntry>();
            }
        }
    }

    // The xml model for the Exhibit entry
    public class ExhibitXmlModel
    {
        // TODO: Consider using predefined (in xml) GUID
        public string Name { get; set; }
        public string Description { get; set; }
        public string ExhibitType { get; set; }
    }

    // The xml model for the Image entry
    public class ImageXmlModel
    {
        // TODO: Consider using predefined (in xml) GUID
        public string Name { get; set; }        // NOTE: Name and Desc should be same with a Name
        public string Description { get; set; } // of Exhibit or Event, or Article. We need this
        public string URL { get; set; }         // to be able link images to another entry.
        public string MIME { get; set; }        // The URL should be relative to the server.
    }

    // The xml model for the Event entry
    public class EventXmlModel
    {
        // TODO: Consider using predefined (in xml) GUID
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsPassed { get; set; }
    }

    // The xml model for the Article entry
    public class ArticleXmlModel
    {
        // TODO: Consider using predefined (in xml) GUID
        public string Name { get; set; }
        public string Description { get; set; }
        public string Exhibit { get; set; }
    }
}
