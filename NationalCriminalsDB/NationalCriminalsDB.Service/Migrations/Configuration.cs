namespace NationalCriminalsDB.Service.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.IO;
    using System.Linq;
    using System.Web;
    using Models;

    internal sealed class Configuration : DbMigrationsConfiguration<ServiceDbContext>
    {
        private Random random = new Random();

        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "NationalCriminalsDB.Service.Models.ServiceDbContext";
        }

        private DateTime GenerateRandomDate(DateTime startDate, DateTime endDate)
        {
            var timeSpan = endDate - startDate;
            var newSpan = new TimeSpan(random.Next(0, (int)timeSpan.TotalHours), 0, 0);
            return startDate + newSpan;
        }

        private IEnumerable<Criminal> GenerateData()
        {
            #region Initial Data
            // Some constant variables
            var minHeight = 100;
            var maxHeight = 250;
            var minWeight = 40;
            var maxWeight = 200;
            var minDate = new DateTime(1900, 1, 1);
            var maxDate = DateTime.Now.AddYears(-18);
            var femaleConvictPhoto = @"https://s-media-cache-ak0.pinimg.com/236x/ae/09/dd/ae09dd6aa3bea0474a085386f78b8396.jpg";
            var maleConvictPhoto = @"http://image.shutterstock.com/z/stock-vector-convict-cartoon-character-85485988.jpg";

            // Creating data
            var data = new Criminal[] {
                new Criminal()
                {
                    CriminalId = Guid.NewGuid(),
                    Address = "California",
                    FirstName = "John",
                    LastName = "Murphy",
                    Nationality = "USA",
                    Photo = maleConvictPhoto,
                    DateOfBirth = GenerateRandomDate(minDate, maxDate),
                    Height = random.Next(minHeight, maxHeight),
                    Sex = Sex.Male,
                    Weight = random.Next(minWeight, maxWeight),
                    CriminalHistory = new List<Crime>()
                    {
                        new Crime()
                        {
                            CrimeID = Guid.NewGuid(),
                            Description = @"Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean massa. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Donec quam felis, ultricies nec, pellentesque eu, pretium quis, sem. Nulla consequat massa quis enim. Donec pede justo, fringilla vel, aliquet nec, vulputate eget, arcu. In enim justo, rhoncus ut, imperdiet a, venenatis vitae, justo. Nullam dictum felis eu pede mollis pretium. Integer tincidunt. Cras dapibus. Vivamus elementum semper nisi. Aenean vulputate eleifend tellus. Aenean leo ligula, porttitor eu, consequat vitae, eleifend ac, enim. Aliquam lorem ante, dapibus in, viverra quis, feugiat",
                            Location = "LA",
                            Victime = "Lorem ipsum",
                            Criminals = new List<Criminal>(),
                            Time = GenerateRandomDate(minDate, DateTime.Now),
                            Type = CrimeType.Homicide
                        },
                        new Crime()
                        {
                            CrimeID = Guid.NewGuid(),
                            Description = @"Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean massa. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Donec quam felis, ultricies nec, pellentesque eu, pretium quis, sem. Nulla consequat massa quis enim. Donec pede justo, fringilla vel, aliquet nec, vulputate eget, arcu. In enim justo, rhoncus ut, imperdiet a, venenatis vitae, justo. Nullam dictum felis eu pede mollis pretium. Integer tincidunt. Cras dapibus. Vivamus elementum semper nisi. Aenean vulputate eleifend tellus. Aenean leo ligula, porttitor eu, consequat vitae, eleifend ac, enim. Aliquam lorem ante, dapibus in, viverra quis, feugiat",
                            Location = "NYC",
                            Victime = "Lorem ipsum",
                            Criminals = new List<Criminal>(),
                            Time = GenerateRandomDate(minDate, DateTime.Now),
                            Type = CrimeType.Rape
                        },
                    },
                },
                new Criminal()
                {
                    CriminalId = Guid.NewGuid(),
                    Address = "Munich",
                    FirstName = "Jane",
                    LastName = "John",
                    Nationality = "Germany",
                    Photo = femaleConvictPhoto,
                    DateOfBirth = GenerateRandomDate(minDate, maxDate),
                    Height = random.Next(minHeight, maxHeight),
                    Sex = Sex.Female,
                    Weight = random.Next(minWeight, maxWeight),
                    CriminalHistory = new List<Crime>()
                    {
                        new Crime()
                        {
                            CrimeID = Guid.NewGuid(),
                            Description = @"Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean massa. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Donec quam felis, ultricies nec, pellentesque eu, pretium quis, sem. Nulla consequat massa quis enim. Donec pede justo, fringilla vel, aliquet nec, vulputate eget, arcu. In enim justo, rhoncus ut, imperdiet a, venenatis vitae, justo. Nullam dictum felis eu pede mollis pretium. Integer tincidunt. Cras dapibus. Vivamus elementum semper nisi. Aenean vulputate eleifend tellus. Aenean leo ligula, porttitor eu, consequat vitae, eleifend ac, enim. Aliquam lorem ante, dapibus in, viverra quis, feugiat",
                            Location = "Munich",
                            Victime = "Lorem ipsum",
                            Criminals = new List<Criminal>(),
                            Time = GenerateRandomDate(minDate, DateTime.Now),
                            Type = CrimeType.Robbery
                        },
                    },
                },
                new Criminal()
                {
                    CriminalId = Guid.NewGuid(),
                    Address = "Cairo",
                    FirstName = "Saly",
                    LastName = "Ahmed",
                    Nationality = "Egypt",
                    Photo = femaleConvictPhoto,
                    DateOfBirth = GenerateRandomDate(minDate, maxDate),
                    Height = random.Next(minHeight, maxHeight),
                    Sex = Sex.Female,
                    Weight = random.Next(minWeight, maxWeight),
                    CriminalHistory = new List<Crime>()
                    {
                        new Crime()
                        {
                            CrimeID = Guid.NewGuid(),
                            Description = @"Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean massa. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Donec quam felis, ultricies nec, pellentesque eu, pretium quis, sem. Nulla consequat massa quis enim. Donec pede justo, fringilla vel, aliquet nec, vulputate eget, arcu. In enim justo, rhoncus ut, imperdiet a, venenatis vitae, justo. Nullam dictum felis eu pede mollis pretium. Integer tincidunt. Cras dapibus. Vivamus elementum semper nisi. Aenean vulputate eleifend tellus. Aenean leo ligula, porttitor eu, consequat vitae, eleifend ac, enim. Aliquam lorem ante, dapibus in, viverra quis, feugiat",
                            Location = "Cairo",
                            Victime = "Lorem ipsum",
                            Criminals = new List<Criminal>(),
                            Time = GenerateRandomDate(minDate, DateTime.Now),
                            Type = CrimeType.Robbery
                        },
                        new Crime()
                        {
                            CrimeID = Guid.NewGuid(),
                            Description = @"Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean massa. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Donec quam felis, ultricies nec, pellentesque eu, pretium quis, sem. Nulla consequat massa quis enim. Donec pede justo, fringilla vel, aliquet nec, vulputate eget, arcu. In enim justo, rhoncus ut, imperdiet a, venenatis vitae, justo. Nullam dictum felis eu pede mollis pretium. Integer tincidunt. Cras dapibus. Vivamus elementum semper nisi. Aenean vulputate eleifend tellus. Aenean leo ligula, porttitor eu, consequat vitae, eleifend ac, enim. Aliquam lorem ante, dapibus in, viverra quis, feugiat",
                            Location = "Alexandria",
                            Victime = "Lorem ipsum",
                            Criminals = new List<Criminal>(),
                            Time = GenerateRandomDate(minDate, DateTime.Now),
                            Type = CrimeType.Fraude
                        },
                        new Crime()
                        {
                            CrimeID = Guid.NewGuid(),
                            Description = @"Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean massa. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Donec quam felis, ultricies nec, pellentesque eu, pretium quis, sem. Nulla consequat massa quis enim. Donec pede justo, fringilla vel, aliquet nec, vulputate eget, arcu. In enim justo, rhoncus ut, imperdiet a, venenatis vitae, justo. Nullam dictum felis eu pede mollis pretium. Integer tincidunt. Cras dapibus. Vivamus elementum semper nisi. Aenean vulputate eleifend tellus. Aenean leo ligula, porttitor eu, consequat vitae, eleifend ac, enim. Aliquam lorem ante, dapibus in, viverra quis, feugiat",
                            Location = "Mansoura",
                            Victime = "Lorem ipsum",
                            Criminals = new List<Criminal>(),
                            Time = GenerateRandomDate(minDate, DateTime.Now),
                            Type = CrimeType.Fraude
                        },
                    },
                },
                new Criminal()
                {
                    CriminalId = Guid.NewGuid(),
                    Address = "Quebec",
                    FirstName = "Nicolas",
                    LastName = "Bordeau",
                    Nationality = "Canada",
                    Photo = maleConvictPhoto,
                    DateOfBirth = GenerateRandomDate(minDate, maxDate),
                    Height = random.Next(minHeight, maxHeight),
                    Sex = Sex.Male,
                    Weight = random.Next(minWeight, maxWeight),
                    CriminalHistory = new List<Crime>()
                    {
                        new Crime()
                        {
                            CrimeID = Guid.NewGuid(),
                            Description = @"Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean massa. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Donec quam felis, ultricies nec, pellentesque eu, pretium quis, sem. Nulla consequat massa quis enim. Donec pede justo, fringilla vel, aliquet nec, vulputate eget, arcu. In enim justo, rhoncus ut, imperdiet a, venenatis vitae, justo. Nullam dictum felis eu pede mollis pretium. Integer tincidunt. Cras dapibus. Vivamus elementum semper nisi. Aenean vulputate eleifend tellus. Aenean leo ligula, porttitor eu, consequat vitae, eleifend ac, enim. Aliquam lorem ante, dapibus in, viverra quis, feugiat",
                            Location = "Montreal",
                            Victime = "Lorem ipsum",
                            Criminals = new List<Criminal>(),
                            Time = GenerateRandomDate(minDate, DateTime.Now),
                            Type = CrimeType.Robbery
                        },
                    },
                },
                new Criminal()
                {
                    CriminalId = Guid.NewGuid(),
                    Address = "London",
                    FirstName = "John",
                    LastName = "Murphy",
                    Nationality = "UK",
                    Photo = maleConvictPhoto,
                    DateOfBirth = GenerateRandomDate(minDate, maxDate),
                    Height = random.Next(minHeight, maxHeight),
                    Sex = Sex.Male,
                    Weight = random.Next(minWeight, maxWeight),
                    CriminalHistory = new List<Crime>()
                    {
                        new Crime()
                        {
                            CrimeID = Guid.NewGuid(),
                            Description = @"Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean massa. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Donec quam felis, ultricies nec, pellentesque eu, pretium quis, sem. Nulla consequat massa quis enim. Donec pede justo, fringilla vel, aliquet nec, vulputate eget, arcu. In enim justo, rhoncus ut, imperdiet a, venenatis vitae, justo. Nullam dictum felis eu pede mollis pretium. Integer tincidunt. Cras dapibus. Vivamus elementum semper nisi. Aenean vulputate eleifend tellus. Aenean leo ligula, porttitor eu, consequat vitae, eleifend ac, enim. Aliquam lorem ante, dapibus in, viverra quis, feugiat",
                            Location = "London",
                            Victime = "Lorem ipsum",
                            Criminals = new List<Criminal>(),
                            Time = GenerateRandomDate(minDate, DateTime.Now),
                            Type = CrimeType.Homicide
                        },
                        new Crime()
                        {
                            CrimeID = Guid.NewGuid(),
                            Description = @"Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean massa. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Donec quam felis, ultricies nec, pellentesque eu, pretium quis, sem. Nulla consequat massa quis enim. Donec pede justo, fringilla vel, aliquet nec, vulputate eget, arcu. In enim justo, rhoncus ut, imperdiet a, venenatis vitae, justo. Nullam dictum felis eu pede mollis pretium. Integer tincidunt. Cras dapibus. Vivamus elementum semper nisi. Aenean vulputate eleifend tellus. Aenean leo ligula, porttitor eu, consequat vitae, eleifend ac, enim. Aliquam lorem ante, dapibus in, viverra quis, feugiat",
                            Location = "London",
                            Victime = "Lorem ipsum",
                            Criminals = new List<Criminal>(),
                            Time = GenerateRandomDate(minDate, DateTime.Now),
                            Type = CrimeType.Robbery
                        },
                        new Crime()
                        {
                            CrimeID = Guid.NewGuid(),
                            Description = @"Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean massa. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Donec quam felis, ultricies nec, pellentesque eu, pretium quis, sem. Nulla consequat massa quis enim. Donec pede justo, fringilla vel, aliquet nec, vulputate eget, arcu. In enim justo, rhoncus ut, imperdiet a, venenatis vitae, justo. Nullam dictum felis eu pede mollis pretium. Integer tincidunt. Cras dapibus. Vivamus elementum semper nisi. Aenean vulputate eleifend tellus. Aenean leo ligula, porttitor eu, consequat vitae, eleifend ac, enim. Aliquam lorem ante, dapibus in, viverra quis, feugiat",
                            Location = "London",
                            Victime = "Lorem ipsum",
                            Criminals = new List<Criminal>(),
                            Time = GenerateRandomDate(minDate, DateTime.Now),
                            Type = CrimeType.Fraude
                        },
                    },
                },
                new Criminal()
                {
                    CriminalId = Guid.NewGuid(),
                    Address = "Paris",
                    FirstName = "Alice",
                    LastName = "Bordeau",
                    Nationality = "France",
                    Photo = femaleConvictPhoto,
                    DateOfBirth = GenerateRandomDate(minDate, maxDate),
                    Height = random.Next(minHeight, maxHeight),
                    Sex = Sex.Female,
                    Weight = random.Next(minWeight, maxWeight),
                    CriminalHistory = new List<Crime>()
                    {
                        new Crime()
                        {
                            CrimeID = Guid.NewGuid(),
                            Description = @"Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean massa. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Donec quam felis, ultricies nec, pellentesque eu, pretium quis, sem. Nulla consequat massa quis enim. Donec pede justo, fringilla vel, aliquet nec, vulputate eget, arcu. In enim justo, rhoncus ut, imperdiet a, venenatis vitae, justo. Nullam dictum felis eu pede mollis pretium. Integer tincidunt. Cras dapibus. Vivamus elementum semper nisi. Aenean vulputate eleifend tellus. Aenean leo ligula, porttitor eu, consequat vitae, eleifend ac, enim. Aliquam lorem ante, dapibus in, viverra quis, feugiat",
                            Location = "Hauts-de-Seine",
                            Victime = "Lorem ipsum",
                            Criminals = new List<Criminal>(),
                            Time = GenerateRandomDate(minDate, DateTime.Now),
                            Type = CrimeType.Rape
                        },
                    },
                },
                new Criminal()
                {
                    CriminalId = Guid.NewGuid(),
                    Address = "California",
                    FirstName = "Saly",
                    LastName = "Ahmed",
                    Nationality = "Egypt",
                    Photo = femaleConvictPhoto,
                    DateOfBirth = GenerateRandomDate(minDate, maxDate),
                    Height = random.Next(minHeight, maxHeight),
                    Sex = Sex.Female,
                    Weight = random.Next(minWeight, maxWeight),
                    CriminalHistory = new List<Crime>()
                },
                new Criminal()
                {
                    CriminalId = Guid.NewGuid(),
                    Address = "California",
                    FirstName = "John",
                    LastName = "Steward",
                    Nationality = "UK",
                    Photo = maleConvictPhoto,
                    DateOfBirth = GenerateRandomDate(minDate, maxDate),
                    Height = random.Next(minHeight, maxHeight),
                    Sex = Sex.Male,
                    Weight = random.Next(minWeight, maxWeight),
                    CriminalHistory = new List<Crime>()
                    {
                        new Crime()
                        {
                            CrimeID = Guid.NewGuid(),
                            Description = @"Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean massa. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Donec quam felis, ultricies nec, pellentesque eu, pretium quis, sem. Nulla consequat massa quis enim. Donec pede justo, fringilla vel, aliquet nec, vulputate eget, arcu. In enim justo, rhoncus ut, imperdiet a, venenatis vitae, justo. Nullam dictum felis eu pede mollis pretium. Integer tincidunt. Cras dapibus. Vivamus elementum semper nisi. Aenean vulputate eleifend tellus. Aenean leo ligula, porttitor eu, consequat vitae, eleifend ac, enim. Aliquam lorem ante, dapibus in, viverra quis, feugiat",
                            Location = "LA",
                            Victime = "Lorem ipsum",
                            Criminals = new List<Criminal>(),
                            Time = GenerateRandomDate(minDate, DateTime.Now),
                            Type = CrimeType.Fraude
                        },

                        new Crime()
                        {
                            CrimeID = Guid.NewGuid(),
                            Description = @"Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean massa. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Donec quam felis, ultricies nec, pellentesque eu, pretium quis, sem. Nulla consequat massa quis enim. Donec pede justo, fringilla vel, aliquet nec, vulputate eget, arcu. In enim justo, rhoncus ut, imperdiet a, venenatis vitae, justo. Nullam dictum felis eu pede mollis pretium. Integer tincidunt. Cras dapibus. Vivamus elementum semper nisi. Aenean vulputate eleifend tellus. Aenean leo ligula, porttitor eu, consequat vitae, eleifend ac, enim. Aliquam lorem ante, dapibus in, viverra quis, feugiat",
                            Location = "New York",
                            Victime = "Lorem ipsum",
                            Criminals = new List<Criminal>(),
                            Time = GenerateRandomDate(minDate, DateTime.Now),
                            Type = CrimeType.Fraude
                        },
                    },
                },
                new Criminal()
                {
                    CriminalId = Guid.NewGuid(),
                    Address = "Washington DC",
                    FirstName = "Murphy",
                    LastName = "John",
                    Nationality = "USA",
                    Photo = maleConvictPhoto,
                    DateOfBirth = GenerateRandomDate(minDate, maxDate),
                    Height = random.Next(minHeight, maxHeight),
                    Sex = Sex.Male,
                    Weight = random.Next(minWeight, maxWeight),
                    CriminalHistory = new List<Crime>()
                    {
                        new Crime()
                        {
                            CrimeID = Guid.NewGuid(),
                            Description = @"Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean massa. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Donec quam felis, ultricies nec, pellentesque eu, pretium quis, sem. Nulla consequat massa quis enim. Donec pede justo, fringilla vel, aliquet nec, vulputate eget, arcu. In enim justo, rhoncus ut, imperdiet a, venenatis vitae, justo. Nullam dictum felis eu pede mollis pretium. Integer tincidunt. Cras dapibus. Vivamus elementum semper nisi. Aenean vulputate eleifend tellus. Aenean leo ligula, porttitor eu, consequat vitae, eleifend ac, enim. Aliquam lorem ante, dapibus in, viverra quis, feugiat",
                            Location = "Washington DC",
                            Victime = "Lorem ipsum",
                            Criminals = new List<Criminal>(),
                            Time = GenerateRandomDate(minDate, DateTime.Now),
                            Type = CrimeType.Homicide
                        },

                        new Crime()
                        {
                            CrimeID = Guid.NewGuid(),
                            Description = @"Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean massa. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Donec quam felis, ultricies nec, pellentesque eu, pretium quis, sem. Nulla consequat massa quis enim. Donec pede justo, fringilla vel, aliquet nec, vulputate eget, arcu. In enim justo, rhoncus ut, imperdiet a, venenatis vitae, justo. Nullam dictum felis eu pede mollis pretium. Integer tincidunt. Cras dapibus. Vivamus elementum semper nisi. Aenean vulputate eleifend tellus. Aenean leo ligula, porttitor eu, consequat vitae, eleifend ac, enim. Aliquam lorem ante, dapibus in, viverra quis, feugiat",
                            Location = "Washington DC",
                            Victime = "Lorem ipsum",
                            Criminals = new List<Criminal>(),
                            Time = GenerateRandomDate(minDate, DateTime.Now),
                            Type = CrimeType.Rape
                        },
                    },
                }
            };
            #endregion

            // Fixing data dates
            foreach (var criminal in data.Where(c => c.CriminalHistory.Any(crime => c.DateOfBirth.AddYears(18) >= crime.Time)))
                criminal.DateOfBirth.AddYears(-18);

            // Accomplice
            data[6].CriminalHistory.Add(data[0].CriminalHistory.First());
            return data;
        }

        protected override void Seed(ServiceDbContext context)
        {
            var data = GenerateData();
            for (int i = 0; i < 50; i++)
                data = data.Concat(GenerateData());

            //  This method will be called after migrating to the latest version.
            context.Criminals.AddOrUpdate(c => c.CriminalId, data.ToArray());
            context.SaveChanges();
        }
    }
}
