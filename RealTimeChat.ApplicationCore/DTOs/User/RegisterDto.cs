namespace RealTimeChat.ApplicationCore.DTOs.User
{
    public class RegisterDto
    {
        public RegisterDto()
        {
            
        }
        public RegisterDto(string email, string password, string name,
            string lastName, string confirmPassword, string userName)
        {
            Email = email;
            Password = password;
            Name = name;
            LastName = lastName;
            ConfirmPassword = confirmPassword;
            UserName = userName;
        }

        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string ConfirmPassword { get; set; }
        public string UserName { get; set; }
    }
}
