using AppAuth.BLL.Interfaces;
using AppAuth.DAL.Interfaces;
using AppAuth.Model;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppAuth.BLL.Implements
{
    public class IdentityBizLogic : IIdentityBizLogic
    {
        private readonly IIdentityRepository _identityRepository;

        public IdentityBizLogic(IIdentityRepository identityRepository)
        {
            _identityRepository = identityRepository;
        }

        public async Task<string> Login(UserDTO dto)
        {
            return await _identityRepository.Login(dto);
        }

        public async Task<IdentityResult> SignUp(UserDTO dto)
        {
            return await _identityRepository.SignUp(dto);
        }
    }
}
