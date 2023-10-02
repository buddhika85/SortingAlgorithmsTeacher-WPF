﻿using AlgoTeacherWPF.Model;
using AlgoTeacherWPF.Model.Enums;
using AlgoTeacherWPF.Utilities;
using AlgoTeacherWPF.ViewModel.Commands;
using System;
using System.Collections.ObjectModel;

namespace AlgoTeacherWPF.ViewModel
{
    public class AlgorithmDetailViewModel : BaseViewModel
    {
        private const int InitialDatSetSize = 5;
        private const int Min = -5;
        private const int Max = 100;
        private const bool DefaultCanRepeat = false;
        private const SortSpeed DefaultSortSpeed = SortSpeed.ThreeX;
        private const ComplexityCase DefaultComplexityCase = ComplexityCase.WorstCase;

        internal readonly int MinDataSetSize = 2;      // made these internal to access from command class
        internal readonly int MaxDataSetSize = 10;

        public Algorithm Algorithm { get; init; }

        #region commands

        public DataSetSizeIncreaseCommand DataSetSizeIncreaseCommand { get; set; } = null!;
        public DataSetSizeDecreaseCommand DataSetSizeDecreaseCommand { get; set; } = null!;
        public CaseRadioButtonSelectionCommand CaseRadioButtonSelectionCommand { get; set; } = null!;
        public CanRepeatCommand CanRepeatCommand { get; set; } = null!;
        public SortCommand SortCommand { get; set; } = null!;
        public ResetCommand ResetCommand { get; set; } = null!;
        public SelectSortSpeedCommand SelectSortSpeedCommand { get; set; } = null!;
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

        private ComplexityCase _complexityCase = DefaultComplexityCase;

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


        #region canRepeatRadioButtons

        private bool _canRepeatYes;

        public bool CanRepeatYes
        {
            get => _canRepeatYes;
            set
            {
                _canRepeatYes = value;
                OnPropertyChanged(nameof(CanRepeatYes));
            }
        }

        private bool _canRepeatNo;

        public bool CanRepeatNo
        {
            get => _canRepeatNo;
            set
            {
                _canRepeatNo = value;
                OnPropertyChanged(nameof(CanRepeatNo));
            }
        }

        #endregion canRepeatRadioButtons

        #region speedRadioButtons

        private SortSpeed _sortSpeed = DefaultSortSpeed;

        public SortSpeed SortSpeed
        {
            get => _sortSpeed;
            set
            {
                _sortSpeed = value;
                OnPropertyChanged(nameof(SortSpeed));
                SetSpeedRadioButtonSelection();
            }
        }

        private bool _isOneX;

        public bool IsOneX
        {
            get => _isOneX;
            set
            {
                _isOneX = value;
                OnPropertyChanged(nameof(IsOneX));
            }
        }

        private bool _isTwoX;

        public bool IsTwoX
        {
            get => _isTwoX;
            set
            {
                _isTwoX = value;
                OnPropertyChanged(nameof(IsTwoX));
            }
        }

        private bool _isThreeX = true;      // default this is selected

        public bool IsThreeX
        {
            get => _isThreeX;
            set
            {
                _isThreeX = value;
                OnPropertyChanged(nameof(IsThreeX));
            }
        }

        private bool _isFourX;

        public bool IsFourX
        {
            get => _isFourX;
            set
            {
                _isFourX = value;
                OnPropertyChanged(nameof(IsFourX));
            }
        }

        private bool _isFiveX;

        public bool IsFiveX
        {
            get => _isFiveX;
            set
            {
                _isFiveX = value;
                OnPropertyChanged(nameof(IsFiveX));
            }
        }

        #endregion speedRadioButtons


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
            SetCanRepeat(DefaultCanRepeat);

            SetupCommands();
        }

        // This constructor will be invoked when MainView algorithm selection button gets clicked
        public AlgorithmDetailViewModel(Algorithm algorithm)
        {
            Algorithm = algorithm;
            GenerateRandomDataSet();
            SetCanRepeat(DefaultCanRepeat);

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
        public void SetCanRepeat(bool canRepeat)
        {
            if (canRepeat)
            {
                CanRepeatYes = true;
                CanRepeatNo = false;
            }
            else
            {
                CanRepeatNo = true;
                CanRepeatYes = false;
            }
        }

        public void SetSortSpeed(SortSpeed sortSpeed)
        {
            SortSpeed = sortSpeed;
        }

        #region helpers


        private void SetupCommands()
        {
            DataSetSizeIncreaseCommand = new DataSetSizeIncreaseCommand(this);
            DataSetSizeDecreaseCommand = new DataSetSizeDecreaseCommand(this);
            CaseRadioButtonSelectionCommand = new CaseRadioButtonSelectionCommand(this);
            CanRepeatCommand = new CanRepeatCommand(this);
            SortCommand = new SortCommand(this);
            ResetCommand = new ResetCommand(this);
            SelectSortSpeedCommand = new SelectSortSpeedCommand(this);
        }
        private void GenerateRandomDataSet()
        {
            Util.GenerateRandomDataSet(Min, Max, DataSetSize, ComplexityCase, ref _unsortedDataSet);
            if (CanRepeatYes)
                ReArrangeDataSetToRepeats();
        }

        private void ReArrangeDataSet()
        {
            Util.ReArrangeDataSet(ComplexityCase, ref _unsortedDataSet);
        }

        private void ReArrangeDataSetToRepeats()
        {
            Util.ReArrangeDataSetToRepeats(ref _unsortedDataSet);
        }

        #endregion helpers

        public void Sort()
        {
            ShowSuccessMessageBox($"Sort: {Algorithm.Name}" +
                                  $"{Environment.NewLine}Size:{DataSetSize}" +
                                  $"{Environment.NewLine}CanRepeat:{CanRepeatYes}" +
                                  $"{Environment.NewLine}Case:{ComplexityCase}" +
                                  $"{Environment.NewLine}Speed:{SortSpeed}");
        }

        public void Reset()
        {
            ShowInfoMessageBox("Reset");
            DataSetSize = InitialDatSetSize;
            SetCanRepeat(DefaultCanRepeat);
            SetSortSpeed(DefaultSortSpeed);
            GenerateRandomDataSet();
        }


        private void SetSpeedRadioButtonSelection()
        {
            switch (SortSpeed)
            {
                case SortSpeed.OneX:
                    IsOneX = true;
                    IsTwoX = false;
                    IsThreeX = false;
                    IsFourX = false;
                    IsFiveX = false;
                    break;
                case SortSpeed.TwoX:
                    IsOneX = false;
                    IsTwoX = true;
                    IsThreeX = false;
                    IsFourX = false;
                    IsFiveX = false;
                    break;
                case SortSpeed.FourX:
                    IsOneX = false;
                    IsTwoX = false;
                    IsThreeX = false;
                    IsFourX = true;
                    IsFiveX = false;
                    break;
                case SortSpeed.FiveX:
                    IsOneX = false;
                    IsTwoX = false;
                    IsThreeX = false;
                    IsFourX = false;
                    IsFiveX = true;
                    break;
                case SortSpeed.ThreeX:
                default:
                    IsOneX = false;
                    IsTwoX = false;
                    IsThreeX = true;
                    IsFourX = false;
                    IsFiveX = false;
                    break;
            }
        }

    }
}