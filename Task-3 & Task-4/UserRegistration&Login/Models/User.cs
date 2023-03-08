using System.ComponentModel.DataAnnotations;

namespace UserRegistration_Login.Models
{
    public class User
    {
        [Key]
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string District { get; set; }
        public string Division { get; set; }

    }
}
