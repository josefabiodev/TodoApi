using TodoApi.Models;

namespace TodoApi.Repositories.Interfaces
{
    public interface ITodoRepository
    {
        Task<List<TodoModel>> GetAllTasks();
        Task<TodoModel> GetById(int id);
        Task<TodoModel> AddTask(TodoModel task);
        Task<TodoModel> UpdateTask(TodoModel task, int id);
        Task<bool> DeleteTask(int id);
    }
}
