using BaiTapApi.Entities;
using BaiTapApi.Helper;
using BaiTapApi.iServices;
using BaiTapApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BaiTapApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly iProductService _productService;
        public ProductController()
        {
            _productService = new ProductService();
        }
        [HttpGet]
        public IActionResult GetProduct() {
            var ret = _productService.LayDanhSachProducts();
            return Ok(ret);
        }
        [HttpPost("ThemProduct")]
        public IActionResult ThemProduct([FromBody] Product product) { 
            var ret = _productService.ThemProduct(product);
            if(ret == Helper.ErrorHelper.ThanhCong)
            {
                return Ok(Helper.ErrorHelperMessage.GetErrorMessage(Helper.ErrorHelper.ThanhCong));
            }
            else
            {
                return BadRequest(Helper.ErrorHelperMessage.GetErrorMessage(Helper.ErrorHelper.ThatBai));
            }
        }
        [HttpGet("{keyword}")]
        public IActionResult TimKiemProduct(string keyword, [FromQuery]Pagination pagination = null) { 
            var ret = _productService.TimKiemProducts(keyword);
            var Products  = PageResult<Product>.ToPagedResult(pagination ,ret).AsEnumerable();
            pagination.totalCount= ret.Count();
            var res = new PageResult<Product>(pagination,Products);
            return Ok(res);
        }
        [HttpPut("SuaProduct")]
        public IActionResult SuaProduct([FromBody] Product product)
        {
            var ret = _productService.SuaProduct(product);
            if (ret == Helper.ErrorHelper.ThanhCong)
            {
                return Ok(Helper.ErrorHelperMessage.GetErrorMessage(Helper.ErrorHelper.ThanhCong));
            }
            else
            {
                return BadRequest(Helper.ErrorHelperMessage.GetErrorMessage(Helper.ErrorHelper.ThatBai));
            }
        }
        [HttpDelete("XoaProduct")]
        public IActionResult XoaProduct([FromQuery] int productId)
        {
            var ret = _productService.XoaProduct(productId);
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
