using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using TorrentSite.Models;

namespace TorrentSite.ViewModels
{
    public class TorrentViewModel
    {
        public static Expression<Func<Torrent, TorrentViewModel>> FromTorrent
        {
            // TODO: Clean unused data.

            get
            {
                return t => new TorrentViewModel
                {
                    Id = t.Id,
                    Title = t.Title,
                    FileLink = t.FileLink,
                    Description = t.Description,
                    Image = t.Image,
                    DateCreated = t.DateCreated,
                    Rating = t.Rating,
                    Size = t.Size,
                    TimesDownloaded = t.TimesDownloaded,
                    Seeders = t.Seeders,
                    Leechers = t.Leechers,
                    CatalogueId = t.CatalogueId,
                    Category = t.Categories,
                    Comments = t.Comments
                };
            }
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

        public ICollection<Category> Category { get; set; }

        public ICollection<Comment> Comments { get; set; }
    }
}