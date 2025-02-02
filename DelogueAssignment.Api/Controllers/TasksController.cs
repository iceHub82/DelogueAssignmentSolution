using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using DelogueAssignment.Data.Interfaces;

namespace DelogueAssignment.Api.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class TasksController : ControllerBase
{
    private readonly ITasksRepository _tasksRepo;
    private readonly ILogger<TasksController> _logger;

    public TasksController(ITasksRepository tasksRepo)
    {
        _tasksRepo = tasksRepo;
    }
}