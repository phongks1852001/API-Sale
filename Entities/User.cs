using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Numerics;

namespace BaiTapApi.Entities
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string user_name { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public string address { get; set; }
        public int? AccountId { get; set; }
        public DateTime? created_at { get; set; }
        public DateTime? update_at { get; set; }
        public Account? account { get; set; }
        public IEnumerable<Order>? orders { get; set; }
    }
}
