using System.ComponentModel.DataAnnotations;

namespace Quiz.Models;

public class Answer
{
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required(ErrorMessage = "Text is required.")]
    [MinLength(1, ErrorMessage = "Text must be at least 1 characters long.")]
    [MaxLength(256, ErrorMessage = "Text cannot be longer than 256 characters.")]
    public required string Text { get; set; }

    public bool IsCorrect { get; set; } = false;

    public Guid QuestionId { get; set; }

    public Question Question { get; set; } = null!;
}