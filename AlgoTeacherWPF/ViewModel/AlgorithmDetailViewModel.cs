using AlgoTeacherWPF.Model;

namespace AlgoTeacherWPF.ViewModel
{
    public class AlgorithmDetailViewModel : BaseViewModel
    {
        public Algorithm Algorithm { get; init; }

        public AlgorithmDetailViewModel(Algorithm algorithm)
        {
            Algorithm = algorithm;
        }
    }
}
