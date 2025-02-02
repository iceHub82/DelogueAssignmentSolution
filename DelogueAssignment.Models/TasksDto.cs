namespace DelogueAssignment.Models;

public class TasksDto
{
    public List<TaskDto>? Tasks { get; set; } = new();
}

public class TaskDto
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public string? Status { get; set; }
}