﻿using AppAuth.Model;
using AppEntity.Model;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppAuth.DAL.Interfaces
{
    public interface IIdentityRepository
    {
        public Task<string> Login(UserModel dto);
        public Task<IdentityResult> SignUp(UserModel dto);
    }
}
