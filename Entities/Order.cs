using System.ComponentModel.DataAnnotations;

namespace BaiTapApi.Entities
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        public int UserId { get; set; }
        public double original_price { get; set; }
        public double actual_price { get; set; }
        public string full_name { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string address { get; set; }
        public int OrderStatusId { get; set; }
        public DateTime? created_at { get; set; }
        public DateTime? update_at { get; set; }
        public User? user { get; set; }
        public IEnumerable<OrderDetail>? orderDetails { get; set; }

        public OrderStatus? orderStatus { get; set; }
    }
}
