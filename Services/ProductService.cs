using BaiTapApi.Entities;
using BaiTapApi.Helper;
using BaiTapApi.iServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace BaiTapApi.Services
{
    public class ProductService : iProductService
    {
        private readonly AppDbContext dbContext;

        public ProductService()
        {
            dbContext = new AppDbContext();
        }
        public IEnumerable<Product> LayDanhSachProducts()
        {
            return dbContext.Product.AsQueryable();
        }

        public ErrorHelper SuaProduct(Product product)
        {
            if(!InputHelper.KiemTraProduct(product))
            {
                return ErrorHelper.ThatBai;
            }
            var ProductHienTai = dbContext.Product.FirstOrDefault(x=>x.ProductId == product.ProductId);
            if(ProductHienTai != null)
            {
                ProductHienTai = new Product()
                {
                    ProductTypeId = product.ProductTypeId,
                    name_product = product.name_product,
                    price = product.price,
                    avartar_image_product = product.avartar_image_product,
                    title = product.title,
                    discount = product.discount,
                    status = product.status,
                    number_of_views = product.number_of_views,
                    update_at = DateTime.Now
                };
                dbContext.Update(ProductHienTai);
                dbContext.SaveChanges();
                return ErrorHelper.ThanhCong;
            }
            else
            {
                return ErrorHelper.ThatBai;
            }
        }

        public ErrorHelper ThemProduct(Product product)
        {
            if(!InputHelper.KiemTraProduct(product))
            {
                return ErrorHelper.ThatBai;
            }
            var newProduct = new Product()
            {
                ProductTypeId = product.ProductTypeId,
                name_product = product.name_product,
                price = product.price,
                avartar_image_product = product.avartar_image_product,
                title = product.title,
                discount = product.discount,
                status = product.status,
                number_of_views = product.number_of_views,
                created_at = DateTime.Now,
                update_at = DateTime.Now
            };
            if(dbContext.ProductType.FirstOrDefault(x=>x.ProductTypeId == product.ProductTypeId) == null) {
                return ErrorHelper.DuLieuSai;
            }
            dbContext.Product.Add(newProduct);
            dbContext.SaveChanges();
            return ErrorHelper.ThanhCong;
        }

        public IQueryable<Product> TimKiemProducts( string keyword)
        {
            var query = dbContext.Product.Include(x=>x.productType).Include(x=>x.orderDetails).AsQueryable();
            if (!keyword.IsNullOrEmpty())
            {
                query = query.Where(x=>x.name_product.Contains(keyword.ToLower()) || x.ProductId.ToString().Contains(keyword.ToLower()));
            }
            return query;
        }

        public ErrorHelper XoaProduct(int productId)
        {
           var ProductHienTai = dbContext.Product.FirstOrDefault(x => x.ProductId == productId);
            if(ProductHienTai != null) {
                    
                dbContext.Remove(ProductHienTai);
                dbContext.SaveChanges();
                return ErrorHelper.ThanhCong;
            }
            else
            {
                return ErrorHelper.ThatBai;
            }
        }
    }
}
