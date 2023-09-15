using AlgoTeacherWPF.Data;
using AlgoTeacherWPF.Model;
using AlgoTeacherWPF.ViewModel.Commands;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace AlgoTeacherWPF.ViewModel
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private IList<Algorithm>? _algorithms;
        public IList<Algorithm>? Algorithms
        {
            get => _algorithms;
            set
            {
                _algorithms = value;
                OnPropertyChanged(nameof(Algorithms));
            }
        }

        public AlgorithmSelectionCommand AlgorithmSelectionCommand { get; set; }


        public MainWindowViewModel()
        {
            Algorithms = JsonDataReader.GetAlgorithms();
            AlgorithmSelectionCommand = new AlgorithmSelectionCommand(this);
        }


        public void OnAlgorithmSelectionClick(int algorithmId)
        {
            MessageBox.Show($"{algorithmId}");
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion INotifyPropertyChanged


    }
}
