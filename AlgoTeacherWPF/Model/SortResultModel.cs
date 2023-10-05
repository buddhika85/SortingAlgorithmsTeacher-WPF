using System;
using System.Collections.ObjectModel;
using System.Windows;

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

        private int _lastLogMessageId = 0;
        public int LastLogMessageId
        {
            get => _lastLogMessageId;
            set
            {
                _lastLogMessageId = value;
                OnPropertyChanged(nameof(_lastLogMessageId));
            }
        }

        private ObservableCollection<SortingLogMessage> _sortingLogMessages = new();

        public ObservableCollection<SortingLogMessage> SortingLogMessages
        {
            get => _sortingLogMessages;
            set
            {
                _sortingLogMessages = value;
                OnPropertyChanged(nameof(SortingLogMessages));
            }
        }

        public void AddLogMessage(SortingLogMessage sortingLogMessage)
        {
            Application.Current.Dispatcher.Invoke((Action)delegate
            {
                SortingLogMessages.Add(sortingLogMessage);
                OnPropertyChanged(nameof(SortingLogMessages));
            });
        }

        public void ClearLogMessages()
        {
            SortingLogMessages.Clear();
        }
    }
}
