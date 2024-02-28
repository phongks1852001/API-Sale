using System.ComponentModel.DataAnnotations;

namespace BaiTapApi.Entities
{
    public class OrderDetail
    {
        [Key]
        public int OrderDetailId { get; set; }
        public int? OrderId { get; set; }
        public int? ProductId { get; set; }
        public double price_total { get; set; }
        public int quantity { get; set; }
        public DateTime created_at { get; set; }
        public DateTime update_at { get; set; }
        public Product? product { get; set; }
        public Order? order { get; set; }    

    }
}
