using System.Linq.Dynamic.Core;
using Microsoft.EntityFrameworkCore;
using DelogueAssignment.Models;
using DelogueAssignment.Entities;
using DelogueAssignment.Data.Interfaces;

namespace DelogueAssignment.Data.Repositories;

public class NotesRepository(DelogueDbContext db) : INotesRepository
{
    private readonly DelogueDbContext _db = db;

    public async Task<Note?> GetById(int id)
    {
        return await _db.Notes!.FindAsync(id);
    }

    public async Task<NotesDto> Notes(int take, int skip, string sort, string dir)
    {
        NotesDto dto = new() {
            Notes = await _db.Notes.Include(n => n.Author).Include(n => n.Task).Select(n => new NoteDto {
                Id = n.NoteId,
                Content = n.Content,
                Author = n.Author.Name,
                TaskTitle = n.Task.Title
            })
            .OrderBy($"{sort} {dir}")
            .Skip(skip)
            .Take(take)
            .ToListAsync()
        };

        return dto;
    }

    public async Task<bool> Add(int id, int authorId, int taskId, string content)
    {
        //var user = await _db.Users.FindAsync(authorId) ?? throw new Exception("User not found");
        //var task = await _db.Tasks.FindAsync(taskId) ?? throw new Exception("Task not found");

        await _db.Notes.AddAsync(new Note {
            NoteId = id,
            AuthorId = authorId,
            TaskId = taskId,
            //Author = user,
            //Task = task,
            Content = content,
            CreatedAt = DateTime.Now
        });

        var result = await _db.SaveChangesAsync();

        return result > 0;
    }
}