namespace HoPe.Application.ViewModels
{
    public class LoginUserViewModel
    {
        public LoginUserViewModel(string email, string password)
        {
            Email = email;
            Password = password;
        }

        public string Email { get; set; }
        public string Password { get; set; }
    }
}
