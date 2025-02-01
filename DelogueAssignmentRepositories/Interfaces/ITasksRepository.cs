namespace DelogueAssignment.Data.Interfaces;

public interface ITasksRepository
{
    Task<Entities.Task?> GetByIdAsync(int id);
}