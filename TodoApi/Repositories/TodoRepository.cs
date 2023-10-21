using Microsoft.EntityFrameworkCore;
using TodoApi.Data;
using TodoApi.Models;
using TodoApi.Repositories.Interfaces;

namespace TodoApi.Repositories
{
    public class TodoRepository : ITodoRepository
    {
        private readonly TodoDbContext _dbContext;

        public TodoRepository(TodoDbContext todoDbContext)
        {
            _dbContext = todoDbContext;
        }

        public async Task<TodoModel> GetById(int id)
        {
            return await _dbContext.Todos
                .Include(x=>x.User)
                .FirstOrDefaultAsync(task => task.Id == id);
        }

        public async Task<List<TodoModel>> GetAllTasks()
        {
            return await _dbContext.Todos
                .Include(x=>x.User)
                .ToListAsync();
        }

        public async Task<TodoModel> AddTask(TodoModel task)
        {
            await _dbContext.Todos.AddAsync(task);
            await _dbContext.SaveChangesAsync();
            return task;
        }

        public async Task<TodoModel> UpdateTask(TodoModel task, int id)
        {
            TodoModel taskById = await GetById(id);
            if (taskById == null)
            {
                throw new Exception($"Tarefa para o ID: {id} não foi encontrada no banco de dados.");
            }

            taskById.Title = task.Title;
            taskById.Description = task.Description;
            taskById.Status = task.Status;
            taskById.UserId = task.UserId;

            _dbContext.Todos.Update(taskById);
            await _dbContext.SaveChangesAsync();

            return taskById;
        }

        public async Task<bool> DeleteTask(int id)
        {
            TodoModel taskById = await GetById(id);
            if (taskById == null)
            {
                throw new Exception($"Tarefa para o ID: {id} não foi encontrada no banco de dados.");
            }

            _dbContext.Todos.Remove(taskById);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
