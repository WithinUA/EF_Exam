using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Exam
{
    public class Collections
    {
        PlateStore db = new();

        ObservableCollection<Plate> Plates { get; set; }
        ObservableCollection<Publisher> Publishers { get; set; }
        ObservableCollection<Genre> Genres { get; set; }
        ObservableCollection<Band> Bands { get; set; }
        ObservableCollection<Customer> Customers { get; set; }
        ObservableCollection<Promotion> Promotions { get; set; }

        public Collections()
        {
            Random rand = new();

            db.Customers.Add(new Customer() {FirstName = "John", LastName = "Carter", SpentMoney = 392.50m, Login = "JohnC", Password = "carter123" });
            db.Customers.Add(new Customer() { FirstName = "Alice", LastName = "Adams", SpentMoney = 250.75m, Login = "AliceA", Password = "adams456" });
            db.Customers.Add(new Customer() { FirstName = "Bob", LastName = "Baker", SpentMoney = 620.20m, Login = "BobB", Password = "baker789" });
            db.Customers.Add(new Customer() { FirstName = "Charlie", LastName = "Clark", SpentMoney = 150.00m, Login = "CharlieC", Password = "clark321" });
            db.Customers.Add(new Customer() { FirstName = "David", LastName = "Davis", SpentMoney = 1000.30m, Login = "DavidD", Password = "davis987" });
            db.Customers.Add(new Customer() { FirstName = "Emma", LastName = "Evans", SpentMoney = 890.50m, Login = "EmmaE", Password = "evans654" });
            db.Customers.Add(new Customer() { FirstName = "Frank", LastName = "Ford", SpentMoney = 430.80m, Login = "FrankF", Password = "ford123" });
            db.Customers.Add(new Customer() { FirstName = "Grace", LastName = "Garcia", SpentMoney = 760.00m, Login = "GraceG", Password = "garcia456" });
            db.Customers.Add(new Customer() { FirstName = "Henry", LastName = "Hill", SpentMoney = 520.25m, Login = "HenryH", Password = "hill789" });
            db.Customers.Add(new Customer() { FirstName = "Ivy", LastName = "Irwin", SpentMoney = 320.40m, Login = "IvyI", Password = "irwin321" });
            db.SaveChanges();
            foreach (var customer in db.Customers)
            {
                if (customer.SpentMoney >= 300 && customer.SpentMoney < 650)
                    customer.DiscountPercent = 5;
                else if (customer.SpentMoney >= 650 && customer.SpentMoney < 1000)
                    customer.DiscountPercent = 10;
                else if (customer.SpentMoney >= 1000)
                    customer.DiscountPercent = 15;
            }
            db.SaveChanges();

            var genres = new List<Genre>
            {
                new Genre { Name = "Heavy Metal" },
                new Genre { Name = "Pop" },
                new Genre { Name = "Rock" },
                new Genre { Name = "Progressive Rock" },
                new Genre { Name = "Grunge" },
                new Genre { Name = "Hard Rock" },
                new Genre { Name = "Hip Hop" },
                new Genre { Name = "Electronic" },
                new Genre { Name = "Alternative Rock" },
                new Genre { Name = "Blues Rock" }
            };

            db.Genres.AddRange(genres);
            db.SaveChanges();

            var publishers = new List<Publisher>
            {
                new Publisher { Name = "Sony Music Entertainment" },
                new Publisher { Name = "Universal Music Group" },
                new Publisher { Name = "Warner Music Group" },
                new Publisher { Name = "EMI Group" },
                new Publisher { Name = "BMG Rights Management" },
                new Publisher { Name = "Capitol Music Group" },
                new Publisher { Name = "Atlantic Records" },
                new Publisher { Name = "Columbia Records" },
                new Publisher { Name = "Republic Records" },
                new Publisher { Name = "Island Records" },
                new Publisher { Name = "Interscope Records" },
                new Publisher { Name = "Def Jam Recordings" }
            };

            db.Bands.Add(new Band() { Name = "Metallica", GenreId = 1 });
            db.Bands.Add(new Band() { Name = "The Beatles", GenreId = 2 });
            db.Bands.Add(new Band() { Name = "Queen", GenreId = 3 });
            db.Bands.Add(new Band() { Name = "Pink Floyd", GenreId = 4 });
            db.Bands.Add(new Band() { Name = "Nirvana", GenreId = 5 });
            db.Bands.Add(new Band() { Name = "AC/DC", GenreId = 6 });
            db.Bands.Add(new Band() { Name = "Kendrick Lamar", GenreId = 7 });
            db.Bands.Add(new Band() { Name = "Daft Punk", GenreId = 8 });
            db.Bands.Add(new Band() { Name = "Coldplay", GenreId = 9 });
            db.Bands.Add(new Band() { Name = "The Rolling Stones", GenreId = 10 });

            

            db.Publishers.AddRange(publishers);
            db.SaveChanges();


            foreach (var genre in db.Genres)
            {
                decimal randomDiscount = new Random().Next(7, 12);
                db.Promotions.Add(new Promotion() { Name = $"Week of {genre.Name}", PromotionDiscount = randomDiscount });
            }

            db.SaveChanges();

            
            var plates = new List<Plate>
            {
                new Plate
                {
                    Name = "Master of Puppets",
                    TrackCount = 8,
                    BandId = 1,
                    GenreId = 1,
                    PublisherId = rand.Next(1,13),
                    PublishingYear = 1986,
                    SelfCoast = 10,
                    Price = 15,
                    DeliveryDate = DateTime.Now.AddDays(-64),
                    CustomerId = rand.Next(1,11),
                    SoldDate = DateTime.Now.AddDays(-22),
                    SoldCount = 38, 
                    IsSold = false 
                },
                new Plate
                {
                    Name = "Ride the Lightning",
                    TrackCount = 8,
                    BandId = 1,
                    GenreId = 1,
                    PublisherId = rand.Next(1,13),
                    PublishingYear = 1984,
                    SelfCoast = 10,
                    Price = 15,
                    DeliveryDate = DateTime.Now.AddDays(-65),
                    CustomerId = rand.Next(1,11),
                    SoldDate = DateTime.Now.AddDays(-12),
                    SoldCount = 41, 
                    IsSold = true
                },
                new Plate
                {
                    Name = "Metallica (The Black Album)",
                    TrackCount = 12,
                    BandId = 1,
                    GenreId = 1,
                    PublisherId = rand.Next(1,13),
                    PublishingYear = 1991,
                    SelfCoast = 12,
                    Price = 18,
                    DeliveryDate = DateTime.Now.AddDays(-64),
                    SoldCount = 12, 
                    IsSold = false 
                },
                new Plate
                {
                    Name = "...And Justice for All",
                    TrackCount = 9,
                    BandId = 1,
                    GenreId = 1,
                    PublisherId = rand.Next(1,13),
                    PublishingYear = 1988,
                    SelfCoast = 11,
                    Price = 16,
                    DeliveryDate = DateTime.Now.AddDays(-60),
                    SoldCount = 34, 
                    IsSold = false 
                },
                new Plate
                {
                    Name = "Kill 'Em All",
                    TrackCount = 10,
                    BandId = 1,
                    GenreId = 1,
                    PublisherId = rand.Next(1,13),
                    PublishingYear = 1983,
                    SelfCoast = 9,
                    Price = 14,
                    DeliveryDate = DateTime.Now.AddDays(-60),
                    CustomerId = rand.Next(1,11),
                    SoldCount = 28,
                    SoldDate = DateTime.Now.AddDays(-38),
                    IsSold = true
                },
                new Plate
                {
                    Name = "Please Please Me",
                    TrackCount = 14, 
                    BandId = 2, 
                    GenreId = 2, 
                    PublisherId = rand.Next(1, 13), 
                    PublishingYear = 1963, 
                    SelfCoast = 8, 
                    Price = 15,
                    SoldCount = rand.Next(11,31),
                    DeliveryDate = DateTime.Now.AddDays(-71), 
                    IsSold = false 
                },
                new Plate
                {
                    Name = "Abbey Road",
                    TrackCount = 12,
                    BandId = 2,
                    GenreId = 2,
                    PublisherId = rand.Next(1, 13),
                    PublishingYear = 1969,
                    SelfCoast = 8,
                    Price = 15,
                    SoldCount = rand.Next(11,31),
                    DeliveryDate = DateTime.Now.AddDays(-71),
                    CustomerId = rand.Next(1,11),
                    SoldDate = DateTime.Now.AddDays(-17),
                    IsSold = true
                },
                new Plate
                {
                    Name = "Rubber Soul",
                    TrackCount = 14,
                    BandId = 2,
                    GenreId = 2,
                    PublisherId = rand.Next(1, 13),
                    PublishingYear = 1965,
                    SelfCoast = 8,
                    Price = 15,
                    SoldCount = rand.Next(11,31),
                    DeliveryDate = DateTime.Now.AddDays(-71),
                    CustomerId = rand.Next(1,11),
                    SoldDate = DateTime.Now.AddDays(-21),
                    IsSold = true
                },
                new Plate
                {
                    Name = "Sgt. Pepper's Lonely Hearts Club Band",
                    TrackCount = 15,
                    BandId = 2,
                    GenreId = 2,
                    PublisherId = rand.Next(1, 13),
                    PublishingYear = 1970,
                    SelfCoast = 8,
                    Price = 15,
                    SoldCount = rand.Next(11,31),
                    DeliveryDate = DateTime.Now.AddDays(-71),
                    IsSold = false
                },
                new Plate
                {
                    Name = "Let It Be",
                    TrackCount = 12, 
                    BandId = 2, 
                    GenreId = 2, 
                    PublisherId = rand.Next(1, 13), 
                    PublishingYear = 1970, 
                    SelfCoast = 8, 
                    Price = 15,
                    SoldCount = rand.Next(11,31),
                    DeliveryDate = DateTime.Now.AddDays(-rand.Next(51, 70)),
                    IsSold = false
                }
            };

            db.Plates.Add(new Plate()
            {
                Name = "Queen",
                TrackCount = 10,
                BandId = 3, 
                GenreId = 3, 
                PublisherId = rand.Next(1, 13),
                PublishingYear = 1973,
                SelfCoast = 10,
                Price = 20,
                SoldCount = rand.Next(11, 31),
                DeliveryDate = DateTime.Now.AddDays(-rand.Next(51, 70)),
                CustomerId = rand.Next(1, 11),
                SoldDate = DateTime.Now.AddDays(-rand.Next(11,51)),
                IsSold = true
            });

            db.Plates.Add(new Plate()
            {
                Name = "Queen II",
                TrackCount = 11,
                BandId = 3, 
                GenreId = 3, 
                PublisherId = rand.Next(1, 13),
                PublishingYear = 1974,
                SelfCoast = 11,
                Price = 22,
                SoldCount = rand.Next(11, 31),
                DeliveryDate = DateTime.Now.AddDays(-rand.Next(51, 70)),
                IsSold = false
            });

            db.Plates.Add(new Plate()
            {
                Name = "Sheer Heart Attack",
                TrackCount = 13,
                BandId = 3, 
                GenreId = 3, 
                PublisherId = rand.Next(1, 13),
                PublishingYear = 1974,
                SelfCoast = 12,
                Price = 24,
                SoldCount = rand.Next(13, 31),
                DeliveryDate = DateTime.Now.AddDays(-rand.Next(51, 70)),
                CustomerId = rand.Next(1, 11),
                SoldDate = DateTime.Now.AddDays(-rand.Next(11, 51)),
                IsSold = true
            });

            db.Plates.Add(new Plate()
            {
                Name = "A Night at the Opera",
                TrackCount = 12,
                BandId = 3,
                GenreId = 3,
                PublisherId = rand.Next(1, 13),
                PublishingYear = 1975,
                SelfCoast = 13,
                Price = 26,
                SoldCount = rand.Next(11, 31),
                DeliveryDate = DateTime.Now.AddDays(-rand.Next(51, 70)),
                IsSold = false
            });

            db.Plates.Add(new Plate()
            {
                Name = "A Day at the Races",
                TrackCount = 12,
                BandId = 3, 
                GenreId = 3, 
                PublisherId = rand.Next(1, 13), 
                PublishingYear = rand.Next(1970, 1981),
                SelfCoast = 10, 
                Price = 25,
                SoldCount = rand.Next(11, 31),
                DeliveryDate = DateTime.Now.AddDays(-rand.Next(51, 70)),
                CustomerId = rand.Next(1, 11),
                SoldDate = DateTime.Now.AddDays(-rand.Next(11, 51)),
                IsSold = true
            });

            db.Plates.Add(new Plate()
            {
                Name = "The Dark Side of the Moon",
                TrackCount = 10,
                BandId = 4,
                GenreId = 4, 
                PublisherId = rand.Next(1, 13), 
                PublishingYear = 1973, 
                SelfCoast = 10, 
                Price = 20,
                SoldCount = rand.Next(11, 31),
                DeliveryDate = DateTime.Now.AddDays(-rand.Next(51, 70)),
                CustomerId = rand.Next(1, 11),
                SoldDate = DateTime.Now.AddDays(-rand.Next(11, 51)),
                IsSold = true
            });

            db.Plates.Add(new Plate()
            {
                Name = "Wish You Were Here",
                TrackCount = 9,
                BandId = 4, 
                GenreId = 4, 
                PublisherId = rand.Next(1, 13), 
                PublishingYear = 1975, 
                SelfCoast = 10, 
                Price = 20,
                SoldCount = rand.Next(11, 31),
                DeliveryDate = DateTime.Now.AddDays(-rand.Next(51, 70)), 
                IsSold = false 
            });

            db.Plates.Add(new Plate()
            {
                Name = "The Wall",
                TrackCount = 26,
                BandId = 4, 
                GenreId = 4, 
                PublisherId = rand.Next(1, 13), 
                PublishingYear = 1979, 
                SelfCoast = 10, 
                Price = 20,
                SoldCount = rand.Next(11, 31),
                DeliveryDate = DateTime.Now.AddDays(-rand.Next(51, 70)),
                CustomerId = rand.Next(1, 11),
                SoldDate = DateTime.Now.AddDays(-rand.Next(11, 51)),
                IsSold = true
            });

            db.Plates.Add(new Plate()
            {
                Name = "Animals",
                TrackCount = 5,
                BandId = 4, 
                GenreId = 4, 
                PublisherId = rand.Next(1, 13), 
                PublishingYear = 1977,
                SelfCoast = 10, 
                Price = 20,
                SoldCount = rand.Next(11, 31),
                DeliveryDate = DateTime.Now.AddDays(-rand.Next(51, 70)), 
                IsSold = false 
            });

            db.Plates.Add(new Plate()
            {
                Name = "Meddle",
                TrackCount = 6,
                BandId = 4, 
                GenreId = 4, 
                PublisherId = rand.Next(1, 13), 
                PublishingYear = 1971, 
                SelfCoast = 10, 
                Price = 20,
                SoldCount = rand.Next(11, 31),
                DeliveryDate = DateTime.Now.AddDays(-rand.Next(51, 70)),
                CustomerId = rand.Next(1, 11),
                SoldDate = DateTime.Now.AddDays(-rand.Next(11, 51)),
                IsSold = true
            });

            db.Plates.Add(new Plate()
            {
                Name = "Nevermind",
                TrackCount = 12,
                BandId = 5, 
                GenreId = 5, 
                PublisherId = rand.Next(1, 13),
                PublishingYear = rand.Next(1989, 1992),
                SelfCoast = 10,
                Price = 20,
                SoldCount = rand.Next(11, 31),
                DeliveryDate = DateTime.Now.AddDays(-rand.Next(51, 70)),
                CustomerId = rand.Next(1, 11),
                SoldDate = DateTime.Now.AddDays(-rand.Next(11, 51)),
                IsSold = true
            });

            db.Plates.Add(new Plate()
            {
                Name = "In Utero",
                TrackCount = 12,
                BandId = 5, 
                GenreId = 5, 
                PublisherId = rand.Next(1, 13),
                PublishingYear = rand.Next(1992, 1994),
                SelfCoast = 12,
                Price = 22,
                SoldCount = rand.Next(11, 31),
                DeliveryDate = DateTime.Now.AddDays(-rand.Next(51, 70)),
                IsSold = false
            });

            db.Plates.Add(new Plate()
            {
                Name = "Bleach",
                TrackCount = 13,
                BandId = 5, 
                GenreId = 5, 
                PublisherId = rand.Next(1, 13),
                PublishingYear = rand.Next(1989, 1990),
                SelfCoast = 9,
                Price = 18,
                SoldCount = rand.Next(11, 31),
                DeliveryDate = DateTime.Now.AddDays(-rand.Next(51, 70)),
                CustomerId = rand.Next(1, 11),
                SoldDate = DateTime.Now.AddDays(-rand.Next(11, 51)),
                IsSold = true
            });

            db.Plates.Add(new Plate()
            {
                Name = "MTV Unplugged in New York",
                TrackCount = 14,
                BandId = 5, 
                GenreId = 5, 
                PublisherId = rand.Next(1, 13),
                PublishingYear = rand.Next(1993, 1994),
                SelfCoast = 11,
                Price = 21,
                SoldCount = rand.Next(11, 31),
                DeliveryDate = DateTime.Now.AddDays(-rand.Next(51, 70)),
                CustomerId = rand.Next(1, 11),
                SoldDate = DateTime.Now.AddDays(-rand.Next(11, 51)),
                IsSold = true
            });

            db.Plates.Add(new Plate()
            {
                Name = "Incesticide",
                TrackCount = 15,
                BandId = 5, 
                GenreId = 5, 
                PublisherId = rand.Next(1, 13),
                PublishingYear = rand.Next(1992, 1993),
                SelfCoast = 10,
                Price = 19,
                SoldCount = rand.Next(11, 31),
                DeliveryDate = DateTime.Now.AddDays(-rand.Next(51, 70)),
                IsSold = false
            });

            db.Plates.Add(new Plate()
            {
                Name = "Back in Black",
                TrackCount = 10,
                BandId = 6, 
                GenreId = 6, 
                PublisherId = rand.Next(1, 13),
                PublishingYear = rand.Next(1979, 1981),
                SelfCoast = 11,
                Price = 25,
                SoldCount = rand.Next(11, 31),
                DeliveryDate = DateTime.Now.AddDays(-rand.Next(51, 70)),
                CustomerId = rand.Next(1, 11),
                SoldDate = DateTime.Now.AddDays(-rand.Next(11, 51)),
                IsSold = true
            });

            db.Plates.Add(new Plate()
            {
                Name = "Highway to Hell",
                TrackCount = 10,
                BandId = 6, 
                GenreId = 6, 
                PublisherId = rand.Next(1, 13),
                PublishingYear = rand.Next(1979, 1980),
                SelfCoast = 10,
                Price = 23,
                SoldCount = rand.Next(11, 31),
                DeliveryDate = DateTime.Now.AddDays(-rand.Next(51, 70)),
                IsSold = false
            });

            db.Plates.Add(new Plate()
            {
                Name = "Powerage",
                TrackCount = 9,
                BandId = 6, 
                GenreId = 6, 
                PublisherId = rand.Next(1, 13),
                PublishingYear = rand.Next(1978, 1979),
                SelfCoast = 9,
                Price = 21,
                SoldCount = rand.Next(11, 31),
                DeliveryDate = DateTime.Now.AddDays(-rand.Next(51, 70)),
                CustomerId = rand.Next(1, 11),
                SoldDate = DateTime.Now.AddDays(-rand.Next(11, 51)),
                IsSold = true
            });

            db.Plates.Add(new Plate()
            {
                Name = "Dirty Deeds Done Dirt Cheap",
                TrackCount = 9,
                BandId = 6, 
                GenreId = 6,
                PublisherId = rand.Next(1, 13),
                PublishingYear = rand.Next(1976, 1977),
                SelfCoast = 10,
                Price = 22,
                SoldCount = rand.Next(11, 31),
                DeliveryDate = DateTime.Now.AddDays(-rand.Next(51, 70)),
                IsSold = false
            });

            db.Plates.Add(new Plate()
            {
                Name = "Let There Be Rock",
                TrackCount = 8,
                BandId = 6, 
                GenreId = 6, 
                PublisherId = rand.Next(1, 13),
                PublishingYear = rand.Next(1977, 1978),
                SelfCoast = 10,
                Price = 20,
                SoldCount = rand.Next(11, 31),
                DeliveryDate = DateTime.Now.AddDays(-rand.Next(51, 70)),
                CustomerId = rand.Next(1, 11),
                SoldDate = DateTime.Now.AddDays(-rand.Next(11, 51)),
                IsSold = true
            });

            db.Plates.Add(new Plate()
            {
                Name = "Good Kid, M.A.A.D City",
                TrackCount = 12,
                BandId = 7, 
                GenreId = 7, 
                PublisherId = rand.Next(1, 13),
                PublishingYear = rand.Next(2012, 2013),
                SelfCoast = 8,
                Price = 18,
                SoldCount = rand.Next(11, 31),
                DeliveryDate = DateTime.Now.AddDays(-rand.Next(51, 70)),
                IsSold = false
            });

            db.Plates.Add(new Plate()
            {
                Name = "To Pimp a Butterfly",
                TrackCount = 16,
                BandId = 7, 
                GenreId = 7, 
                PublisherId = rand.Next(1, 13),
                PublishingYear = rand.Next(2015, 2016),
                SelfCoast = 9,
                Price = 20,
                SoldCount = rand.Next(11, 31),
                DeliveryDate = DateTime.Now.AddDays(-rand.Next(51, 70)),
                CustomerId = rand.Next(1, 11),
                SoldDate = DateTime.Now.AddDays(-rand.Next(11, 51)),
                IsSold = true
            });

            db.Plates.Add(new Plate()
            {
                Name = "DAMN.",
                TrackCount = 14,
                BandId = 7, 
                GenreId = 7, 
                PublisherId = rand.Next(1, 13),
                PublishingYear = rand.Next(2017, 2018),
                SelfCoast = 10,
                Price = 22,
                SoldCount = rand.Next(11, 31),
                DeliveryDate = DateTime.Now.AddDays(-rand.Next(51, 70)),
                CustomerId = rand.Next(1, 11),
                SoldDate = DateTime.Now.AddDays(-rand.Next(11, 51)),
                IsSold = true
            });

            db.Plates.Add(new Plate()
            {
                Name = "Section.80",
                TrackCount = 16,
                BandId = 7, 
                GenreId = 7, 
                PublisherId = rand.Next(1, 13),
                PublishingYear = rand.Next(2011, 2012),
                SelfCoast = 7,
                Price = 17,
                SoldCount = rand.Next(11, 31),
                DeliveryDate = DateTime.Now.AddDays(-rand.Next(51, 70)),
                IsSold = false
            });

            db.Plates.Add(new Plate()
            {
                Name = "Untitled Unmastered",
                TrackCount = 8,
                BandId = 7, 
                GenreId = 7, 
                PublisherId = rand.Next(1, 13),
                PublishingYear = rand.Next(2016, 2017),
                SelfCoast = 8,
                Price = 19,
                SoldCount = rand.Next(11, 31),
                DeliveryDate = DateTime.Now.AddDays(-rand.Next(51, 70)),
                CustomerId = rand.Next(1, 11),
                SoldDate = DateTime.Now.AddDays(-rand.Next(11, 51)),
                IsSold = true
            });

            db.Plates.Add(new Plate()
            {
                Name = "Discovery",
                TrackCount = 14,
                BandId = 8, 
                GenreId = 8, 
                PublisherId = rand.Next(1, 13),
                PublishingYear = rand.Next(2000, 2002),
                SelfCoast = 10,
                Price = 25,
                DeliveryDate = DateTime.Now.AddDays(-rand.Next(51, 70)),
                SoldCount = rand.Next(11, 31), 
                IsSold = false 
            });

            db.Plates.Add(new Plate()
            {
                Name = "Random Access Memories",
                TrackCount = 13,
                BandId = 8, 
                GenreId = 8, 
                PublisherId = rand.Next(1, 13),
                PublishingYear = rand.Next(2013, 2014),
                SelfCoast = 12,
                Price = 28,
                DeliveryDate = DateTime.Now.AddDays(-rand.Next(51, 70)),
                SoldCount = rand.Next(11, 31), 
                IsSold = false
            });

            db.Plates.Add(new Plate()
            {
                Name = "Homework",
                TrackCount = 16,
                BandId = 8, 
                GenreId = 8, 
                PublisherId = rand.Next(1, 13),
                PublishingYear = rand.Next(1996, 1997),
                SelfCoast = 8,
                Price = 20,
                DeliveryDate = DateTime.Now.AddDays(-rand.Next(51, 70)),
                SoldCount = rand.Next(11, 31),
                CustomerId = rand.Next(1, 11),
                SoldDate = DateTime.Now.AddDays(-rand.Next(11, 51)),
                IsSold = true 
            });

            db.Plates.Add(new Plate()
            {
                Name = "Human After All",
                TrackCount = 10,
                BandId = 8, 
                GenreId = 8, 
                PublisherId = rand.Next(1, 13),
                PublishingYear = rand.Next(2005, 2006),
                SelfCoast = 9,
                Price = 22,
                DeliveryDate = DateTime.Now.AddDays(-rand.Next(51, 70)),
                SoldCount = rand.Next(11, 31),
                CustomerId = rand.Next(1, 11),
                SoldDate = DateTime.Now.AddDays(-rand.Next(11, 51)),
                IsSold = true 
            });

            db.Plates.Add(new Plate()
            {
                Name = "Alive 2007",
                TrackCount = 12,
                BandId = 8, 
                GenreId = 8, 
                PublisherId = rand.Next(1, 13),
                PublishingYear = 2007,
                SelfCoast = 11,
                Price = 24,
                DeliveryDate = DateTime.Now.AddDays(-rand.Next(51, 70)),
                SoldCount = rand.Next(11, 31),
                CustomerId = rand.Next(1, 11),
                SoldDate = DateTime.Now.AddDays(-rand.Next(11, 51)),
                IsSold = true 
            });

            db.Plates.Add(new Plate()
            {
                Name = "Parachutes",
                TrackCount = 10,
                BandId = 9, 
                GenreId = 9, 
                PublisherId = rand.Next(1, 13),
                PublishingYear = rand.Next(2000, 2001),
                SelfCoast = 9,
                Price = 20,
                SoldCount = rand.Next(11, 31),
                DeliveryDate = DateTime.Now.AddDays(-rand.Next(51, 70)),
                CustomerId = rand.Next(1, 11),
                SoldDate = DateTime.Now.AddDays(-rand.Next(11, 51)),
                IsSold = true
            });

            db.Plates.Add(new Plate()
            {
                Name = "A Rush of Blood to the Head",
                TrackCount = 11,
                BandId = 9, 
                GenreId = 9, 
                PublisherId = rand.Next(1, 13),
                PublishingYear = rand.Next(2002, 2003),
                SelfCoast = 10,
                Price = 22,
                SoldCount = rand.Next(11, 31),
                DeliveryDate = DateTime.Now.AddDays(-rand.Next(51, 70)),
                CustomerId = rand.Next(1, 11),
                SoldDate = DateTime.Now.AddDays(-rand.Next(11, 51)),
                IsSold = true
            });

            db.Plates.Add(new Plate()
            {
                Name = "X&Y",
                TrackCount = 13,
                BandId = 9, 
                GenreId = 9, 
                PublisherId = rand.Next(1, 13),
                PublishingYear = rand.Next(2005, 2006),
                SelfCoast = 11,
                Price = 24,
                SoldCount = rand.Next(11, 31),
                DeliveryDate = DateTime.Now.AddDays(-rand.Next(51, 70)),
                IsSold = false
            });

            db.Plates.Add(new Plate()
            {
                Name = "Viva la Vida or Death and All His Friends",
                TrackCount = 10,
                BandId = 9, 
                GenreId = 9, 
                PublisherId = rand.Next(1, 13),
                PublishingYear = rand.Next(2008, 2009),
                SelfCoast = 10,
                Price = 21,
                SoldCount = rand.Next(11, 31),
                DeliveryDate = DateTime.Now.AddDays(-rand.Next(51, 70)),
                IsSold = false
            });

            db.Plates.Add(new Plate()
            {
                Name = "Mylo Xyloto",
                TrackCount = 14,
                BandId = 9, 
                GenreId = 9, 
                PublisherId = rand.Next(1, 13),
                PublishingYear = rand.Next(2011, 2012),
                SelfCoast = 12,
                Price = 25,
                SoldCount = rand.Next(11, 31),
                DeliveryDate = DateTime.Now.AddDays(-rand.Next(51, 70)),
                CustomerId = rand.Next(1, 11),
                SoldDate = DateTime.Now.AddDays(-rand.Next(11, 51)),
                IsSold = true
            });

            db.Plates.Add(new Plate()
            {
                Name = "Sticky Fingers",
                TrackCount = 10,
                BandId = 10, 
                GenreId = 10, 
                PublisherId = rand.Next(1, 13),
                PublishingYear = rand.Next(1970, 1971),
                SelfCoast = 11,
                Price = 25,
                SoldCount = rand.Next(11, 31),
                DeliveryDate = DateTime.Now.AddDays(-rand.Next(51, 70)),
                IsSold = false
            });

            db.Plates.Add(new Plate()
            {
                Name = "Let It Bleed",
                TrackCount = 9,
                BandId = 10, 
                GenreId = 10, 
                PublisherId = rand.Next(1, 13),
                PublishingYear = rand.Next(1969, 1970),
                SelfCoast = 10,
                Price = 22,
                SoldCount = rand.Next(11, 31),
                DeliveryDate = DateTime.Now.AddDays(-rand.Next(51, 70)),
                IsSold = false
            });

            db.Plates.Add(new Plate()
            {
                Name = "Beggars Banquet",
                TrackCount = 10,
                BandId = 10, 
                GenreId = 10, 
                PublisherId = rand.Next(1, 13),
                PublishingYear = rand.Next(1968, 1969),
                SelfCoast = 10,
                Price = 23,
                SoldCount = rand.Next(11, 31),
                DeliveryDate = DateTime.Now.AddDays(-rand.Next(51, 70)),
                CustomerId = rand.Next(1, 11),
                SoldDate = DateTime.Now.AddDays(-rand.Next(11, 51)),
                IsSold = true
            });

            db.Plates.Add(new Plate()
            {
                Name = "Aftermath",
                TrackCount = 14,
                BandId = 10, 
                GenreId = 10, 
                PublisherId = rand.Next(1, 13),
                PublishingYear = rand.Next(1966, 1967),
                SelfCoast = 9,
                Price = 20,
                SoldCount = rand.Next(11, 31),
                DeliveryDate = DateTime.Now.AddDays(-rand.Next(51, 70)),
                CustomerId = rand.Next(1, 11),
                SoldDate = DateTime.Now.AddDays(-rand.Next(11, 51)),
                IsSold = true
            });

            db.Plates.Add(new Plate()
            {
                Name = "Some Girls",
                TrackCount = 12,
                BandId = 10, 
                GenreId = 10, 
                PublisherId = rand.Next(1, 13),
                PublishingYear = rand.Next(1977, 1978),
                SelfCoast = 11,
                Price = 24,
                SoldCount = rand.Next(11, 31),
                DeliveryDate = DateTime.Now.AddDays(-rand.Next(51, 70)),
                CustomerId = rand.Next(1, 11),
                SoldDate = DateTime.Now.AddDays(-rand.Next(11, 51)),
                IsSold = true
            });

            db.Plates.AddRange(plates);
            db.SaveChanges();
        }

    };
        
}
