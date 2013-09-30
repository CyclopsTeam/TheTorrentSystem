namespace TorrentSite.Data.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using TorrentSite.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<TorrentSite.Data.DataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(TorrentSite.Data.DataContext context)
        {
            this.PopulateDb(context);
        }

        private void PopulateDb(DataContext context)
        {
            var catalogues = new List<Catalogue>
            {
                new Catalogue { Name = "Movies",
                    Categories = new HashSet<Category>
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
                    } },
                new Catalogue { Name = "Games",
                    Categories = new HashSet<Category>
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
                    } },
                new Catalogue { Name = "Music",
                    Categories = new HashSet<Category>{  } },
                new Catalogue { Name = "Programs",
                    Categories = new HashSet<Category>{  } },
            };

            foreach (var catalogue in catalogues)
            {
                context.Catalogues.AddOrUpdate(catalogue);
            }
        }
    }
}