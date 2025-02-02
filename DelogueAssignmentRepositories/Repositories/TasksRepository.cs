using System.Linq.Dynamic.Core;
using Microsoft.EntityFrameworkCore;
using DelogueAssignment.Models;
using DelogueAssignment.Entities;
using DelogueAssignment.Data.Interfaces;

namespace DelogueAssignment.Data.Repositories;

public class TasksRepository(DelogueDbContext db) : ITasksRepository
{
    private readonly DelogueDbContext _db = db;

    public async Task<Entities.Task?> GetById(int id)
    {
        return await _db.Tasks!.FindAsync(id);
    }

    public async Task<TasksDto> Tasks(int take, int skip, string sort, string dir)
    {
        TasksDto dto = new() {
            Tasks = await _db.Tasks.Select(u => new TaskDto {
                Id = u.TaskId,
                Title = u.Title,
                Description = u.Description
            })
            .OrderBy($"{sort} {dir}")
            .Skip(skip)
            .Take(take)
            .ToListAsync()
        };

        return dto;
    }

    public async Task<bool> Add(int id, string title, string description, string status)
    {
        await _db.Tasks.AddAsync(new Entities.Task {
            TaskId = id,
            Title = title, 
            Description = description,
            Status = status,
            CreatedAt = DateOnly.FromDateTime(DateTime.Now) 
        });

        var result = await _db.SaveChangesAsync();

        return result > 0;
    }
}