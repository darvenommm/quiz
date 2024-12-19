using System.ComponentModel.DataAnnotations;

namespace Quiz.Models;

public class Test
{
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required(ErrorMessage = "Title is required.")]
    [MinLength(5, ErrorMessage = "Title must be at least 5 characters long.")]
    [MaxLength(256, ErrorMessage = "Title cannot be longer than 256 characters.")]
    public required string Title { get; set; }

    [Required(ErrorMessage = "Description is required.")]
    [MinLength(6, ErrorMessage = "Description must be at least 6 characters long.")]
    [MaxLength(1000, ErrorMessage = "Description cannot be longer than 1000 characters.")]
    public required string Description { get; set; }

    public ICollection<Question> Questions { get; set; } = new List<Question>();

    public ICollection<Result> Results { get; set; } = new List<Result>();
}
