using AlgoTeacherWPF.Model;
using AlgoTeacherWPF.Model.Enums;
using AlgoTeacherWPF.Utilities;
using AlgoTeacherWPF.ViewModel.Commands;
using System.Collections.ObjectModel;
using System.Linq;

namespace AlgoTeacherWPF.ViewModel
{
    public class AlgorithmDetailViewModel : BaseViewModel
    {
        private const int InitialDatSetSize = 5;
        private const int Min = 10;
        private const int Max = 100;
        internal readonly int MinDataSetSize = 2;      // made these internal to access from command class
        internal readonly int MaxDataSetSize = 10;

        public Algorithm Algorithm { get; init; }

        #region commands

        public DataSetSizeIncreaseCommand DataSetSizeIncreaseCommand { get; set; } = null!;
        public DataSetSizeDecreaseCommand DataSetSizeDecreaseCommand { get; set; } = null!;
        public CaseRadioButtonSelectionCommand CaseRadioButtonSelectionCommand { get; set; } = null!;
        #endregion commands



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


        private int _dataSetSize = InitialDatSetSize;

        public int DataSetSize
        {
            get => _dataSetSize;
            set
            {
                _dataSetSize = value;
                OnPropertyChanged(nameof(DataSetSize));
                GenerateRandomDataSet();
            }
        }

        private ComplexityCase _complexityCase;

        public ComplexityCase ComplexityCase
        {
            get => _complexityCase;
            set
            {
                _complexityCase = value;
                OnPropertyChanged(nameof(ComplexityCase));
                ReArrangeDataSet();
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
            SetupCommands();
        }

        // This constructor will be invoked when MainView algorithm selection button gets clicked
        public AlgorithmDetailViewModel(Algorithm algorithm)
        {
            Algorithm = algorithm;
            GenerateRandomDataSet();
            SetupCommands();
        }

        #endregion constructors


        public void DataSetSizeIncrease()
        {
            ++DataSetSize;
        }

        public void DataSetSizeDecrease()
        {
            --DataSetSize;
        }

        public void SetComplexityCase(ComplexityCase complexityCase)
        {
            ComplexityCase = complexityCase;
        }

        #region helpers

        private void SetupCommands()
        {
            DataSetSizeIncreaseCommand = new DataSetSizeIncreaseCommand(this);
            DataSetSizeDecreaseCommand = new DataSetSizeDecreaseCommand(this);
            CaseRadioButtonSelectionCommand = new CaseRadioButtonSelectionCommand(this);
        }
        private void GenerateRandomDataSet()
        {
            Util.GenerateRandomDataSet(Min, Max, DataSetSize, ref _unsortedDataSet);
        }

        private void ReArrangeDataSet()
        {
            var tempList = UnsortedDataSet.ToList();
            tempList.Sort();
            UnsortedDataSet.Clear();
            switch (ComplexityCase)
            {
                case ComplexityCase.BestCase:
                    // already sorted
                    break;
                case ComplexityCase.WorstCase:
                    tempList.Reverse();
                    break;
                case ComplexityCase.AverageCase:
                default:
                    // mix first and last
                    (tempList[0], tempList[^1]) = (tempList[^1], tempList[0]);
                    break;
            }
            foreach (var item in tempList)
            {
                UnsortedDataSet.Add(item);
            }
        }
        #endregion helpers
    }
}