using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using DelogueAssignment.Models;
using DelogueAssignment.Data.Interfaces;

namespace DelogueAssignment.Api.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class UsersController(IUsersRepository usersRepo) : ControllerBase
{
    private readonly IUsersRepository _usersRepo = usersRepo;
    private readonly ILogger<UsersController>? _logger;

    [HttpGet("{id}")]
    public async Task<IActionResult> GetUser(int id)
    {
        try
        {
            var user = await _usersRepo.GetById(id);

            return user is not null ? Ok(user) : NotFound();
        }
        catch (Exception ex)
        {
            _logger!.LogError(ex.Message);
            return StatusCode(500);
        }
    }

    [HttpGet]
    public async Task<IActionResult> GetPaginatedUsers(int take, int skip, string sort, string dir)
    {
        try
        {
            var users = await _usersRepo.Users(take, skip, sort, dir);

            return Ok(users);
        }
        catch (Exception ex)
        {
            _logger!.LogError(ex.Message);
            return StatusCode(500);
        }
    }

    [HttpPost("Create")]
    [Authorize(Policy = "Admin")]
    public async Task<IActionResult> CreateUser([FromBody] UserDto dto)
    {
        try
        {
            if (!await _usersRepo.Add(dto.Name!, dto.Email!))
                throw new Exception("Error creating user"); 

            return Ok("User Created");
        }
        catch (Exception ex)
        {
            _logger!.LogError(ex.Message);
            return StatusCode(500);
        }
    }
}