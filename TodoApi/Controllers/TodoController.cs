using Microsoft.AspNetCore.Mvc;
using TodoApi.Models;
using TodoApi.Repositories.Interfaces;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly ITodoRepository _todoRepository;

        public TodoController(ITodoRepository todoRepository)
        {
            _todoRepository = todoRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<TodoModel>>> GetAllTaskss()
        {
            List<TodoModel> task = await _todoRepository.GetAllTasks();
            return Ok(task);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TodoModel>> GetById(int id)
        {
            TodoModel task = await _todoRepository.GetById(id);
            return Ok(task);
        }

        [HttpPost]
        public async Task<ActionResult<TodoModel>> AddTask([FromBody] TodoModel todoModel)
        {
            TodoModel task =  await _todoRepository.AddTask(todoModel);
            return Ok(task);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<TodoModel>> UpdateTask([FromBody] TodoModel todoModel, int id)
        {
            todoModel.Id = id;
            TodoModel task = await _todoRepository.UpdateTask(todoModel, id);
            return Ok(task);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<TodoModel>> DeleteTask(int id)
        {
            bool deleted = await _todoRepository.DeleteTask(id);
            return Ok(deleted);
        }
    }
}
