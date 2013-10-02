using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TorrentSite.ViewModels
{
    public class CataloguesCategoriesViewModel
    {
        public IEnumerable<Kendo.Mvc.UI.TreeViewItemModel> TreeView { get; set; }

        public IEnumerable<CategoryViewModel> Categories { get; set; } 
    }
}