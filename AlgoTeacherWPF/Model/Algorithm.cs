namespace AlgoTeacherWPF.Model;

public class Algorithm
{
    public int Id { get; set; }
    public string Description { get; set; } = null!;
    public TimeComplexity WorstCaseComplexity { get; set; } = null!;
    public TimeComplexity AverageCaseComplexity { get; set; } = null!;
    public TimeComplexity BestCaseComplexity { get; set; } = null!;
    public bool IsStable { get; set; }
}