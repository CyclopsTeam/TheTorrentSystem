using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using TorrentSite.Models;

namespace TorrentSite.Areas.ViewModels
{
    public class UserViewModel
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public IEnumerable<string> Roles { get; set; }

        public string RoleForAddingId { get; set; }
        public string RoleForRemovingId { get; set; }


        public static Expression<Func<ApplicationUser, UserViewModel>> FromUser
        {
            get
            {
                return user => new UserViewModel
                {
                    Id = user.Id,
                    Username=user.UserName,
                    Roles= user.Roles.Select(u=>u.Role.Name).ToList()
                };
            }
        }
    }
}