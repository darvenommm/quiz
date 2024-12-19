using System.ComponentModel.DataAnnotations;

namespace Quiz.Models;

public class Question
{
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required(ErrorMessage = "Text is required.")]
    [MinLength(5, ErrorMessage = "Text must be at least 5 characters long.")]
    [MaxLength(256, ErrorMessage = "Text cannot be longer than 256 characters.")]
    public required string Text { get; set; }

    public Guid TestId { get; set; }

    public Test Test { get; set; } = null!;

    public ICollection<Answer> Answers { get; set; } = new List<Answer>();
}
