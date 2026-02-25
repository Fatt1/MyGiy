using Domain.Constants;
using Domain.Repository;
using Microsoft.AspNetCore.Mvc;
namespace TaskMaster.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly AppDbContext _context;


        public TaskController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetTasks()
        {
            return Ok(_context.Tasks);
        }

        [HttpPost("seed")]
        public async Task<IActionResult> SeedTasks()
        {
            var task1 = new Domain.Entities.Task("Task 1", "Description for Task 1", TaskStatusEnum.ToDo, 1, Guid.NewGuid());
            var task2 = new Domain.Entities.Task("Task 2", "Description for Task 2", TaskStatusEnum.ToDo, 1, Guid.NewGuid());
            _context.Tasks.Add(task1);
            _context.Tasks.Add(task2);

            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPost("assign/{taskId}")]
        public async Task<IActionResult> AssignTask(Guid taskId, [FromBody] Guid userId)
        {
            var task = _context.Tasks.FirstOrDefault(t => t.Id == taskId);
            if (task == null)
            {
                return NotFound();
            }
            try
            {
                task.AssignUser(userId);
                await _context.SaveChangesAsync();
                return Ok(task);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
