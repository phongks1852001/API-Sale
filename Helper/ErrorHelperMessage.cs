namespace BaiTapApi.Helper
{
    public class ErrorHelperMessage
    {
        public static string GetErrorMessage(ErrorHelper errorCode)
        {
            switch (errorCode)
            {
                case ErrorHelper.ThanhCong:
                    return "Thuc hien thanh cong";
                case ErrorHelper.ThatBai:
                    return "Thuc hien that bai, vui long nhap lai";
                case ErrorHelper.TrungLap:
                    return "Du lieu da co, vui long nhap du lieu khac";
                case ErrorHelper.SaiDinhDang:
                    return "Dinh dang bi sai, vui long nhap lai";
                case ErrorHelper.QuaSoLuong1And50:
                    return " ky tu khong nam trong khaong tu 1 -> 50 vui long nhap lai";
                case ErrorHelper.QuaSoTuTu1Den10:
                    return "so tu khong nam trong khoang 1->10. vui long nhap lai";
                 case ErrorHelper.DuLieuSai:
                    return "Du lieu nhap vao khong dung, vui long nhap lai";
                default:
                    return "Loi khong biet, vui long nhap lai";
            }
        }
    }
}
