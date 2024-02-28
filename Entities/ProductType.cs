using System.ComponentModel.DataAnnotations;

namespace BaiTapApi.Entities
{
    public class ProductType
    {
        [Key]
        public int ProductTypeId { get; set; }
        public string name_product_type { get; set; }
        public string image_type_product { get; set; }
        public DateTime created_at { get; set; }
        public DateTime update_at { get; set; }
        public IEnumerable<Product> products { get; set; }
    }
}
