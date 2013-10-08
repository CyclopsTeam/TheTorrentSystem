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
                    new Category{ Name = "Action"},
                    new Category{ Name = "Animation"},
                    new Category{ Name = "Anime"},
                    new Category{ Name = "Asian"},
                    new Category{ Name = "Biographic"},
                    new Category{ Name = "Bulgarian"},
                    new Category{ Name = "War"},
                    new Category{ Name = "Documentary"},
                    new Category{ Name = "Drama"},
                    new Category{ Name = "European"},
                    new Category{ Name = "Erotic"},
                    new Category{ Name = "Hindi"},
                    new Category{ Name = "History"},
                    new Category{ Name = "Comedy"},
                    new Category{ Name = "Concert"},
                    new Category{ Name = "Crime"},
                    new Category{ Name = "Mystery"},
                    new Category{ Name = "Musical"},
                    new Category{ Name = "Parody"},
                    new Category{ Name = "Adventure"},
                    new Category{ Name = "Psycho"},
                    new Category{ Name = "Romance"},
                    new Category{ Name = "Family"},
                    new Category{ Name = "Sport"},
                    new Category{ Name = "Thriller"},
                    new Category{ Name = "Western"},
                    new Category{ Name = "Horror"},
                    new Category{ Name = "Sci Fi"},
                    new Category{ Name = "Fantasy"}
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
                    new Category{ Name = "3D Action"},
                    new Category{ Name = "FPS"},
                    new Category{ Name = "MMORPG"},
                    new Category{ Name = "RPG"},
                    new Category{ Name = "Fighting"},
                    new Category{ Name = "Action"},
                    new Category{ Name = "Fun"},
                    new Category{ Name = "Quest"},
                    new Category{ Name = "Logical"},
                    new Category{ Name = "Manager"},
                    new Category{ Name = "Adventure"},
                    new Category{ Name = "Simulatior"},
                    new Category{ Name = "Sport"},
                    new Category{ Name = "Strategy"},
                    new Category{ Name = "Racing"},
                    new Category{ Name = "Tactical"},
                    new Category{ Name = "Psycho"},
                    new Category{ Name = "Hentai"}
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