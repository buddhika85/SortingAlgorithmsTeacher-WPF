using AlgoTeacherWPF.Model.Enums;

namespace AlgoTeacherWPF.Model;

public class Algorithm
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public Complexity WorstCaseComplexity { get; set; } = null!;
    public Complexity AverageCaseComplexity { get; set; } = null!;
    public Complexity BestCaseComplexity { get; set; } = null!;
    public BigOComplexity SpaceComplexity { get; set; }
    public bool IsStable { get; set; }
}