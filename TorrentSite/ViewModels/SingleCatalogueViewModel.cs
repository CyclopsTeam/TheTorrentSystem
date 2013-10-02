using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using TorrentSite.Models;

namespace TorrentSite.ViewModels
{
    public class SingleCatalogueViewModel
    {
        public static Expression<Func<Catalogue, SingleCatalogueViewModel>> fromCatalogue
        {
            get
            {
                return c => new SingleCatalogueViewModel
                {
                    Id= c.Id,
                    Name = c.Name,
                    Image = c.Image,
                    Categories = c.Categories.AsQueryable()
                    .Select(CategoryViewModel.FromCategory)
                    .ToList()
                };
            }
        }


        public int Id { get; set; }

        public string Name { get; set; }

        public byte[] Image { get; set; }

        public List<CategoryViewModel> Categories { get; set; }

        public List<TorrentViewModel> Torrents { get; set; } 
    }
}