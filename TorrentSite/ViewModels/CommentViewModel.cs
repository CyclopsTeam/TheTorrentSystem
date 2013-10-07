using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using TorrentSite.Models;

namespace TorrentSite.ViewModels
{
    public class CommentViewModel
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public string CommentedBy { get; set; }

        [DisplayFormat(DataFormatString="{0:dd.MM.yyyy}")]
        public DateTime CommentedOn { get; set; }

        public static Expression<Func<Comment, CommentViewModel>> FromComment 
        {
            get 
            {
                return c => new CommentViewModel()
                {
                    Content = c.Content,
                    CommentedOn = c.DateCreated,
                    CommentedBy = c.Creator.UserName
                };
            }
        }
    }
}