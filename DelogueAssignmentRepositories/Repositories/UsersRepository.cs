using System.Linq.Dynamic.Core;
using Microsoft.EntityFrameworkCore;
using DelogueAssignment.Models;
using DelogueAssignment.Entities;
using DelogueAssignment.Data.Interfaces;

namespace DelogueAssignment.Data.Repositories;

public class UsersRepository : IUsersRepository
{
    private readonly DelogueDbContext _db;

    public UsersRepository(DelogueDbContext db)
    {
        _db = db;
    }

    public async Task<User?> GetById(int id)
    {
        return await _db.Users!.FindAsync(id);
    }

    public async Task<UsersDto> Users(int take, int skip, string sort, string dir)
    {
        UsersDto dto = new() {
            Users = await _db.Users.Select(u => new UserDto {
                Id = u.UserId,
                Name = u.Name,
                Email = u.Email
            })
            .OrderBy($"{sort} {dir}")
            .Skip(skip)
            .Take(take)
            .ToListAsync()
        };

        return dto;
    }

    public async Task<bool> Add(int id, string name, string email)
    {
        await _db.Users.AddAsync(new User { UserId = id, Name = name, Email = email});
        var result = await _db.SaveChangesAsync();

        return result > 0;
    }
}