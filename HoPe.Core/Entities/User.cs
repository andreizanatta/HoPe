namespace HoPe.Core.Entities
{
    public class User : BaseEntity
    {
        public User(string fullName, string email, string comment, DateTime bithDate)
        {
            FullName = fullName;
            Email = email;
            BithDate = bithDate;
            Comment = comment;

            CreatedAt = DateTime.Now;
            Active = true;
        }

        public string FullName { get; private set; }
        public string Email { get; private set; }
        public string Comment { get; private set; }
        public DateTime BithDate { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public bool Active { get; private set; }
    }
}
