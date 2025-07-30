using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces;
using Application.DTOs;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIsLayer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaskController : Controller
    {

        private readonly ITaskService _taskService;

        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTask(Guid id, CancellationToken cancellationToken)
        {
            var task = await _taskService.GetTaskByIdAsync(id, cancellationToken);
            if (task == null) return NotFound();
            return Ok(task);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTask()
        {
            var tasks = await _taskService.GetAllTasksAsync();
            return Ok(tasks);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TaskDto dto, CancellationToken cancellationToken)
        {
            var task = await _taskService.AddTaskAsync(dto, cancellationToken);

            return CreatedAtAction(
                nameof(GetTask),                     // the GET method name
                new { id = task.Id },               // route values
                task                                // response body
            );
        }
    }
}

