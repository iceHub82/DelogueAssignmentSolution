using DelogueAssignment.Models;

namespace DelogueAssignment.Data.Interfaces;

public interface ITasksRepository
{
    Task<Entities.Task?> GetById(int id);
    Task<TasksDto> Tasks(int take, int skip, string sort, string dir);
    Task<bool> Add(int id, string title, string description, string status);
}