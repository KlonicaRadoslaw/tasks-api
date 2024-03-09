namespace Tasks.Dto
{
    public class UserDto
    {
        public int Id { get; set; }
        public string email { get; set; }
        public ICollection<Task> Tasks { get; set; }
    }
}
