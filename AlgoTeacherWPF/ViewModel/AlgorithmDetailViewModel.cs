using AlgoTeacherWPF.Model;

namespace AlgoTeacherWPF.ViewModel
{
    public class AlgorithmDetailViewModel : BaseViewModel
    {
        public string Name { get; set; }

        private readonly Algorithm _algorithm;

        public AlgorithmDetailViewModel(Algorithm algorithm)
        {
            _algorithm = algorithm;
            Name = algorithm.Name;
        }
    }
}
