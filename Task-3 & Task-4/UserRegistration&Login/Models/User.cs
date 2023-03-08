using System.ComponentModel.DataAnnotations;

namespace UserRegistration_Login.Models
{
    public class User
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string FullName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string District { get; set; }
        [Required]
        public string PostCode { get; set; }
        [Required]
        public string Division { get; set; }

    }
}
