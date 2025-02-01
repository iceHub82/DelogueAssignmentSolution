using DelogueAssignment.Entities;
using DelogueAssignment.Data.Interfaces;

namespace DelogueAssignment.Data.Repositories;

public class NotesRepository : INotesRepository
{
    private readonly DelogueDbContext _db;

    public NotesRepository(DelogueDbContext db)
    {
        _db = db;
    }

    public async Task<Note?> GetByIdAsync(int id)
    {
        return await _db.Notes!.FindAsync(id);
    }
}