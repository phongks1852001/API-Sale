using BaiTapApi.Entities;
using BaiTapApi.Helper;

namespace BaiTapApi.iServices
{
    public interface IOrderService
    {
        public IQueryable<Order> LayOrderTheoDieuKien(string? keyword, int? year = null,int? month = null, DateTime? tuNgay = null, DateTime? DenNgay = null, double? TuGia = null, double? DenGia = null);
        IEnumerable<Order> GetOrders();
        ErrorHelper TaoDonHang(Order order);
        ErrorHelper SuaDonHang(Order order);
        ErrorHelper XoaDonHang(int id);


    }
}
