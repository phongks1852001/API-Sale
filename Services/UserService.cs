using BaiTapApi.Entities;
using BaiTapApi.Helper;
using BaiTapApi.iServices;
using Microsoft.Identity.Client;
using Microsoft.IdentityModel.Tokens;
using System.Net;
using System.Numerics;

namespace BaiTapApi.Services
{
    public class UserService : iUserService
    {
        private readonly AppDbContext dbContext;
        public UserService()
        {
            dbContext = new AppDbContext();
        }
        public IEnumerable<User> LayUsers()
        {
            return dbContext.User.AsQueryable();
        }

        public ErrorHelper SuaUser(User user)
        {
            if(!InputHelper.KiemTraUser(user))
            {
                return ErrorHelper.ThatBai;
            }
            var UserHienTai = dbContext.User.FirstOrDefault(x => x.UserId == user.UserId);
            if (UserHienTai != null)
            {
               
                UserHienTai = new User()
                {
                    user_name = user.user_name,
                    phone = user.phone,
                    email = user.email,
                    address = user.address,
                    update_at = DateTime.Now,
                };
                dbContext.User.Update(UserHienTai);
                dbContext.SaveChanges();
                return ErrorHelper.ThanhCong;
            }
            else
            {
                return ErrorHelper.ThatBai;
            }
        }

        public ErrorHelper TaoUser(User user)
        {
            if (!InputHelper.KiemTraUser(user))
            {
                return ErrorHelper.DuLieuSai;
            }
            if (user.AccountId <= 0)
            {
                return ErrorHelper.DuLieuSai;
            }
            var newUser = new User()
            {
                user_name = user.user_name,
                phone = user.phone,
                email = user.email,
                address = user.address,
                AccountId = user.AccountId,
                created_at = DateTime.Now,
                update_at = DateTime.Now,
            };

            if (dbContext.Account.FirstOrDefault(x => x.AccountId == newUser.AccountId) == null)
            {
                return ErrorHelper.DuLieuSai;
            }
            else if (dbContext.User.Where(x => x.AccountId == user.AccountId).Count() > 0)
            {
                return ErrorHelper.TrungLap;
            }
            else
            {
                dbContext.User.Add(newUser);
                dbContext.SaveChanges();
                return ErrorHelper.ThanhCong;
            }
        }

        public ErrorHelper XoaUser(int user)
        {
            var UserHienTai = dbContext.User.FirstOrDefault(x => x.UserId == user);
            if (UserHienTai != null)
            {
                dbContext.Remove(UserHienTai);
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
