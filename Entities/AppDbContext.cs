using Microsoft.EntityFrameworkCore;

namespace BaiTapApi.Entities
{
    public class AppDbContext : DbContext
    {
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<ProductType> ProductType { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<OrderStatus> OrderStatus { get; set; }
        public virtual DbSet<OrderDetail> OrderDetail { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<Account> Account { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = DESKTOP-UCD9BPR\\SQLEXPRESS ; Database = BaiTapCuoiKhoa_API ; Trusted_Connection = True; TrustServerCertificate = True");
        }
    }
}
