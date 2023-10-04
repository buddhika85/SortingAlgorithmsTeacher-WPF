namespace AlgoTeacherWPF.Model
{
    public class SortResultModel : ObservableModel
    {
        public string AlgorithmName { get; set; } = null!;

        private int _comparisons = 0;
        public int Comparisons
        {
            get => _comparisons;
            set
            {
                _comparisons = value;
                OnPropertyChanged(nameof(Comparisons));
            }
        }

        private int _swaps = 0;
        public int Swaps
        {
            get => _swaps;
            set
            {
                _swaps = value;
                OnPropertyChanged(nameof(Swaps));
            }
        }


        private int _totalOperations = 0;
        public int TotalOperations
        {
            get => _totalOperations;
            set
            {
                _totalOperations = value;
                OnPropertyChanged(nameof(TotalOperations));
            }
        }
    }
}
