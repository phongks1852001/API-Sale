using BaiTapApi.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text.RegularExpressions;

namespace BaiTapApi.Helper
{
    public class InputHelper
    {
        public static bool KiemTraSo(string input)
        {
            double number;
            return double.TryParse(input, out number);
        }
        public static bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
        public static bool KiemTraDoDaiChuoi(string input,int min,  int max)
        {
            return input.Length < max && input.Length> min;
        }
        public static bool KiemTraSoTu(string input, int SoTuMin, int soTuMax)
        {
            return input.Split(' ').Length >= SoTuMin && input.Split(' ').Length <= soTuMax;
        }
        public static string AnMatKhau(string password)
        {
            string hiddenPassword = password.Replace(password, new string('*', password.Length));
            return hiddenPassword;
        }
        public static bool KiemTraNgayThang(string input)
        {
            DateTime dateTime;
            return DateTime.TryParse(input, out dateTime);
        }
        public static bool KiemTraDinhDangSoDienThoai(string soDienThoai)
        {
            string pattern = @"^[0-9]{10,}$"; 

            return Regex.IsMatch(soDienThoai, pattern);
        }
        public static bool KiemTraThongTinAccount(Account account)
        {
            if (!KiemTraDoDaiChuoi(account.user_name, 1, 50))
            {
                return false;
            }
            if (!KiemTraSoTu(account.user_name, 1, 10))
            {
                return false;
            }
            return true;
        }
       public static bool KiemTraUser(User user)
        {
            if (!KiemTraDoDaiChuoi(user.user_name, 1, 50))
            {
                return false;
            }
            if (!KiemTraSoTu(user.user_name, 1, 10))
            {
                return false;
            }
            if(!IsValidEmail(user.email))
            {
                return false;
            }
            if (!KiemTraDoDaiChuoi(user.address, 1, 70))
            {
                return false;
            }
            if (!KiemTraSoTu(user.address, 1, 20))
            {
                return false;
            }
            if (!KiemTraDinhDangSoDienThoai(user.phone))
            {
                return false;
            }
            return true;
        }
        public static bool KiemTraProduct(Product product)
        {
            if (!KiemTraDoDaiChuoi(product.title, 1, 50))
            {
                return false;
            }
            if (!KiemTraSoTu(product.title, 1, 10))
            {
                return false;
            }
         
            if (!KiemTraDoDaiChuoi(product.name_product, 1, 50))
            {
                return false;
            }
            if (!KiemTraSoTu(product.name_product, 1, 20))
            {
                return false;
            }
            return true;
        }
        public static bool KiemTraOrder(Order order)
        {
            if (!KiemTraDoDaiChuoi(order.full_name, 1, 50))
            {
                return false;
            }
            if (!KiemTraSoTu(order.full_name, 1, 10))
            {
                return false;
            }
            if (!IsValidEmail(order.email))
            {
                return false;
            }
            if (!KiemTraDoDaiChuoi(order.address, 1, 70))
            {
                return false;
            }
            if (!KiemTraSoTu(order.address, 1, 20))
            {
                return false;
            }
            if (!KiemTraDinhDangSoDienThoai(order.phone))
            {
                return false;
            }
            return true;
        }
    }
}
