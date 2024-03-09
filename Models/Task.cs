using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Tasks.Models
{
    public class Task
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Done { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
