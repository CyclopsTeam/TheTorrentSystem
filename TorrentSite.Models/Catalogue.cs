using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TorrentSite.Models
{
    public class Catalogue
    {
        public Catalogue()
        {
            this.Categories = new HashSet<Category>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public byte[] Image { get; set; }

        public virtual ICollection<Category> Categories { get; set; }
    }
}
