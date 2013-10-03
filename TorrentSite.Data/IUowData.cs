namespace TorrentSite.Data
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using TorrentSite.Models;


    public interface IUowData : IDisposable
    {
        IRepository<Catalogue> Catalogues { get; }

        IRepository<Category> Categories { get; }

        IRepository<Comment> Comments { get; }

        IRepository<Torrent> Torrents { get; }

        IRepository<ApplicationUser> Users { get; }

        IRepository<Role> Roles { get; }

        IRepository<UserRole> UserRoles { get; }
        int SaveChanges();
    }
}
