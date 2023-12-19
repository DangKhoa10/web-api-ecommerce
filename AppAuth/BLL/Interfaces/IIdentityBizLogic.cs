using AppAuth.Model;
using AppEntity.Model;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppAuth.BLL.Interfaces
{
    public interface IIdentityBizLogic
    {
        public Task<string> Login(UserModel dto);
        public Task<IdentityResult> SignUp(UserModel dto);
    }
}
