namespace Tasks.Models
{
    public class User
    {
        public int Id { get; set; }
        public string email { get; set; }
        public string passwordHash { get; set; }
        public ICollection<Task> Tasks { get; set; }
    }
}
