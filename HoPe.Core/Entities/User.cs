namespace HoPe.Core.Entities
{
    public class User : BaseEntity
    {
        public User(string fullName, string email, string comment, DateTime bithDate, string password, string role)
        {
            FullName = fullName;
            Email = email;
            BithDate = bithDate;
            Comment = comment;

            Password = password;
            Role = role;

            CreatedAt = DateTime.Now;
            Active = true;
        }

        public string FullName { get; private set; }
        public string Email { get; private set; }
        public string Comment { get; private set; }
        public DateTime BithDate { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public bool Active { get; private set; }
        public string Password { get; private set; }
        public string Role { get; private set; }
    }
}
