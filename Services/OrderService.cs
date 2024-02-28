using BaiTapApi.Entities;
using BaiTapApi.Helper;
using BaiTapApi.iServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Net;
using System.Numerics;

namespace BaiTapApi.Services
{
    public class OrderService : IOrderService
    {
        private readonly AppDbContext dbContext;
        public OrderService()
        {
            dbContext = new AppDbContext();
        }

        public IEnumerable<Order> GetOrders()
        {
            return dbContext.Order.Include(x=>x.user).Include(x=>x.orderStatus).Include(x=>x.orderDetails).Include(x=>x.orderDetails).ThenInclude(x=>x.product).AsNoTracking().AsQueryable();
        }

        public IQueryable<Order> LayOrderTheoDieuKien(string? keyword, int? year = null, int? month = null, DateTime? tuNgay = null, DateTime? DenNgay = null, double? TuGia = null, double? DenGia = null)
        {
            var query = dbContext.Order.Include(x=>x.user).OrderByDescending(x=>x.created_at).AsQueryable();
               
            if(!keyword.IsNullOrEmpty() )
            {
                query = query.Where(x => x.full_name.Contains(keyword.ToLower()) || x.email.Contains(keyword.ToLower()));
            }
            if(year.HasValue)
            {
                query = query.Where(x => x.update_at.Value.Year == year);
            }
            if(month.HasValue)
            {
                query = query.Where(x=>x.update_at.Value.Month == month);
            }
            if (tuNgay.HasValue)
            {
                query = query.Where(x=>x.update_at.Value.Date >= tuNgay.Value.Date);
            }
            if(DenNgay.HasValue)
            {
                query = query.Where(x=>x.update_at.Value.Date <= DenNgay.Value.Date);
            }
            if (TuGia.HasValue)
            {
                query = query.Where(x => x.actual_price >= TuGia);
            }
            if (DenGia.HasValue)
            {
                query = query.Where(x=>x.actual_price <= DenGia);
            }
            return query;
        }

        public ErrorHelper SuaDonHang(Order order)
        {
            if (!InputHelper.KiemTraOrder(order))
            {
                return ErrorHelper.ThatBai;
            }
            var OrderHienTai = dbContext.Order.Include(o => o.orderDetails).FirstOrDefault(x => x.OrderId == order.OrderId);

            if (OrderHienTai != null)
            {
                OrderHienTai = new Order()
                {
                    UserId = order.UserId,
                    original_price = order.original_price,
                    actual_price = order.actual_price,
                    full_name = order.full_name,
                    email = order.email,
                    phone = order.phone,
                    address = order.address,
                    OrderStatusId = order.OrderStatusId,
                    update_at = DateTime.Now
                };
                
                dbContext.Update(OrderHienTai);
                dbContext.SaveChanges();
                return ErrorHelper.ThanhCong;
            }
            else
            {
                return ErrorHelper.ThatBai;
            }
        }

        public ErrorHelper TaoDonHang(Order order)
        {
            if(!InputHelper.KiemTraOrder(order))
            {
                return ErrorHelper.ThatBai;
            }
            var newOrder = new Order()
            {
                UserId = order.UserId,
                original_price = order.original_price,
                actual_price = order.actual_price,
                full_name = order.full_name,
                email = order.email,
                phone = order.phone,
                address = order.address,
                OrderStatusId = order.OrderStatusId,
                created_at = DateTime.Now,
                update_at = DateTime.Now,
            };
            if (dbContext.User.FirstOrDefault(x => x.UserId == newOrder.UserId) == null)
            {
                return ErrorHelper.DuLieuSai;
            }
            if (dbContext.OrderStatus.FirstOrDefault(x => x.OrderStatusId == newOrder.OrderStatusId) == null)
            {
                return ErrorHelper.DuLieuSai;
            }
            dbContext.Order.Add(newOrder);
            dbContext.SaveChanges();
            return ErrorHelper.ThanhCong;


        }

        public ErrorHelper XoaDonHang(int id)
        {
            var DonHangHienTai = dbContext.Order.FirstOrDefault(x=>x.OrderId == id);
            if(DonHangHienTai != null)
            {
                return ErrorHelper.ThanhCong;
            }
            else
            {
                return ErrorHelper.ThatBai;
            }
        }
    }
}
