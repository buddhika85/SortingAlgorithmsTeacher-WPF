using AlgoTeacherWPF.Model;
using System.Collections.Generic;

namespace AlgoTeacherWPF.ViewModel
{
    public class AlgorithmDetailViewModel : BaseViewModel
    {
        public Algorithm Algorithm { get; init; }

        private List<int> _unsortedDataSet;

        public List<int> UnsortedDataSet
        {
            get => _unsortedDataSet;
            set
            {
                _unsortedDataSet = value;
                OnPropertyChanged(nameof(UnsortedDataSet));
            }
        }



        #region constructors

        // This constructor is used for testing and UI design purposes
        public AlgorithmDetailViewModel()
        {
            Algorithm = new Algorithm
            {
                Id = 1,
                Name = "X sort",
                Description =
                    "Lorem Ipsum is simply dummy text of the printing and typesetting industry. It has been the industry's standard dummy text ever since the 1500s," +
                    " when an unknown printer took a galley of type and scrambled it to make a type specimen book. ",
                WorstCaseComplexity = "O(n^2)",
                BestCaseComplexity = "O(n)",
                AverageCaseComplexity = "O(n^2)",
                SpaceComplexity = "O(1)",
                IsStable = false,
                Presentation = new Presentation { BackgroundColor = "Red" }
            };
            _unsortedDataSet = new List<int> { 50, 40, 30, 20, 10 };
        }

        // This constructor will be invoked when MainView algorithm selection button gets clicked
        public AlgorithmDetailViewModel(Algorithm algorithm)
        {
            Algorithm = algorithm;
            _unsortedDataSet = new List<int> { 50, 40, 30, 20, 10 };
        }

        #endregion constructors
    }
}
