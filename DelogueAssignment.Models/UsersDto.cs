namespace DelogueAssignment.Models;

public class UsersDto
{
    public List<UserDto>? Users { get; set; } = new();
}

public class UserDto
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Email { get; set; }
}