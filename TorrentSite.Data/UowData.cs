namespace TorrentSite.Data
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Collections.Generic;
    using TorrentSite.Models;

    public class UowData : IUowData
    {
        private readonly DataContext context;
        private readonly Dictionary<Type, object> repositories = new Dictionary<Type, object>();

        public UowData()
            : this(new DataContext())
        {
        }

        public UowData(DataContext context)
        {
            this.context = context;
        }

        public IRepository<Catalogue> Catalogues
        {
            get
            {
                return this.GetRepository<Catalogue>();
            }
        }

        public IRepository<Category> Categories
        {
            get
            {
                return this.GetRepository<Category>();
            }
        }
        public IRepository<Comment> Comments
        {
            get
            {
                return this.GetRepository<Comment>();
            }
        }
        public IRepository<Torrent> Torrents
        {
            get
            {
                return this.GetRepository<Torrent>();
            }
        }
                
        public IRepository<ApplicationUser> Users
        {
            get
            {
                return this.GetRepository<ApplicationUser>();
            }
        }

        public IRepository<Role> Roles
        {
            get
            {
                return this.GetRepository<Role>();
            }
        }

        public IRepository<UserRole> UserRoles
        {
            get
            {
                return this.GetRepository<UserRole>();
            }
        }

        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }

        public void Dispose()
        {
            if (this.context != null)
            {
                this.context.Dispose();
            }
        }

        private IRepository<T> GetRepository<T>() where T : class
        {
            if (!this.repositories.ContainsKey(typeof(T)))
            {
                var type = typeof(GenericRepository<T>);

                this.repositories.Add(typeof(T), Activator.CreateInstance(type, this.context));
            }

            return (IRepository<T>)this.repositories[typeof(T)];
        }
    }
}
