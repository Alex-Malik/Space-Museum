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
        private const string ExhibitTypeMissiles = "Missiles";
        private const string ExhibitTypeSpacesuits = "Spacesuits";
        private const string ExhibitTypeNavigationalSatellite = "Navigational Satellite";
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
                //CreateUser(context);

                //CreateExhibitTypes(context);
                //CreateExhibits(context);
                //CreateImagesForExhibits(context);

                //CreateEvents(context);
                //CreateImagesForEvents(context);

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
                item => item.Name,
                new ExhibitType { ExhibitTypeID = Guid.NewGuid(), Name = ExhibitTypeMissiles, Description = ExhibitTypeMissiles },
                new ExhibitType { ExhibitTypeID = Guid.NewGuid(), Name = ExhibitTypeSpacesuits, Description = ExhibitTypeSpacesuits },
                new ExhibitType { ExhibitTypeID = Guid.NewGuid(), Name = ExhibitTypeNavigationalSatellite, Description = ExhibitTypeNavigationalSatellite },
                new ExhibitType { ExhibitTypeID = Guid.NewGuid(), Name = ExhibitTypeSpacesuits, Description = ExhibitTypeSpacesuits }
            );
        }

        // Creates exhibits
        private void CreateExhibits(DatabaseContext context)
        {
            // Get existing exhibit types
            IEnumerable<ExhibitType> exhibitTypes = context.ExhibitTypes.AsEnumerable();
            IEnumerable<Exhibit> exhibits = LoadData<Exhibit, ExhibitXmlModel>((x) => new Exhibit
            {
                ExhibitID = Guid.NewGuid(),
                Name = x.Name,
                Description = x.Description,
                ExhibitType = exhibitTypes.FirstOrDefault(et => et.Name == x.ExhibitType)
            });

            // Create or Update exhibits
            context.Exhibits.AddOrUpdate(item => item.Name, exhibits.ToArray());
        }

        // TODO: Generate models like in CreateExhibits() method
        private void CreateImagesForExhibits(DatabaseContext context)
        {
            IEnumerable<Exhibit> exhibits = context.Exhibits.AsEnumerable();
            ICollection<Image> images = new List<Image>
            {
                new Image
                {
                    ImageID = Guid.NewGuid(),
                    Name = "Medel, Yuri Gagarin",
                    Description = "Medal, Yuri Gagarin",
                    URL = @"https://airandspace.si.edu/sites/default/files/styles/slideshow_sm/public/images/collection-objects/record-images/A20020464000cp01.jpg?itok=5ksZiy18",
                    MIME = "image/jpeg"
                },
                new Image
                {
                    ImageID = Guid.NewGuid(),
                    Name = "Model, Rocket, Jupiter C, 1:48",
                    Description = "Model, Rocket, Jupiter C, 1:48",
                    URL = @"https://airandspace.si.edu/sites/default/files/styles/slideshow_sm/public/images/collection-objects/record-images/A19720992000s.JPG?itok=Y7yklHYg",
                    MIME = "image/jpeg"
                },
                new Image
                {
                    ImageID = Guid.NewGuid(),
                    Name = "Skylab Orbital Workshop",
                    Description = "Skylab Orbital Workshop",
                    URL = @"https://airandspace.si.edu/sites/default/files/styles/slideshow_sm/public/images/collection-objects/record-images/A19761033000CP58.jpg?itok=2Py8Z9vW",
                    MIME = "image/jpeg"
                },
                new Image
                {
                    ImageID = Guid.NewGuid(),
                    Name = "Skylab Orbital Workshop",
                    Description = "Skylab Orbital Workshop",
                    URL = @"https://airandspace.si.edu/webimages/collections/full/A19761033000D1.JPG",
                    MIME = "image/jpeg"
                },
                new Image
                {
                    ImageID = Guid.NewGuid(),
                    Name = "Tomahawk Cruise Missile",
                    Description = "Tomahawk Cruise Missile",
                    URL = @"https://airandspace.si.edu/sites/default/files/styles/slideshow_sm/public/images/collection-objects/record-images/A19820119000CP01.JPG?itok=jBcBOHad",
                    MIME = "image/jpeg"
                },
                new Image
                {
                    ImageID = Guid.NewGuid(),
                    Name = "Minuteman III Missile",
                    Description = "Minuteman III Missile",
                    URL = @"https://airandspace.si.edu/sites/default/files/styles/slideshow_sm/public/images/collection-objects/record-images/A19761115000d.jpg?itok=W6PJqZ9p",
                    MIME = "image/jpeg"
                },
                new Image
                {
                    ImageID = Guid.NewGuid(),
                    Name = "Navigational Satellite, Transit 5-A",
                    Description = "Navigational Satellite, Transit 5-A",
                    URL = @"https://airandspace.si.edu/sites/default/files/styles/slideshow_sm/public/images/collection-objects/record-images/Transit_Artifacts213_0009.jpg?itok=FBDsW92n",
                    MIME = "image/jpeg"
                },
                new Image
                {
                    ImageID = Guid.NewGuid(),
                    Name = "Navigational Satellite, Transit 5-A",
                    Description = "Navigational Satellite, Transit 5-A",
                    URL = @"https://airandspace.si.edu/webimages/collections/full/A19850001000cu01.jpg",
                    MIME = "image/jpeg"
                },
                new Image
                {
                    ImageID = Guid.NewGuid(),
                    Name = "Lt. Franciszek Jarecki flight suit at the Udvar-Hazy Center",
                    Description = "Lt. Franciszek Jarecki flight suit at the Udvar-Hazy Center",
                    URL = @"https://airandspace.si.edu/sites/default/files/styles/callout_half/public/images/editoral-stories/thumbnails/WEB10854-2008h.jpg?itok=sHot2lfm",
                    MIME = "image/jpeg"
                },
                new Image
                {
                    ImageID = Guid.NewGuid(),
                    Name = "Model, Rocket, Scout w/Launch Tower",
                    Description = "Model, Rocket, Scout w/Launch Tower",
                    URL = @"http://ids.si.edu/ids/deliveryService?id=NASM-9752698A2CF82_002",
                    MIME = "image/jpeg"
                },
                new Image
                {
                    ImageID = Guid.NewGuid(),
                    Name = "Lens, 80mm, Xenotar, Gemini",
                    Description = "Lens, 80mm, Xenotar, Gemini",
                    URL = @"https://airandspace.si.edu/sites/default/files/styles/slideshow_sm/public/images/collection-objects/record-images/NASM-558808650DB82_01.jpg?itok=O92QZ-e8",
                    MIME = "image/jpeg"
                },
                new Image
                {
                    ImageID = Guid.NewGuid(),
                    Name = "Lens, 80mm, Xenotar, Gemini",
                    Description = "Lens, 80mm, Xenotar, Gemini",
                    URL = @"http://ids.si.edu/ids/deliveryService?id=NASM-558808650DB82_05",
                    MIME = "image/jpeg"
                },
                new Image
                {
                    ImageID = Guid.NewGuid(),
                    Name = "Event: Observe the Sun with safe telescopes",
                    Description = "Observe the Sun with safe telescopes",
                    URL = @"https://airandspace.si.edu/sites/default/files/styles/callout_half/public/images/events/ObservatoryDaytime_EventPhoto.jpg?itok=tAurEBAu",
                    MIME = "image/jpeg"
                },
                new Image
                {
                    ImageID = Guid.NewGuid(),
                    Name = "Event: Round and Round We Go: Innovation",
                    Description = "Round and Round We Go: Innovation",
                    URL = @"https://airandspace.si.edu/sites/default/files/styles/callout_half/public/images/events/December%20Making%20STEM%20Magic.jpg?itok=WeITozUu",
                    MIME = "image/jpeg"
                },
                new Image
                {
                    ImageID = Guid.NewGuid(),
                    Name = "Event: On Earth by Brian Karas",
                    Description = "On Earth by Brian Karas",
                    URL = @"https://airandspace.si.edu/sites/default/files/styles/callout_half/public/images/events/9670_640_2.jpg?itok=9n7N5FAg&c=21aef1a914e8d6acdef6b9b9106baa41",
                    MIME = "image/jpeg"
                },
                new Image
                {
                    ImageID = Guid.NewGuid(),
                    Name = "Event: Reaction Motors: America's First Liquid-Propellant Rocket Company",
                    Description = "Reaction Motors: America's First Liquid-Propellant Rocket Company",
                    URL = @"https://airandspace.si.edu/sites/default/files/styles/callout_half/public/images/events/A19510007000_NASM2015-07303.jpg?itok=TnuwkD3q&c=d5eb1845487a3d2af4f412dcab28206d",
                    MIME = "image/jpeg"
                },
                new Image
                {
                    ImageID = Guid.NewGuid(),
                    Name = "Event: Astronomy Chat with Courtney Dressing",
                    Description = "Astronomy Chat with Courtney Dressing",
                    URL = @"https://airandspace.si.edu/sites/default/files/styles/callout_half/public/images/events/4966h_1.jpg?itok=aA8vuzGv",
                    MIME = "image/jpeg"
                }
            };

            // Create or Update images
            context.Images.AddOrUpdate(item => item.Name, images.ToArray());

            // Link images with exhibits
            foreach (Exhibit exhibit in exhibits)
            {
                // TODO: Link images to exhibits
            }
        }

        // TODO: Generate models like in CreateExhibits() method
        private void CreateEvents(DatabaseContext context)
        {
            // TODO: Get all existing exhibits and generate events

            context.Events.AddOrUpdate(
                item => item.Name,
                new Event
                {
                    EventID = Guid.NewGuid(),
                    Name = "Observe the Sun with safe telescopes",
                    IsPassed = false,
                    Description =
@"Become an astronomer and observe the skies with a telescope, even during the day! 

View the Sun safely using the Observatory's solar-filtered telescopes. Knowledgeable staff will be present to answer questions and guide observing. Sometimes additional daytime objects, including the Moon and Venus, may be in the sky for observing. 

Online visitors are invited to check the Observatory's Ustream channel for a live telescope view during our open hours, when available, and archived videos of the Sun, Moon, planets, and more.

The Observatory is free and open to the public during posted hours, weather permitting. For weather and closure updates, check @SIObservatory or ask at the Welcome Center when you arrive at the Museum.

Join us for other observing programs, and sign up for the Observatory newsletter (select Public Observatory News) to get notified about upcoming special events!

Accessibility: The Observatory dome and terrace are accessible via ramp or steps. Written and touchable explanatory materials are available"
                },
                new Event
                {
                    EventID = Guid.NewGuid(),
                    Name = "Round and Round We Go: Innovation",
                    IsPassed = false,
                    Description =
@"Learn about the Wright brothers and test your design skills in our December challenge as you design, create, and test your own paper copter. AHS International – The Vertical Flight Technical Society will be on hand to help out with today's design challenge. 

Making STEM Magic is a new program that introduces young visitors to engineering in a fun and creative way. Learn by doing. Design, build, and test a prototype that solves a given challenge. Every month we'll explore a new theme and introduce a new problem to be solved, so come back each month to accept the challenge and learn to think like an engineer. 

Making STEM Magic is held every Saturday from 10:00 am to 3:00 pm. Learn more about future Making STEM Magic challenges."
                },
                new Event
                {
                    EventID = Guid.NewGuid(),
                    Name = "On Earth by Brian Karas",
                    IsPassed = false,
                    Description =
@"Museum staff read stories about famous aviators, hot-air balloon flights, trips to Mars, characters visible in the night sky, or creatures that have their own wings. Each session includes one story and a hands-on activity. Groups larger than 15 are encouraged to reserve a program through the group reservation form.

These programs are made possible through the generous support of the Conrad N. Hilton Foundation."
                },
                new Event
                {
                    EventID = Guid.NewGuid(),
                    Name = "Reaction Motors: America's First Liquid-Propellant Rocket Company",
                    IsPassed = false,
                    Description =
@"Join senior curator Michael Neufeld as he discusses the 75th anniversary of Reaction Motors, Inc.., America's first liquid-propellant rocket company. Meet at the Welcome Center in the Boeing Milestones of Flight Hall on the first floor.

Please note: Although Ask an Expert talks are usually held on Wednesdays, this Ask an Expert will be held on Thursday, December 15.

About the Ask an Expert lecture series: Every Wednesday at noon in the National Mall Building, a Museum staff member talks to the public about the history, collection, or personalities related to a specific artifact or exhibition in the Museum."
                },
                new Event
                {
                    EventID = Guid.NewGuid(),
                    Name = "Astronomy Chat with Courtney Dressing",
                    IsPassed = false,
                    Description =
@"Chat with astronomer Courtney Dressing. Ask questions about her research about habitable exoplanets, what it’s like to be an astronomer, or anything else that interests you. Courtney Dressing is an astronomer at the California Institute of Technology.

In the event of inclement weather, the program may be moved or postponed. Check @SIObservatory for updates or call (202) 633-2517.

Accessibility: The Observatory dome and Museum galleries are accessible."
                });
        }

        // TODO: Generate models like in CreateExhibits() method
        private void CreateImagesForEvents(DatabaseContext context)
        {
            // TODO: Link images to events (part of images is in CreateImagesForExhibits())

            foreach (var image in context.Images.ToList())
            {
                var evnt = context.Events.FirstOrDefault(item => "Event: " + item.Name == image.Name);
                if (evnt != null)
                {
                    evnt.Images.Add(image);
                }
            }
        }

        // TODO: Generate models like in CreateExhibits() method
        private void CreateArticles(DatabaseContext context)
        {
            // TODO: Read articles and all other entities from txt files
            var article1 = new Article
            {
                ArticleID = Guid.NewGuid(),
                Name = "Why Yuri Gagarin Remains the First Man in Space, Even Though He Did Not Land Inside His Spacecraft",
                Description =
@"Every year as the anniversary of the first human spaceflight approaches, I receive calls inquiring about the validity of Yuri Gagarin’s claim as the first human in space.  The legitimate questions focus on the fact that Gagarin did not land inside his spacecraft.  The reasoning goes that since he did not land inside his spacecraft, he disqualified himself from the record books.  This might seem to be a very reasonable argument, but Gagarin remains the first man in space.  The justification for Gagarin remaining in that position lies in the organization that sets the standards for flight.
The Fédération Aéronautique Internationale (FAI) is the world's air sports federation.  It was founded in 1905 as a non-governmental and non-profit making international organization to further aeronautical and astronautical activities worldwide.  Among its duties, the FAI certifies and registers records.  Its first records in aviation date back to 1906.  The organization also arbitrates disputes over records.  If nationals from two different countries claim a record, it is the FAI’s job to examine the submitted documentation and make a ruling as to who has accomplished the feat first.  When it was apparent that the United States and the Union of Soviet Socialist Republics were planning to launch men into space, the FAI specified spaceflight guidelines.  One of the stipulations that the FAI carried over from aviation was that spacecraft pilots, like aircraft pilots should land inside their craft in order for the record to be valid.  In the case of aviation, this made perfect sense.  No one wanted to encourage pilots to sacrifice themselves for an aviation record.  Piloting an aircraft that could not land did nothing to further aeronautical engineering. When Yuri Gagarin orbited the Earth on 12 April 1961, the plan had never been for him to land inside his Vostok spacecraft.  His spherical reentry capsule came through the Earth’s atmosphere on a ballistic trajectory.  Soviet engineers had not yet perfected a braking system that would slow the craft sufficiently for a human to survive impact.  They decided to eject the cosmonaut from his craft.  Yuri Gagarin ejected at 20,000 feet and landed safely on Earth.  Soviet engineers had not discussed this shortcoming with Soviet delegates to the FAI prior to his flight.  They prepared their documents for the FAI omitting this fact.  This led everyone to believe that Gagarin had landed inside his spacecraft.  It was not until four months later, when German Titov became the second human to orbit the Earth and the first person to spend a full day in space, when the controversy began to brew.  Titov owned up to ejecting himself.  This led to a special meeting of the delegates to the FAI to reexamine Titov’s spaceflight records.  The conclusion of the delegates was to rework the parameters of human spaceflight to recognize that the great technological accomplishment of spaceflight was the launch, orbiting and safe return of the human, not the manner in which he or she landed.  Gagarin and Titov’s records remained on the FAI books.  Even after Soviet -made models of the Vostok spacecraft  made it clear that the craft had no braking capability, the FAI created the Gagarin Medal that it awards annually to greatest aviation or space achievement of that year. One should keep other examples of a sports federations’ reconsideration of rules in the face of new techniques and technologies in mind when considering the FAI Gagarin decision.  The underwater dolphin kick in freestyle swimming and the introduction of the clap skate in speed skating both caused initial international flaps.  After the respective sports federations voted to accept these changes, that ended the controversy.  Yes, Gagarin did not follow the rules that the FAI established before his flight.  However, as is true with any sports organization, the FAI reserved the right to reexamine and reinterpret its rules in light of new knowledge and circumstances.  Yuri Gagarin remains indisputably the first person in space and the concept that the first cosmonauts had to land inside their spacecraft is a faded artifact of the transition from aviation to spaceflight. "
            };
            article1.Exhibits.Add(context.Exhibits.FirstOrDefault(item => item.Name == "Medal, Yuri Gagarin"));

            var article2 = new Article
            {
                ArticleID = Guid.NewGuid(),
                Name = "The Day I Met a Communist Defector",
                Description =
@"When you are visiting the Udvar-Hazy Center, you will come across a display case that holds the flightsuit of a former MiG pilot named Frank Jarecki. It is located just in front of the Museum’s MiG in the Cold War Aviation area. Jarecki is not exactly a household name, I know, but someone with a unique and interesting background nevertheless.

A while ago, I was fortunate enough to meet Jarecki when he was at the Center taping a Polish TV documentary about his life.

Jarecki was a pilot in the Polish Air Force when, on March 5, 1953, he defected to the West in his MiG-15 by flying to Bornholm, Denmark. It was the first intact MiG-15 to reach the West. Not only did it allow Western aviation experts to take apart and examine a Soviet fighter jet, but also Jarecki was able to provide first-hand information about Soviet aircraft and air tactics.

Jarecki told me that before his defection, he did not think carefully about what he was doing.  He said he was “ignorant,” actually.  He did not think about what might happen to his mother, who was arrested and imprisoned for a while.

The U.S. government interrogated him a lot when he came to the United States, he told me, trying to figure out if he was truly a defector or a spy.  But, he pointed out, “Why would the Poles let him come here in a MiG?  It was a brand new one, the latest model.”

Once it was determined he was not a spy, Jarecki began a new life in the United States and became somewhat of a media celebrity. He settled in Erie, Pennsylvania and eventually established his own company, Jarecki Industries. He married and had five children.

During our brief meeting, Jarecki was very congenial and told stories about his life in communist Poland and his adjustment in the United States. He particularly enjoyed telling me about all the movie stars he has met. I greatly enjoyed my first, and probably last, encounter with a genuine, history-making figure from the Cold War. ."
            };
            article2.Exhibits.Add(context.Exhibits.FirstOrDefault(item => item.Name == "Lt. Franciszek Jarecki flight suit at the Udvar-Hazy Center"));

            context.Articles.AddOrUpdate(
                item => item.Name,
                article1,
                article2);
        }

        // Loads list of TXmlModels from embedded xml resource file and maps it a given TEntry
        private IEnumerable<TEntry> LoadData<TEntry, TXmlModel>(Func<TXmlModel, TEntry> mapper)
        {
            // Open stream to xml with data for a given TEntry, which is part of assembly resources
            using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream($"SpaceMuseum.Data.Migrations.Test.Data.{typeof(TEntry).Name}s.xml"))
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
    }

    // The xml model for the Article entry
    public class ArticleXmlModel
    {
        // TODO: Consider using predefined (in xml) GUID
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
