using System.ComponentModel.DataAnnotations;

namespace BaiTapApi.Entities
{
    public class Account
    {
        [Key]
        public int AccountId { get; set; }
        public string user_name { get; set; }
        public string avatar { get; set; }
        public string password { get; set; }
        public int? status { get; set; }
        public DateTime? created_at { get; set; }
        public DateTime? update_at { get; set; }
        public IEnumerable<User>? users { get; set; }
    }
    
}
