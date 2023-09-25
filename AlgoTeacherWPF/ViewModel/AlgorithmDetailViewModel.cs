using AlgoTeacherWPF.Model;
using System;
using System.Collections.ObjectModel;

namespace AlgoTeacherWPF.ViewModel
{
    public class AlgorithmDetailViewModel : BaseViewModel
    {
        private const int InitialDatSetSize = 5;
        public const int Min = 10;
        public const int Max = 100;
        public Algorithm Algorithm { get; init; }



        private ObservableCollection<int> _unsortedDataSet = new();
        public ObservableCollection<int> UnsortedDataSet
        {
            get => _unsortedDataSet;
            set
            {
                _unsortedDataSet = value;
                OnPropertyChanged(nameof(UnsortedDataSet));
            }
        }


        private int _datSetSize = InitialDatSetSize;

        public int DatSetSize
        {
            get => _datSetSize;
            set
            {
                _datSetSize = value;
                OnPropertyChanged(nameof(DatSetSize));
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
            GenerateRandomDataSet();
        }

        // This constructor will be invoked when MainView algorithm selection button gets clicked
        public AlgorithmDetailViewModel(Algorithm algorithm)
        {
            Algorithm = algorithm;
            GenerateRandomDataSet();
        }

        #endregion constructors

        #region helpers

        private void GenerateRandomDataSet()
        {
            Random rnd = new();
            UnsortedDataSet.Clear();
            for (var i = 0; i < _datSetSize; i++)
            {
                UnsortedDataSet.Add(rnd.Next(Min, Max + 1));
            }
        }
        #endregion helpers
    }
}