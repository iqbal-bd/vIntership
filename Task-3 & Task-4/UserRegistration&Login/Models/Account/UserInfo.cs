using System.ComponentModel.DataAnnotations;

namespace UserRegistration_Login.Models.Account
{
    public class UserInfo
    {
        [Key]
        public int ID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public bool IsRemember { get; set; }
    }
}
