using Tasks.Data;
using Tasks.Interfaces;
using Tasks.Models;

namespace Tasks.Repository
{
    public class TaskRepository : ITaskRepository
    {
        private readonly DataContext _context;
        public TaskRepository(DataContext context)
        {
            _context = context;
        }

        public bool CreateTask(Models.Task task)
        {
            _context.Add(task);
            return Save();
        }

        public bool DeleteTask(Models.Task task)
        {
            _context.Remove(task);
            return Save();
        }

        public Models.Task GetTaskById(int Id)
        {
            return _context.Tasks.Where(t => t.Id == Id).FirstOrDefault();
        }

        public ICollection<Models.Task> GetTasks()
        {
            return _context.Tasks.OrderBy(t => t.Id).ToList();
        }

        public ICollection<Models.Task> GetTasksByUser(int userId)
        {
            return _context.Tasks.Where(r => r.User.Id == userId).ToList();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool TaskExists(int Id)
        {
            return _context.Tasks.Any(t => t.Id == Id);
        }

        public bool UpdateTask(Models.Task task)
        {
            _context.Update(task);
            return Save();
        }
    }
}
