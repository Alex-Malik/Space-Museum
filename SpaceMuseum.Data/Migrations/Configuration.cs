using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity.Migrations;
using System.Linq;
using Microsoft.AspNet.Identity.EntityFramework;

namespace SpaceMuseum.Data.Migrations
{
    using Models;

    internal sealed class Configuration : DbMigrationsConfiguration<DatabaseContext>
    {
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

            // add Roles
            context.Roles.AddOrUpdate(
                r => r.Name, 
                new IdentityRole { Name = "Administrator" });

            // add Users
            context.Users.AddOrUpdate(
                u => u,
                new IdentityUser { UserName = "Administrator"});

            // add exhibit types
            context.ExhibitTypes.AddOrUpdate(
                item => item,
                new ExhibitType { Description = "Missiles" },
                new ExhibitType { Description = "Spacesuits" },
                new ExhibitType { Description = "Navigational Satellite" },
                new ExhibitType { Description = "Other" });

            // add exhibits
            context.Exhibits.AddOrUpdate(
                item => item,
                new Exhibit
                {
                    Name = "Navigational Satellite, Transit 5-A",
                    Description = 
@"Beginning in the 1960s, the United States Navy began developing a communications and navigation satellite program to meet the needs of ships at sea and submarines. One result of this program was the Transit satellite series, designed and built to Navy specifications by the Johns Hopkins University Applied Physics Laboratory in Maryland.

Submarines received radio signals from a Transit satellite, whose orbit was known to great accuracy, as it passed overhead. The change in frequency of the signal due to the Doppler effect told the submarine that the satellite was directly overhead. The submarine commander could establish a position without having to surface and take reading on stars--the traditional method of navigation, but a risky one for a submarine.

The Transit V-A satellite is an operational backup to the Transit series and was donated to NASM by the JHU Applied Physics Lab in late 1984.",
                    ExhibitType = context.ExhibitTypes.FirstOrDefault(it => it.Name == "Navigational Satellite")
                },
                new Exhibit
                {
                    Name = "Minuteman III Missile",
                    Description =
@"This a training version of the Minuteman III intercontinental-range ballistic missile, deployed since 1970 by the U.S. Air Force. A three-stage, solid-fuel missile, Minuteman IIIs until recently carried up to three independently targeted Mk 12A nuclear warheads a maximum distance of 13,000 km (8,000 miles). They now carry a single nuclear warhead pursuant to arms control agreements between the United States and Russia. Made by Boeing, this missile was donated by the U.S. Air Force.",
                    ExhibitType = context.ExhibitTypes.FirstOrDefault(it => it.Name == "Missiles")
                },
                new Exhibit
                {
                    Name = "Tomahawk Cruise Missile",
                    Description =
@"This is a flight test version of the Tomahawk, a U.S. Navy long-range, subsonic cruise missile capable of being launched from surface ships and submarines. It flew in four tests from 1976-1978. Operational missiles are launched by a solid-fueled booster rocket and carried to their target by a turbofan jet engine. The Tomahawk flies near the surface at 550 mph and uses satellite-assisted navigation and TERCOM (Terrain Contour Matching) radar to guide it to a target up to approximately 1,500 miles distant. It can carry either a conventional or a nuclear warhead. General Dynamics built this missile and the U.S. Navy donated it to NASM in 1981. Before doing so, the U.S. Navy removed the missile's warhead, guidance system, and engine.",
                    ExhibitType = context.ExhibitTypes.FirstOrDefault(it => it.Name == "Missiles")
                },
                new Exhibit
                {
                    Name = "Skylab Orbital Workshop",
                    Description =
@"The orbital workshop is the largest component of Skylab, America's first space station. It houses the living quarters, work and storage areas, research equipment, and most of the supplies needed to support a succession of three-man crews. Two complete Skylab space stations were manufactured and equipped for flight, and one was launched into Earth orbit in May 1973. After the Skylab program was canceled as effort shifted to Space Shuttle development, NASA transferred the backup Skylab to the National Air and Space Museum in 1975. On display in the Museum's Space Hall since 1976, the orbital workshop has been slightly modified to permit viewers to walk through the living quarters.",
                    ExhibitType = context.ExhibitTypes.FirstOrDefault(it => it.Name == "Other")
                },
                new Exhibit
                {
                    Name = "Model, Rocket, Jupiter C, 1:48",
                    Description =
@"This is a 1:48 scale model of the Jupiter-C, a four-stage rocket developed by the U.S. Army Ballistic Missile Agency that used a modified Redstone ballistic missile as its first stage. In 1956 and 1957 it was used to launch components of the Jupiter intermediate-range ballistic missile for testing purposes. After the USSR launched the world's first satellite (Sputnik I) in October 1957, the Army placed America's first satellite (Explorer I) in orbit on January 31, 1958, using the Jupiter-C. The rocket was used several more times in the following two years to launch subsequent Explorer and Beacon satellites. NASA's Marshall Space Flight Center built this model and transferred it to NASM in 1972.",
                    ExhibitType = context.ExhibitTypes.FirstOrDefault(it => it.Name == "Missiles")
                },
                new Exhibit
                {
                    Name = "Medal, Yuri Gagarin",
                    Description =
@"Commemorative pins and medals are one way in which Russian and Soviet leaders have recognized accomplishments and individuals in the space program. Initially limited groups of people within the space program received medals. As the space programs grew in prestige and publicity, the medals increased in numbers and played an increasing role in celebrating the accomplishments of the space program. Ultimately, medals became the currency of diplomatic gifts from the Soviet Union. High government or industry officials would give these medals as gifts to their counterparts abroad, including the United States. The typical medals had the main, commemorative theme on the front and supporting statement on the reverse.

This medal commemorates the life of the first man in space, Yuri Gagarin, who died in 1968.",
                    ExhibitType = context.ExhibitTypes.FirstOrDefault(it => it.Name == "Other")
                },
                new Exhibit
                {
                    Name = "Lt. Franciszek Jarecki flight suit at the Udvar-Hazy Center",
                    Description =
@"On the morning of March 5, 1953, Lt. Franciszek Jarecki defected from the Polish Air Force while leading a patrol of four MiG-15s from his base at Stolp, Poland. He wore this flight suit during his daring flight to freedom.",
                    ExhibitType = context.ExhibitTypes.FirstOrDefault(it => it.Name == "Spacesuits")
                },
                new Exhibit
                {
                    Name = "Model, Rocket, Scout w/Launch Tower",
                    Description =
@"This is a model of the Scout rocket and its launch tower. Developed by the National Aeronautics and Space Administration (NASA), the Scout was a solid-fuel, four-stage rocket that was first used in 1960. Over the next thirty-four years the rocket underwent several improvements and was used to launch a variety of scientific satellites and probes by NASA, the Department of Defense, and the European Space Research Organization. In the end, the Scout proved to be one of the most reliable, versatile, and cost-effective launch vehicles ever developed.

Neither the manufacturer nor donor of this artifact are known.",
                    ExhibitType = context.ExhibitTypes.FirstOrDefault(it => it.Name == "Missiles")
                },
                new Exhibit
                {
                    Name = "Lens, 80mm, Xenotar, Gemini",
                    Description =
@"The 80mm Zeiss Xenotar lenses were standard lenses for Maurer cameras on human spaceflight missions during Project Gemini. The equipment available for these photographic work during Gemini was extensive, including lenses of different focal lengths, special filters, and extra film magazines, which increased the types and amount of photographic work astronauts could do in space.

This lens was transferred from NASA to the Museum in 1972.",
                    ExhibitType = context.ExhibitTypes.FirstOrDefault(it => it.Name == "Other")
                });

            // add images
            context.Images.AddOrUpdate(
                item => item,
                new Image
                {
                    Name = "Medal, Yuri Gagarin",
                    Description = "Medal, Yuri Gagarin", 
                    URL = @"https://airandspace.si.edu/sites/default/files/styles/slideshow_sm/public/images/collection-objects/record-images/A20020464000cp01.jpg?itok=5ksZiy18", 
                    MIME = "image/jpeg"
                },
                new Image
                {
                    Name = "Model, Rocket, Jupiter C, 1:48",
                    Description = "Model, Rocket, Jupiter C, 1:48",
                    URL = @"https://airandspace.si.edu/sites/default/files/styles/slideshow_sm/public/images/collection-objects/record-images/A19720992000s.JPG?itok=Y7yklHYg",
                    MIME = "image/jpeg"
                },
                new Image
                {
                    Name = "Skylab Orbital Workshop",
                    Description = "Skylab Orbital Workshop",
                    URL = @"https://airandspace.si.edu/sites/default/files/styles/slideshow_sm/public/images/collection-objects/record-images/A19761033000CP58.jpg?itok=2Py8Z9vW",
                    MIME = "image/jpeg"
                },
                new Image
                {
                    Name = "Skylab Orbital Workshop",
                    Description = "Skylab Orbital Workshop",
                    URL = @"https://airandspace.si.edu/webimages/collections/full/A19761033000D1.JPG",
                    MIME = "image/jpeg"
                },
                new Image
                {
                    Name = "Tomahawk Cruise Missile",
                    Description = "Tomahawk Cruise Missile",
                    URL = @"https://airandspace.si.edu/sites/default/files/styles/slideshow_sm/public/images/collection-objects/record-images/A19820119000CP01.JPG?itok=jBcBOHad",
                    MIME = "image/jpeg"
                },
                new Image
                {
                    Name = "Minuteman III Missile",
                    Description = "Minuteman III Missile",
                    URL = @"https://airandspace.si.edu/sites/default/files/styles/slideshow_sm/public/images/collection-objects/record-images/A19761115000d.jpg?itok=W6PJqZ9p",
                    MIME = "image/jpeg"
                },
                new Image
                {
                    Name = "Navigational Satellite, Transit 5-A",
                    Description = "Navigational Satellite, Transit 5-A",
                    URL = @"https://airandspace.si.edu/sites/default/files/styles/slideshow_sm/public/images/collection-objects/record-images/Transit_Artifacts213_0009.jpg?itok=FBDsW92n",
                    MIME = "image/jpeg"
                },
                new Image
                {
                    Name = "Navigational Satellite, Transit 5-A",
                    Description = "Navigational Satellite, Transit 5-A",
                    URL = @"https://airandspace.si.edu/webimages/collections/full/A19850001000cu01.jpg",
                    MIME = "image/jpeg"
                },
                new Image
                {
                    Name = "Lt. Franciszek Jarecki flight suit at the Udvar-Hazy Center",
                    Description = "Lt. Franciszek Jarecki flight suit at the Udvar-Hazy Center",
                    URL = @"https://airandspace.si.edu/sites/default/files/styles/callout_half/public/images/editoral-stories/thumbnails/WEB10854-2008h.jpg?itok=sHot2lfm",
                    MIME = "image/jpeg"
                },
                new Image
                {
                    Name = "Model, Rocket, Scout w/Launch Tower",
                    Description = "Model, Rocket, Scout w/Launch Tower",
                    URL = @"http://ids.si.edu/ids/deliveryService?id=NASM-9752698A2CF82_002",
                    MIME = "image/jpeg"
                },
                new Image
                {
                    Name = "Lens, 80mm, Xenotar, Gemini",
                    Description = "Lens, 80mm, Xenotar, Gemini",
                    URL = @"https://airandspace.si.edu/sites/default/files/styles/slideshow_sm/public/images/collection-objects/record-images/NASM-558808650DB82_01.jpg?itok=O92QZ-e8",
                    MIME = "image/jpeg"
                },
                new Image
                {
                    Name = "Lens, 80mm, Xenotar, Gemini",
                    Description = "Lens, 80mm, Xenotar, Gemini",
                    URL = @"http://ids.si.edu/ids/deliveryService?id=NASM-558808650DB82_05",
                    MIME = "image/jpeg"
                },
                new Image
                {
                    Name = "Event: Observe the Sun with safe telescopes",
                    Description = "Observe the Sun with safe telescopes",
                    URL = @"https://airandspace.si.edu/sites/default/files/styles/callout_half/public/images/events/ObservatoryDaytime_EventPhoto.jpg?itok=tAurEBAu",
                    MIME = "image/jpeg"
                },
                new Image
                {
                    Name = "Event: Round and Round We Go: Innovation",
                    Description = "Round and Round We Go: Innovation",
                    URL = @"https://airandspace.si.edu/sites/default/files/styles/callout_half/public/images/events/December%20Making%20STEM%20Magic.jpg?itok=WeITozUu",
                    MIME = "image/jpeg"
                },
                new Image
                {
                    Name = "Event: On Earth by Brian Karas",
                    Description = "On Earth by Brian Karas",
                    URL = @"https://airandspace.si.edu/sites/default/files/styles/callout_half/public/images/events/9670_640_2.jpg?itok=9n7N5FAg&c=21aef1a914e8d6acdef6b9b9106baa41",
                    MIME = "image/jpeg"
                },
                new Image
                {
                    Name = "Event: Reaction Motors: America's First Liquid-Propellant Rocket Company",
                    Description = "Reaction Motors: America's First Liquid-Propellant Rocket Company",
                    URL = @"https://airandspace.si.edu/sites/default/files/styles/callout_half/public/images/events/A19510007000_NASM2015-07303.jpg?itok=TnuwkD3q&c=d5eb1845487a3d2af4f412dcab28206d",
                    MIME = "image/jpeg"
                },
                new Image
                {
                    Name = "Event: Astronomy Chat with Courtney Dressing",
                    Description = "Astronomy Chat with Courtney Dressing",
                    URL = @"https://airandspace.si.edu/sites/default/files/styles/callout_half/public/images/events/4966h_1.jpg?itok=aA8vuzGv",
                    MIME = "image/jpeg"
                });

            // link images with exhibits
            foreach (var image in context.Images)
            {
                var exhibit = context.Exhibits.FirstOrDefault(item => item.Name == image.Name);
                if (exhibit != null)
                {
                    exhibit.Images.Add(image);
                }
            }

            // add articles
            var article1 = new Article
            {
                Name = "Why Yuri Gagarin Remains the First Man in Space, Even Though He Did Not Land Inside His Spacecraft",
                Description =
@"Every year as the anniversary of the first human spaceflight approaches, I receive calls inquiring about the validity of Yuri Gagarin’s claim as the first human in space.  The legitimate questions focus on the fact that Gagarin did not land inside his spacecraft.  The reasoning goes that since he did not land inside his spacecraft, he disqualified himself from the record books.  This might seem to be a very reasonable argument, but Gagarin remains the first man in space.  The justification for Gagarin remaining in that position lies in the organization that sets the standards for flight.
The Fédération Aéronautique Internationale (FAI) is the world's air sports federation.  It was founded in 1905 as a non-governmental and non-profit making international organization to further aeronautical and astronautical activities worldwide.  Among its duties, the FAI certifies and registers records.  Its first records in aviation date back to 1906.  The organization also arbitrates disputes over records.  If nationals from two different countries claim a record, it is the FAI’s job to examine the submitted documentation and make a ruling as to who has accomplished the feat first.  When it was apparent that the United States and the Union of Soviet Socialist Republics were planning to launch men into space, the FAI specified spaceflight guidelines.  One of the stipulations that the FAI carried over from aviation was that spacecraft pilots, like aircraft pilots should land inside their craft in order for the record to be valid.  In the case of aviation, this made perfect sense.  No one wanted to encourage pilots to sacrifice themselves for an aviation record.  Piloting an aircraft that could not land did nothing to further aeronautical engineering. When Yuri Gagarin orbited the Earth on 12 April 1961, the plan had never been for him to land inside his Vostok spacecraft.  His spherical reentry capsule came through the Earth’s atmosphere on a ballistic trajectory.  Soviet engineers had not yet perfected a braking system that would slow the craft sufficiently for a human to survive impact.  They decided to eject the cosmonaut from his craft.  Yuri Gagarin ejected at 20,000 feet and landed safely on Earth.  Soviet engineers had not discussed this shortcoming with Soviet delegates to the FAI prior to his flight.  They prepared their documents for the FAI omitting this fact.  This led everyone to believe that Gagarin had landed inside his spacecraft.  It was not until four months later, when German Titov became the second human to orbit the Earth and the first person to spend a full day in space, when the controversy began to brew.  Titov owned up to ejecting himself.  This led to a special meeting of the delegates to the FAI to reexamine Titov’s spaceflight records.  The conclusion of the delegates was to rework the parameters of human spaceflight to recognize that the great technological accomplishment of spaceflight was the launch, orbiting and safe return of the human, not the manner in which he or she landed.  Gagarin and Titov’s records remained on the FAI books.  Even after Soviet -made models of the Vostok spacecraft  made it clear that the craft had no braking capability, the FAI created the Gagarin Medal that it awards annually to greatest aviation or space achievement of that year. One should keep other examples of a sports federations’ reconsideration of rules in the face of new techniques and technologies in mind when considering the FAI Gagarin decision.  The underwater dolphin kick in freestyle swimming and the introduction of the clap skate in speed skating both caused initial international flaps.  After the respective sports federations voted to accept these changes, that ended the controversy.  Yes, Gagarin did not follow the rules that the FAI established before his flight.  However, as is true with any sports organization, the FAI reserved the right to reexamine and reinterpret its rules in light of new knowledge and circumstances.  Yuri Gagarin remains indisputably the first person in space and the concept that the first cosmonauts had to land inside their spacecraft is a faded artifact of the transition from aviation to spaceflight. "
            };
            article1.Exhibits.Add(context.Exhibits.FirstOrDefault(item => item.Name == "Medal, Yuri Gagarin"));

            var article2 = new Article
            {
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
                item => item,
                article1,
                article2);

            // add events
            context.Events.AddOrUpdate(
                item => item,
                new Event { 
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
                    Name = "Round and Round We Go: Innovation",
                    IsPassed = false,
                    Description =
@"Learn about the Wright brothers and test your design skills in our December challenge as you design, create, and test your own paper copter. AHS International – The Vertical Flight Technical Society will be on hand to help out with today's design challenge. 

Making STEM Magic is a new program that introduces young visitors to engineering in a fun and creative way. Learn by doing. Design, build, and test a prototype that solves a given challenge. Every month we'll explore a new theme and introduce a new problem to be solved, so come back each month to accept the challenge and learn to think like an engineer. 

Making STEM Magic is held every Saturday from 10:00 am to 3:00 pm. Learn more about future Making STEM Magic challenges."
                },
                new Event
                {
                    Name = "On Earth by Brian Karas",
                    IsPassed = false,
                    Description =
@"Museum staff read stories about famous aviators, hot-air balloon flights, trips to Mars, characters visible in the night sky, or creatures that have their own wings. Each session includes one story and a hands-on activity. Groups larger than 15 are encouraged to reserve a program through the group reservation form.

These programs are made possible through the generous support of the Conrad N. Hilton Foundation."
                },
                new Event
                {
                    Name = "Reaction Motors: America's First Liquid-Propellant Rocket Company",
                    IsPassed = false,
                    Description =
@"Join senior curator Michael Neufeld as he discusses the 75th anniversary of Reaction Motors, Inc.., America's first liquid-propellant rocket company. Meet at the Welcome Center in the Boeing Milestones of Flight Hall on the first floor.

Please note: Although Ask an Expert talks are usually held on Wednesdays, this Ask an Expert will be held on Thursday, December 15.

About the Ask an Expert lecture series: Every Wednesday at noon in the National Mall Building, a Museum staff member talks to the public about the history, collection, or personalities related to a specific artifact or exhibition in the Museum."
                },
                new Event
                {
                    Name = "Astronomy Chat with Courtney Dressing",
                    IsPassed = false,
                    Description =
@"Chat with astronomer Courtney Dressing. Ask questions about her research about habitable exoplanets, what it’s like to be an astronomer, or anything else that interests you. Courtney Dressing is an astronomer at the California Institute of Technology.

In the event of inclement weather, the program may be moved or postponed. Check @SIObservatory for updates or call (202) 633-2517.

Accessibility: The Observatory dome and Museum galleries are accessible."
                });

            // link images with events
            foreach (var image in context.Images)
            {
                var evnt = context.Events.FirstOrDefault(item => "Event: " + item.Name == image.Name);
                if (evnt != null)
                {
                    evnt.Images.Add(image);
                }
            }
        }
    }
}
