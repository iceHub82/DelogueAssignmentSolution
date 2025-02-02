using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using DelogueAssignment.Models;
using DelogueAssignment.Data.Interfaces;

namespace DelogueAssignment.Api.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class NotesController : ControllerBase
{
    private readonly INotesRepository _notesRepo;
    private readonly ILogger<NotesController>? _logger;

    public NotesController(INotesRepository notesRepo, ILogger<NotesController>? logger)
    {
        _notesRepo = notesRepo;
        _logger = logger;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetNote(int id)
    {
        try
        {
            var note = await _notesRepo.GetById(id);

            return note is not null ? Ok(note) : NotFound();
        }
        catch (Exception ex)
        {
            _logger!.LogError(ex.Message);
            return StatusCode(500);
        }
    }

    [HttpGet]
    public async Task<IActionResult> GetPaginatedNotes(int take, int skip, string sort, string dir)
    {
        try
        {
            var notes = await _notesRepo.Notes(take, skip, sort, dir);

            return Ok(notes);
        }
        catch (Exception ex)
        {
            _logger!.LogError(ex.Message);
            return StatusCode(500);
        }
    }

    [HttpPost("Create")]
    public async Task<IActionResult> CreateNote([FromBody] NoteDto dto)
    {
        try
        {
            if (!await _notesRepo.Add(dto.Id, dto.AuthorId, dto.TaskId!, dto.Content!))
                throw new Exception("Error creating note");

            return Ok("Note Created");
        }
        catch (Exception ex)
        {
            _logger!.LogError(ex.Message);
            return StatusCode(500);
        }
    }
}