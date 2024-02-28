using BaiTapApi.Entities;
using BaiTapApi.iServices;
using BaiTapApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BaiTapApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly iUserService _userService;
        public UserController()
        {
            _userService = new UserService();
        }
        [HttpGet]
        public IActionResult GetUsers()
        {
            var DsUser = _userService.LayUsers();
            return Ok(DsUser);
        }
        [HttpPost("ThemUser")]
        public IActionResult ThemUser([FromBody] User user)
        {
            var ret = _userService.TaoUser(user);
            if(ret == Helper.ErrorHelper.ThanhCong)
            {
                return Ok(Helper.ErrorHelperMessage.GetErrorMessage(Helper.ErrorHelper.ThanhCong));
            } else
            {
                return BadRequest(Helper.ErrorHelperMessage.GetErrorMessage(Helper.ErrorHelper.ThatBai));
            }
        }
        [HttpPut("SuaUser")]
        public IActionResult SuaUser([FromBody] User user)
        {
            var ret = _userService.SuaUser(user);
            if (ret == Helper.ErrorHelper.ThanhCong)
            {
                return Ok(Helper.ErrorHelperMessage.GetErrorMessage(Helper.ErrorHelper.ThanhCong));
            }
            else
            {
                return BadRequest(Helper.ErrorHelperMessage.GetErrorMessage(Helper.ErrorHelper.ThatBai));
            }
        }
        [HttpDelete("XoaUser")]
        public IActionResult XoaUser([FromQuery] int userId)
        {
            var ret = _userService.XoaUser(userId);
            if (ret == Helper.ErrorHelper.ThanhCong)
            {
                return Ok(Helper.ErrorHelperMessage.GetErrorMessage(Helper.ErrorHelper.ThanhCong));
            }
            else
            {
                return BadRequest(Helper.ErrorHelperMessage.GetErrorMessage(Helper.ErrorHelper.ThatBai));
            }
        }
    }
}
