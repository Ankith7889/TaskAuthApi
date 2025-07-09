using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using TaskAuthApi.Data;
using TaskAuthApi.Models;

namespace TaskAuthApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaskController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TaskController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/task

       [HttpGet]
        public async Task<ActionResult<IEnumerable<TaskItem>>> GetTasks()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return await _context.TaskItems
                .Where(t => t.UserId == userId)
                .ToListAsync();
        }

        // POST: api/task
        [HttpPost]
        public async Task<ActionResult<TaskItem>> CreateTask(TaskItem task)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            task.UserId = userId;

            _context.TaskItems.Add(task);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTasks), new { id = task.Id }, task);
        }
    }
}
