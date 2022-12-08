namespace MwiesStore.Models
{
    public class Users
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Gender { get; set; }
        public DateTime Birthdate { get; set; }
        public string Phone { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int Lock { get; set; }
        public int Role { get; set; }
    }
}
