namespace Quiz.Models;

public class Result
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public Guid TestId { get; set; }

    public Test Test { get; set; } = null!;

    public string UserId { get; set; } = string.Empty;

    public ApplicationUser User { get; set; } = null!;

    public uint CorrectAnswers { get; set; }

    public uint TotalQuestions { get; set; }

    public DateTime CompletionDate { get; set; }
}
