using DelogueAssignment.Entities;
using DelogueAssignment.Data.Interfaces;
using DelogueAssignment.Models;

namespace DelogueAssignment.Data.Repositories;

public class UsersRepository : IUsersRepository
{
    private readonly DelogueDbContext _db;

    public UsersRepository(DelogueDbContext db)
    {
        _db = db;
    }

    public async Task<User?> GetByIdAsync(int id)
    {
        return await _db.Users!.FindAsync(id);
    }

    public async Task<UsersDto> Users(int take, int skip, string sort, string dir)
    {
        UsersDto dto = new() {
            Users = await _db.Users.Select(u => new UserDto {
                Id = u.UserId,
                Name = u.Name
            })
            .OrderBy($"{sort} {dir}")
            .Skip(skip)
            .Take(take)
            .ToListAsync()
        };
        return dto;
    }
}