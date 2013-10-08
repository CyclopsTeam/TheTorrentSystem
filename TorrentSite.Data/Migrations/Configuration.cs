namespace TorrentSite.Data.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using TorrentSite.Models;

    public sealed class Configuration : DbMigrationsConfiguration<TorrentSite.Data.DataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(DataContext context)
        {
            if (context.Torrents.Count() > 0)
            {
                return;
            }

            this.PopulateDb(context);
        }

        private void PopulateDb(DataContext context)
        {
            Random rand = new Random();

            var moviesCategories = new List<Category>
                {
                    new Category{ Name = "Action",isSelected=false},
                    new Category{ Name = "Animation",isSelected = false},
                    new Category{ Name = "Anime", isSelected =false},
                    new Category{ Name = "Asian",isSelected =false},
                    new Category{ Name = "Biographic",isSelected =false},
                    new Category{ Name = "Bulgarian",isSelected =false},
                    new Category{ Name = "War",isSelected =false},
                    new Category{ Name = "Documentary",isSelected =false},
                    new Category{ Name = "Drama",isSelected =false},
                    new Category{ Name = "European",isSelected =false},
                    new Category{ Name = "Erotic",isSelected =false},
                    new Category{ Name = "Hindi",isSelected =false},
                    new Category{ Name = "History",isSelected =false},
                    new Category{ Name = "Comedy",isSelected =false},
                    new Category{ Name = "Concert",isSelected =false},
                    new Category{ Name = "Crime",isSelected =false},
                    new Category{ Name = "Mystery",isSelected =false},
                    new Category{ Name = "Musical",isSelected =false},
                    new Category{ Name = "Parody",isSelected =false},
                    new Category{ Name = "Adventure",isSelected =false},
                    new Category{ Name = "Psycho",isSelected =false},
                    new Category{ Name = "Romance",isSelected =false},
                    new Category{ Name = "Family",isSelected =false},
                    new Category{ Name = "Sport",isSelected =false},
                    new Category{ Name = "Thriller",isSelected =false},
                    new Category{ Name = "Western",isSelected =false},
                    new Category{ Name = "Horror",isSelected =false},
                    new Category{ Name = "Sci Fi",isSelected =false},
                    new Category{ Name = "Fantasy",isSelected =false}
                };
            var moviesCatalogue = new Catalogue
            {
                Name = "Movies",
                Categories = moviesCategories,                    
            };
            context.Catalogues.Add(moviesCatalogue);

            for (int i = 0; i < 50; i++)
            {
                var torrent = new Torrent()
                {
                    Title = "Random Movie #" + i,
                    CatalogueId = 1,
                    DateCreated = DateTime.Now,
                    Description = "Some random movie",
                    FileLink = "someUrl",
                    Leechers = rand.Next(0, 10),
                    Seeders = rand.Next(1, 20),
                    Rating = rand.Next(1, 10),
                    Size = rand.Next(100, 500),
                    TimesDownloaded = rand.Next(0, 1000),
                };
                var categoriesCount = rand.Next(1, 5);
                for (int j = 0; j < categoriesCount; j++)
                {
                    torrent.Categories.Add(moviesCategories[rand.Next(0, moviesCategories.Count())]);
                }

                context.Torrents.Add(torrent);
            }

            var gamesCategories = new List<Category>()
                { 
                    new Category{ Name = "3D Action",isSelected =false},
                    new Category{ Name = "FPS",isSelected =false},
                    new Category{ Name = "MMORPG",isSelected =false},
                    new Category{ Name = "RPG",isSelected =false},
                    new Category{ Name = "Fighting",isSelected =false},
                    new Category{ Name = "Action",isSelected =false},
                    new Category{ Name = "Fun",isSelected =false},
                    new Category{ Name = "Quest",isSelected =false},
                    new Category{ Name = "Logical",isSelected =false},
                    new Category{ Name = "Manager",isSelected =false},
                    new Category{ Name = "Adventure",isSelected =false},
                    new Category{ Name = "Simulatior",isSelected =false},
                    new Category{ Name = "Sport",isSelected =false},
                    new Category{ Name = "Strategy",isSelected =false},
                    new Category{ Name = "Racing",isSelected =false},
                    new Category{ Name = "Tactical",isSelected =false},
                    new Category{ Name = "Psycho",isSelected =false},
                    new Category{ Name = "Hentai",isSelected =false}
                };
            var gamesCatalogue = new Catalogue
            {
                Name = "Games",
                Categories = gamesCategories
            };
            context.Catalogues.Add(gamesCatalogue);

            for (int i = 0; i < 50; i++)
            {
                var torrent = new Torrent()
                {
                    Title = "Random Game #" + i,
                    CatalogueId = 2,
                    DateCreated = DateTime.Now,
                    Description = "Some random game",
                    FileLink = "someUrl",
                    Leechers = rand.Next(0, 10),
                    Seeders = rand.Next(1, 20),
                    Rating = rand.Next(1, 10),
                    Size = rand.Next(100, 500),
                    TimesDownloaded = rand.Next(0, 1000),
                };
                var categoriesCount = rand.Next(1, 5);
                for (int j = 0; j < categoriesCount; j++)
                {
                    torrent.Categories.Add(gamesCategories[rand.Next(0, gamesCategories.Count())]);
                }

                context.Torrents.Add(torrent);
            }

            var musicCatalogue = new Catalogue
            {
                Name = "Music",
                Categories = new HashSet<Category> { }
            };
            context.Catalogues.Add(musicCatalogue);

            var programsCatalogue = new Catalogue
            {
                Name = "Programs",
                Categories = new HashSet<Category> { }
            };
            context.Catalogues.Add(programsCatalogue);

            context.SaveChanges();
        }
    }
}