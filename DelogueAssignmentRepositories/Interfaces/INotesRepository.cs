using DelogueAssignment.Entities;

namespace DelogueAssignment.Data.Interfaces;

public interface INotesRepository
{
    Task<Note?> GetByIdAsync(int id);
}