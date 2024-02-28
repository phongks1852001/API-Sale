using BaiTapApi.Entities;
using BaiTapApi.Helper;

namespace BaiTapApi.iServices
{
    public interface IAccountService
    {
        public IEnumerable<Account> GetAccounts();
        ErrorHelper  TaoTaiKhoan(Account account);
        ErrorHelper  DangNhap(DangNhapModel dangNhapModel);
        ErrorHelper ChinhSuaThongTinTaiKhoan(Account account);
        ErrorHelper XoaTaiKhoan(int idAccount);

    }
}
