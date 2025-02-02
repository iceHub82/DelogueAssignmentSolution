using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using DelogueAssignment.Models;
using DelogueAssignment.Data.Interfaces;

namespace DelogueAssignment.Api.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class TasksController : ControllerBase
{
    private readonly ITasksRepository _tasksRepo;
    private readonly ILogger<TasksController>? _logger;

    public TasksController(ITasksRepository tasksRepo, ILogger<TasksController>? logger)
    {
        _tasksRepo = tasksRepo;
        _logger = logger;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetTask(int id)
    {
        try
        {
            var task = await _tasksRepo.GetById(id);

            return task is not null ? Ok(task) : NotFound();
        }
        catch (Exception ex)
        {
            _logger!.LogError(ex.Message);
            return StatusCode(500);
        }
    }

    [HttpGet]
    public async Task<IActionResult> GetPaginatedTasks(int take, int skip, string sort, string dir)
    {
        try
        {
            var tasks = await _tasksRepo.Tasks(take, skip, sort, dir);

            return Ok(tasks);
        }
        catch (Exception ex)
        {
            _logger!.LogError(ex.Message);
            return StatusCode(500);
        }
    }

    [HttpPost("Create")]
    public async Task<IActionResult> CreateTask([FromBody] TaskDto dto)
    {
        try
        {
            if (!await _tasksRepo.Add(dto.Id, dto.Title!, dto.Description!, dto.Status!))
                throw new Exception("Error creating task");

            return Ok("Task Created");
        }
        catch (Exception ex)
        {
            _logger!.LogError(ex.Message);
            return StatusCode(500);
        }
    }
}