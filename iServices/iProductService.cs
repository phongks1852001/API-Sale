using BaiTapApi.Entities;
using BaiTapApi.Helper;

namespace BaiTapApi.iServices
{
    public interface iProductService
    {
        IEnumerable<Product> LayDanhSachProducts();
        ErrorHelper ThemProduct(Product product);
        ErrorHelper SuaProduct(Product product);
        ErrorHelper XoaProduct(int  productId);
        IQueryable<Product> TimKiemProducts(string keyword);
        
             
    }
}
