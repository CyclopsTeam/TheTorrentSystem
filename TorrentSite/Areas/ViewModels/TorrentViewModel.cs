using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using TorrentSite.Models;

namespace TorrentSite.Areas.ViewModels
{
    public class TorrentViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage="Title is required!")]
        [MaxLength(100,ErrorMessage="Title max lenght must be 100 symbols!")]
        public string Title { get; set; }

        [Required(ErrorMessage = "FileLinkt is required!")]
        [MaxLength(150, ErrorMessage = "FileLinkt max lenght must be 150 symbols!")]
        public string FileLink { get; set; }

        public string Description { get; set; }

        public byte[] Image { get; set; }

        public DateTime DateCreated { get; set; }

        public int Rating { get; set; }

        public long Size { get; set; }

        public int TimesDownloaded { get; set; }

        public int Seeders { get; set; }

        public int Leechers { get; set; }

        public string CatalogueName { get; set; }
        public int CatalogueId { get; set; }

        public string CategoryToAdd { get; set; }

        public static Expression<Func<Torrent, TorrentViewModel>> FromTorrent
        {
            get
            {
                return torrent => new TorrentViewModel
                {
                    Id = torrent.Id,
                    DateCreated = torrent.DateCreated,
                    Description = torrent.Description,
                    FileLink = torrent.FileLink,
                    Image = torrent.Image,
                    Leechers = torrent.Leechers,
                    Rating = torrent.Rating,
                    Seeders = torrent.Seeders,
                    Size = torrent.Size,
                    TimesDownloaded = torrent.TimesDownloaded,
                    Title = torrent.Title,
                    CatalogueId = torrent.CatalogueId,
                    //CatalogueName=torrent.Catalog.Name

                };
            }
        }
    }
}