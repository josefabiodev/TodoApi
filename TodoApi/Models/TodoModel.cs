using TodoApi.Enums;

namespace TodoApi.Models
{
    public class TodoModel
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public StatusTask Status { get; set; }
    }
}
