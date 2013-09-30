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
                new Catalogue { Name = "Movies" },
                new Catalogue { Name = "Games" },
                new Catalogue { Name = "Music" },
                new Catalogue { Name = "Programs" },
            };

            foreach (var catalogue in catalogues)
            {
                context.Catalogues.AddOrUpdate(catalogue);
            }
        }
    }
}
