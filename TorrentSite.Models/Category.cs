using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TorrentSite.Models
{
    public class Category
    {
        public Category()
        {
            this.Torrent = new HashSet<Torrent>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public int CatalogueId { get; set; }

        public virtual Catalogue Catalogue { get; set; }

        public virtual ICollection<Torrent> Torrent { get; set; }

        public bool isSelected { get; set; } 
    }
}
