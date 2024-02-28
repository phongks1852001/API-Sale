using BaiTapApi.Entities;
using BaiTapApi.Helper;

namespace BaiTapApi.iServices
{
    public interface iUserService
    {
        ErrorHelper TaoUser(User user);
        ErrorHelper SuaUser(User user);
        ErrorHelper XoaUser(int user);
        IEnumerable<User> LayUsers();

    }
}
