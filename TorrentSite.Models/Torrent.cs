using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TorrentSite.Models
{
    public class Torrent
    {
        public Torrent()
        {
            this.Category = new HashSet<Category>();
            this.Comments = new HashSet<Comment>();
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public string FileLink { get; set; }

        public string Description { get; set; }

        public byte[] Image { get; set; }

        public DateTime DateCreated { get; set; }

        public int Rating { get; set; }

        public long Size { get; set; }

        public int TimesDownloaded { get; set; }

        public int Seeders { get; set; }

        public int Leechers { get; set; }

        public int CatalogueId { get; set; }

        //public virtual Catalogue Catalog { get; set; }
        public virtual ICollection<Category> Category { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
    }
}
