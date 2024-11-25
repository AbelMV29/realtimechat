namespace RealTimeChat.ApplicationCore.DTOs.User
{
    public class UserDto
    {
        public UserDto()
        {
            
        }
        public UserDto(int id, string? photoUrl, string fullName, string userName)
        {
            Id = id;
            PhotoUrl = photoUrl;
            FullName = fullName;
            UserName = userName;
        }

        public int Id { get; set; }
        public string? PhotoUrl { get; set; }
        public string FullName { get; set; }
        public string UserName { get; set; }
    }
}
