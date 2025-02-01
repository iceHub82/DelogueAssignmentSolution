using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using DelogueAssignment.Data.Interfaces;
using DelogueAssignment.Data.Repositories;

namespace DelogueAssignment.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUsersRepository _userRepo;

    public UsersController(IUsersRepository userRepo)
    {
        _userRepo = userRepo;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetUser(int id)
    {
        var user = await _userRepo.GetByIdAsync(id);

        return user is not null ? Ok(user) : NotFound();
    }

    //// Public - Anyone with a valid token can read
    [HttpGet]
    [Authorize(Policy = "ReadOnly")]
    public IActionResult GetPaginatedUsers(int take, int skip, string sort, string dir)
    {
        return Ok();
    }

    //// User - Can write (create new tasks)
    //[HttpPost]
    //[Authorize(Policy = "UserWrite")]
    //public IActionResult CreateTask([FromBody] string task)
    //{
    //    Tasks.Add(task);
    //    return Ok("Task Created");
    //}

    //// Admin - Full access
    //[HttpDelete("{index}")]
    //[Authorize(Policy = "Admin")]
    //public IActionResult DeleteTask(int index)
    //{
    //    if (index < 0 || index >= Tasks.Count)
    //        return BadRequest("Invalid index");

    //    Tasks.RemoveAt(index);
    //    return Ok("Task Deleted");
    //}
}