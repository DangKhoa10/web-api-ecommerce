﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppAuth.Model
{
    public class UserDTO : IdentityUser
    {

        public string? FirstName { get; set; }
        public string? LastName { get; set; }
    }
}
