namespace UserRegistration_Login.Models.ViewModel
{
    public class Login_SignUp
    {
        public int ID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public bool IsActive { get; set; }
        public bool IsRemember { get; set; }
    }
}
