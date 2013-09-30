using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using TorrentSite.Models;

namespace TorrentSite.ViewModels
{
    public class CatalogueViewModel
    {
        public static Expression<Func<Catalogue, CatalogueViewModel>> FromCatalogue
        {
            get
            {
                return c => new CatalogueViewModel
                {
                    Id = c.Id,
                    Name = c.Name
                };
            }
        }

        public int Id { get; set; }

        public string Name { get; set; }
    }
}