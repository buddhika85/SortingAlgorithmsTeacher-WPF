namespace AlgoTeacherWPF.Model.Enums;

public enum ComplexityCase
{
    WorstCase,
    AverageCase,
    BestCase
}

public enum BigOComplexity
{
    OOne,           // O(1)         - constant
    OLogN,          // O(log n)     - logarithmic
    On,             // O(n)         - linear
    OnLogN,         // O(n log n)   - loglinear 
    OnSquared,      // O(n^2)       - quadratic
    OTwoSquaredN,   // O(2^n)       - Exponential 
    OnBang          // O(n!)        - factorial
}

public enum SortSpeed
{
    OneX,
    TwoX,
    ThreeX,
    FourX,
    FiveX
}

public enum SortLogMessageType
{
    NormalMessage,
    ComparisonMessage,
    SwapMessage,
    NonSwapMessage,
    SortStartMessage,
    SortCompleteMessage
}