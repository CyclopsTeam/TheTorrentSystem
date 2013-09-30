using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TorrentSite.Models;

namespace TorrentSite.Data
{
    public class DataContext : IdentityDbContextWithCustomUser<ApplicationUser>
    {
        public IDbSet<Torrent> Torrents { get; set; }

        public IDbSet<Category> Categories { get; set; }

        public IDbSet<Catalogue> Catalogues { get; set; }

        public IDbSet<Comment> Comments { get; set; }
    }
}
