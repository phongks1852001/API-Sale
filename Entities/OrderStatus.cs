using System.ComponentModel.DataAnnotations;

namespace BaiTapApi.Entities
{
    public class OrderStatus
    {
        [Key]
        public int OrderStatusId { get; set; }

        public string StatusName { get; set; }

        public IEnumerable<Order> Orders { get; set; }
    }
}
