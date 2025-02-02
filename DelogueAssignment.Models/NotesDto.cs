namespace DelogueAssignment.Models;

public class NotesDto
{
    public List<NoteDto>? Notes { get; set; } = new();
}

public class NoteDto
{
    public int Id { get; set; }
    public string? Content { get; set; }
    public int AuthorId { get; set; }
    public string? Author { get; set; }
    public int TaskId { get; set; }
    public string? TaskTitle { get; set; }
}