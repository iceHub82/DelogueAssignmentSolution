using DelogueAssignment.Entities;
using DelogueAssignment.Models;

namespace DelogueAssignment.Data.Interfaces;

public interface INotesRepository
{
    Task<Note?> GetById(int id);
    Task<NotesDto> Notes(int take, int skip, string sort, string dir);
    Task<bool> Add(int id, int taskId, int authorId, string content);
}