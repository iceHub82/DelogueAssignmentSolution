using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace DelogueAssignment.Api.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class NotesController : ControllerBase
{
    private readonly ILogger<NotesController> _logger;

    public NotesController()
    {
        
    }

}