namespace AlgoTeacherWPF.Model;

public class Algorithm
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string WorstCaseComplexity { get; set; } = null!;
    public string AverageCaseComplexity { get; set; } = null!;
    public string BestCaseComplexity { get; set; } = null!;
    public string SpaceComplexity { get; set; } = null!;
    public bool IsStable { get; set; }
}