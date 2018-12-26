using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZP50.Web.Areas.Administration.Models
{
    public class UserRolesModel
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public RoleSelectionModel[] Roles { get; set; }
    }

    public class RoleSelectionModel {
        public bool Selected { get; set; }
        public string RoleName { get; set; }

    }
}