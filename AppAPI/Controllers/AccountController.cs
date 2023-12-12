using AppAuth.BLL.Interfaces;
using AppAuth.Model;
using AppBLL.Implements;
using AppBLL.Interfaces;
using AppEntity.DTO;
using Microsoft.AspNetCore.Mvc;

namespace AppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IIdentityBizLogic _identityBizLogic;

        public AccountController(IIdentityBizLogic identityBizLogic)
        {
            _identityBizLogic = identityBizLogic;
        }


        [HttpPost("sign-up")]
        public async Task<ActionResult> SignUp(UserDTO model)
        {
            try
            {
                var dt = await _identityBizLogic.SignUp(model);
                if (dt.Succeeded)
                {
                    return Ok(dt.Succeeded);
                }
                return Unauthorized();
            }
            catch(Exception ex)
            {
                return BadRequest();
            }
        }


        [HttpPost("log-in")]
        public async Task<ActionResult> Login(UserDTO model)
        {
            try
            {
                var dt = await _identityBizLogic.Login(model);
                if (string.IsNullOrEmpty(dt))
                {
                    return Unauthorized();
                }
                return Ok(dt);
            }
            catch
            {
                return BadRequest();
            }
        }

    }
}
