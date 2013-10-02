using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using TorrentSite.Models;

namespace TorrentSite.Areas.ViewModels
{
    public class CategoryViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The field is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Category name must be between {2} and {1} symbols")]
        public string Name { get; set; }

        [Required]
        public string Catalog { get; set; }

        public static Expression<Func<Category, CategoryViewModel>> FromCategory
        {
            get
            {
                return category => new CategoryViewModel
                {
                    Id = category.Id,
                    Name = category.Name,
                    Catalog = category.Catalogue.Name
                };
            }
        }
    }
}