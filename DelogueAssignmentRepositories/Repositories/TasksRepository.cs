using DelogueAssignment.Data.Interfaces;
using DelogueAssignment.Entities;

namespace DelogueAssignment.Data.Repositories;

public class TasksRepository : ITasksRepository
{
    private readonly DelogueDbContext _db;

    public TasksRepository(DelogueDbContext db)
    {
        _db = db;
    }

    public async Task<Entities.Task?> GetByIdAsync(int id)
    {
        return await _db.Tasks!.FindAsync(id);
    }
}