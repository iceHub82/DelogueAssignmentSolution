using DelogueAssignment.Models;
using DelogueAssignment.Entities;

namespace DelogueAssignment.Data.Interfaces;

public interface IUsersRepository
{
    Task<User?> GetById(int id);
    Task<UsersDto> Users(int take, int skip, string sort, string dir);
    Task<bool> Add(string name, string email);
}