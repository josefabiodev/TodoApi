using Microsoft.EntityFrameworkCore;
using TodoApi.Models;

namespace TodoApi.Data
{
    public class TodoDbContext : DbContext
    {
        public TodoDbContext(DbContextOptions<TodoDbContext> options) : base(options) 
        {
            
        }

        public DbSet<UserModel> Users { get; set; }
        public DbSet<TodoModel> Todos { get; set; }
    }
}
