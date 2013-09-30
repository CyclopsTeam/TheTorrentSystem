namespace TorrentSite.Data
{
    using System;
    using TorrentSite.Models;


    public interface IUowData : IDisposable
    {
        IRepository<Catalogue> Catalogues { get; }

        IRepository<Category> Categories { get; }

        IRepository<Comment> Comments { get; }

        IRepository<Torrent> Torrents { get; }

        IRepository<ApplicationUser> Users { get; }

        int SaveChanges();
    }
}
