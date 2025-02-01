using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace DelogueAssignment.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TasksController : ControllerBase
{
    public TasksController()
    {
        
    }

    private static readonly List<string> Tasks = new() { "Task 1", "Task 2" };

    [HttpGet("Test")]
    public IActionResult Test()
    {
        return Ok("Test");
    }

    // Public - Anyone with a valid token can read
    [HttpGet]
    [Authorize(Policy = "ReadOnly")]
    public IActionResult GetTasks()
    {
        return Ok(Tasks);
    }

    // User - Can write (create new tasks)
    [HttpPost]
    [Authorize(Policy = "UserWrite")]
    public IActionResult CreateTask([FromBody] string task)
    {
        Tasks.Add(task);
        return Ok("Task Created");
    }

    // Admin - Full access
    [HttpDelete("{index}")]
    [Authorize(Policy = "Admin")]
    public IActionResult DeleteTask(int index)
    {
        if (index < 0 || index >= Tasks.Count)
            return BadRequest("Invalid index");

        Tasks.RemoveAt(index);
        return Ok("Task Deleted");
    }
}