using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using TorrentSite.Models;

namespace TorrentSite.ViewModels
{
    public class CategoryViewModel
    {
        public static Expression<Func<Category, CategoryViewModel>> FromCategory
        {
            get
            {
                return c => new CategoryViewModel
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