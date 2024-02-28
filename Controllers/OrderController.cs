using BaiTapApi.Entities;
using BaiTapApi.iServices;
using BaiTapApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.Extensions.Logging.EventSource.LoggingEventSource;
using System;
using BaiTapApi.Helper;

namespace BaiTapApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrderController()
        {
            _orderService = new OrderService();
        }
        [HttpGet("HienThiTheoThuocTinh")]
        public IActionResult HienThiOrderTheoThuocTinh([FromQuery] string? keyword, [FromQuery] int? year = null, [FromQuery] int? month = null, [FromQuery] DateTime? tuNgay = null, [FromQuery] DateTime? DenNgay = null, [FromQuery] double? TuGia = null, [FromQuery] double? DenGia = null, [FromQuery]Pagination pagination = null)
        {
            var ret = _orderService.LayOrderTheoDieuKien(keyword, year, month, tuNgay, DenNgay, TuGia, DenGia);

            var Orders = PageResult<Order>.ToPagedResult(pagination, ret).AsEnumerable();
            pagination.totalCount = ret.Count();
            var res = new PageResult<Order>(pagination, Orders);
            return Ok(res);
        }
        [HttpGet]
        public IActionResult GetOrder()
        {
            var OrderHienTai = _orderService.GetOrders();
            return Ok(OrderHienTai);
        }
        [HttpPost("ThemOrder")]
   
        public IActionResult ThemOrder([FromBody]Order order)
        {
            var ret = _orderService.TaoDonHang(order);
            if (ret == Helper.ErrorHelper.ThanhCong)
            {
                return Ok(Helper.ErrorHelperMessage.GetErrorMessage(Helper.ErrorHelper.ThanhCong));
            }
            else
            {
                return BadRequest(Helper.ErrorHelperMessage.GetErrorMessage(Helper.ErrorHelper.ThatBai));
            }
        }
        [HttpPut("SuaOrder")]

        public IActionResult SuaOrder([FromBody] Order order)
        {
            var ret = _orderService.SuaDonHang(order);
            if (ret == Helper.ErrorHelper.ThanhCong)
            {
                return Ok(Helper.ErrorHelperMessage.GetErrorMessage(Helper.ErrorHelper.ThanhCong));
            }
            else
            {
                return BadRequest(Helper.ErrorHelperMessage.GetErrorMessage(Helper.ErrorHelper.ThatBai));
            }
        }
        [HttpDelete("XoaOrder")]
        public IActionResult XoaOrder([FromQuery]int orderId)
        {
            var ret = _orderService.XoaDonHang(orderId);
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
