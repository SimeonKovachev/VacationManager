using Microsoft.AspNet.Identity.EntityFramework;
using System;
using VacationManager.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VacationManager.Areas.Dashboard.ViewModels
{
        public class UsersListingModel
        {
            public IEnumerable<VacationUser> Users { get; set; }

            public string RoleID { get; set; }
            public IEnumerable<IdentityRole> Roles { get; set; }
        }

        public class UserActionModel
        {
            public string ID { get; set; }
            public string Email { get; set; }
            public string Username { get; set; }

        }
        public class UserRolesModel
        {
            public string UserID { get; set; }

            public IEnumerable<IdentityRole> UserRoles { get; set; }

            public IEnumerable<IdentityRole> Roles { get; set; }
        }

    
}