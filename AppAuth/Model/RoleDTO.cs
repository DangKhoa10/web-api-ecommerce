using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppAuth.Model
{
    public class RoleDTO : IdentityRole
    {
        public RoleDTO() { }
        public RoleDTO(string roleName) : base(roleName)
        {
        }
    }
}
