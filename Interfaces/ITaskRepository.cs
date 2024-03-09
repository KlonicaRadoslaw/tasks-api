using Tasks.Models;
namespace Tasks.Interfaces
{
    public interface ITaskRepository
    {
        ICollection<Models.Task> GetTasks();
        bool TaskExists(int Id);
        Models.Task GetTaskById(int Id);
        bool CreateTask(Models.Task task);
        bool UpdateTask(Models.Task task);
        bool DeleteTask(Models.Task task);
        ICollection<Models.Task> GetTasksByUser(int userId);
        bool Save();
    }
}
