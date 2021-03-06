﻿using System;
using System.Collections;
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
                    Categories = t.Categories.Select(c => new CategoryViewModel() { Id = c.Id, Name = c.Name} ),
                    Comments = t.Comments.Select(x => new CommentViewModel() { Content = x.Content, CommentedBy = x.Creator.UserName, CommentedOn = x.DateCreated })
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

        public IEnumerable<CategoryViewModel> Categories { get; set; }

        public IEnumerable<CommentViewModel> Comments { get; set; }
    }
}