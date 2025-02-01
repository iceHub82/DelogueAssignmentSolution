using DelogueAssignment.Entities;

namespace DelogueAssignment.Data.Interfaces;

public interface IUsersRepository
{
    Task<User?> GetByIdAsync(int id);
}