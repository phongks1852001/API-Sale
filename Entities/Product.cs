using System.ComponentModel.DataAnnotations;

namespace BaiTapApi.Entities
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        public int ProductTypeId { get; set; }
        public string name_product { get; set; }
        public double price { get; set; }
        public string avartar_image_product { get; set; }
        public string title { get; set; }
        public int discount { get; set; }
        public int status { get; set; }
        public int number_of_views { get; set; }
        public DateTime? created_at { get; set; }
        public DateTime? update_at { get; set; }
        public IEnumerable<OrderDetail>? orderDetails { get; set; }
        public ProductType? productType { get; set; }
       
    }
}
