using BaiTapApi.Entities;
using BaiTapApi.iServices;
using BaiTapApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BaiTapApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        public  AccountController()
        {
            _accountService = new AccountService();
        }
        [HttpGet]
        public IActionResult GetAccount() { 
            var dsAccount = _accountService.GetAccounts();
            return Ok(dsAccount);
        }
        [HttpPut("ChinhSuaAccount")]
        public IActionResult ChinhSuaAccount([FromBody] Account account)
        {
            var ret = _accountService.ChinhSuaThongTinTaiKhoan(account);
            if(ret == Helper.ErrorHelper.ThanhCong)
            {
                return Ok(Helper.ErrorHelperMessage.GetErrorMessage(Helper.ErrorHelper.ThanhCong));
            }
            else
            {
                return BadRequest(Helper.ErrorHelperMessage.GetErrorMessage(Helper.ErrorHelper.ThatBai));
            }
        }
        [HttpPost("ThemAccount")]
        public IActionResult ThemAccount([FromBody] Account account)
        {
            var ret = _accountService.TaoTaiKhoan(account);
            if(ret == Helper.ErrorHelper.ThanhCong)
            {
                return Ok(ret);
            }
            else
            {
                return BadRequest(ret);
            }
        }
        [HttpDelete("XoaAccount")]
        public IActionResult DeleteAccount([FromQuery] int idAccount)
        {
            var ret = _accountService.XoaTaiKhoan(idAccount);
            if(ret == Helper.ErrorHelper.ThanhCong)
            {
                return Ok(Helper.ErrorHelperMessage.GetErrorMessage(Helper.ErrorHelper.ThanhCong));
            }
            else
            {
                return BadRequest(Helper.ErrorHelperMessage.GetErrorMessage(Helper.ErrorHelper.ThatBai));
            }
        }
        [HttpPost("DangNhap")]
        public IActionResult DangNhap([FromBody] DangNhapModel dangNhapModel)
        {
            var ret = _accountService.DangNhap(dangNhapModel);
            if(ret == Helper.ErrorHelper.ThanhCong)
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
