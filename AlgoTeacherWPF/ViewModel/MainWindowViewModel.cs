using AlgoTeacherWPF.Data;
using AlgoTeacherWPF.Model;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

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


        public MainWindowViewModel()
        {
            Algorithms = JsonDataReader.GetAlgorithms();
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
