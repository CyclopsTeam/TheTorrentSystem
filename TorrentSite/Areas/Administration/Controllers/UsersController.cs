using Kendo.Mvc.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TorrentSite.Areas.ViewModels;
using TorrentSite.Controllers;
using TorrentSite.Data;
using Kendo.Mvc.Extensions;
using Microsoft.AspNet.Identity.EntityFramework;

namespace TorrentSite.Areas.Administration.Controllers
{
    public class UsersController : BaseController
    {
        public UsersController(IUowData data)
            : base(data)
        {
        }
        public ActionResult Index()
        {
            IList<SelectListItem> listsRoles =( from role in Data.Roles.All().ToList()
                        select new SelectListItem()
                        {
                            Text = role.Name,
                            Value = role.Id
                        }).ToList();

            ViewData["roles"] = listsRoles;


            return View();
        }

        public JsonResult UpdateUser([DataSourceRequest] DataSourceRequest request, UserViewModel user)
        {
            var existingUser = Data.Users.All().FirstOrDefault(u => u.Id == user.Id);

            if (user != null && ModelState.IsValid)
            {
                existingUser.UserName = user.Username;
                if (user.RoleForAddingId!=null)
                {
                    UserRole roleForAdding = new UserRole()
                    {
                        RoleId=user.RoleForAddingId,
                        UserId=user.Id
                    };

                    var roleForCheck = Data.UserRoles.All()
                        .FirstOrDefault(r => r.UserId == roleForAdding.UserId && r.RoleId == roleForAdding.RoleId);

                    if (roleForCheck==null)
                    {
                        existingUser.Roles.Add(roleForAdding);
                    }
                    
                }
                if (user.RoleForRemovingId != null)
                {
                    var roleForRemoving = Data.UserRoles.All()
                        .FirstOrDefault(r => r.UserId == user.Id && r.RoleId == user.RoleForRemovingId);

                    if (roleForRemoving!=null)
                    {
                        existingUser.Roles.Remove(roleForRemoving);
                    }
                   
                }

                Data.SaveChanges();
            }

            return Json((new[] { user }.ToDataSourceResult(request, ModelState)), JsonRequestBehavior.AllowGet);
        }


        public JsonResult ReadUsers([DataSourceRequest]DataSourceRequest request)
        {

            var users = Data.Users.All().Select(UserViewModel.FromUser).ToList();

            foreach (var user in users)
            {
                user.RolesAsString = string.Join(", ", user.Roles);
            }
           
            return Json(users.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        public JsonResult DeleteUser([DataSourceRequest] DataSourceRequest request, UserViewModel user)
        {
            var existingUser = Data.Users.All().FirstOrDefault(u => u.Id == user.Id);

            Data.Users.Delete(existingUser);
            Data.SaveChanges();

            return Json(new[] { user }, JsonRequestBehavior.AllowGet);
        }

    }
}