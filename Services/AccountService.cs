using BaiTapApi.Entities;
using BaiTapApi.Helper;
using BaiTapApi.iServices;

namespace BaiTapApi.Services
{
    public class AccountService : IAccountService
    {
        private readonly AppDbContext dbContext;
        public AccountService()
        {
            dbContext = new AppDbContext();
        }
        public IEnumerable<Account> GetAccounts()
        {
            return dbContext.Account.AsQueryable();
        }
        public ErrorHelper ChinhSuaThongTinTaiKhoan(Account account)
        {
            var accountHienTai = dbContext.Account.FirstOrDefault(x => x.AccountId == account.AccountId);
            if (accountHienTai != null)
            {
                if (!InputHelper.KiemTraThongTinAccount(account))
                {
                    return ErrorHelper.ThatBai;
                }
                accountHienTai = new Account
                {
                    user_name = account.user_name,
                    avatar = account.avatar,
                    password = account.password,
                    status = account.status,
                    update_at = DateTime.Now,
                };
                dbContext.Account.Update(accountHienTai);
                dbContext.SaveChanges();
                return ErrorHelper.ThanhCong;
            }
            else
            {
                return ErrorHelper.ThatBai;
            }
        }

        public ErrorHelper DangNhap(DangNhapModel dangNhapModel)
        {
            if (!InputHelper.KiemTraDoDaiChuoi(dangNhapModel.TenDangNhap, 1, 50))
            {
                return ErrorHelper.QuaSoLuong1And50;
            }
            if (!InputHelper.KiemTraSoTu(dangNhapModel.TenDangNhap, 1, 20))
            {
                return ErrorHelper.QuaSoTuTu1Den10;
            }
            if (dbContext.Account.Any(x => x.user_name == dangNhapModel.TenDangNhap) && dbContext.Account.Any(x => x.password == dangNhapModel.MatKhau))
            {
                return ErrorHelper.ThanhCong;
            }
            else
            {
                return ErrorHelper.ThatBai;
            }
        }

      

        public ErrorHelper TaoTaiKhoan(Account account)
        {
            if (dbContext.Account.Any(x => x.user_name == account.user_name))
            {
                return ErrorHelper.TrungLap;
            }
            var newAccount = new Account
            {
                user_name = account.user_name,
                avatar = account.avatar,
                password = account.password,
                created_at = DateTime.Now
            };
            dbContext.Account.Add(newAccount);
            dbContext.SaveChanges();
            return ErrorHelper.ThanhCong;
        }

        public ErrorHelper XoaTaiKhoan(int idAccount)
        {
            var TaiKhoanHietTai = dbContext.Account.FirstOrDefault(x=>x.AccountId == idAccount);
            if(TaiKhoanHietTai != null)
            {
                dbContext.Remove(TaiKhoanHietTai);
                dbContext.SaveChanges();
                return ErrorHelper.ThanhCong;
            }
            else { return ErrorHelper.ThatBai; }
        }

    }
}
