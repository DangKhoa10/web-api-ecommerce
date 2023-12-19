using AppAuth.DAL.Interfaces;
using AppAuth.Data;
using AppAuth.Model;
using AppEntity.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AppAuth.DAL.Implements
{
    public class IdentityRepository : IIdentityRepository
    {
        private readonly UserManager<UserDTO> _userManager;
        private readonly SignInManager<UserDTO> _signInManager;
        private readonly IConfiguration _configuration;
        private readonly RoleManager<RoleDTO> _roleManager;

        public IdentityRepository(UserManager<UserDTO> userManager, SignInManager<UserDTO> signInManager , IConfiguration configuration, RoleManager<RoleDTO> roleManager) {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
            _roleManager = roleManager;
        }
        public async Task<string> Login(UserModel dto)
        {
            var user = await _userManager.FindByEmailAsync(dto.Email);
            if(user == null)
            {
                return string.Empty;
            }
            var pwValid = await _userManager.CheckPasswordAsync(user , dto.Password);
            if (!pwValid)
            {
                return string.Empty;
            }
            var result = await _signInManager.PasswordSignInAsync(dto.Email , dto.Password, false , false);
            if (!result.Succeeded)
            {
                return string.Empty;
            }

            var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, dto.Email),
                new Claim(Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),

            };

            var userRoles = await _userManager.GetRolesAsync(user);
            foreach(var role in userRoles)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, role.ToString()));
            }

            var authenKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:SecretKey"]));
            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddMinutes(50),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authenKey , SecurityAlgorithms.HmacSha512Signature)
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<IdentityResult> SignUp(UserModel dto)
        {
            var user = new UserDTO
            {
                Email = dto.Email,
                UserName = dto.Email,
            };

            var result =  await _userManager.CreateAsync(user, dto.Password);
            if(result.Succeeded)
            {
                if (!await _roleManager.RoleExistsAsync(RoleModel.Customer))
                {
                    await _roleManager.CreateAsync(new RoleDTO(RoleModel.Customer));
                }
                await _userManager.AddToRoleAsync(user , RoleModel.Customer);
            }
            return result;
        }
    }
}
