using AlgoTeacherWPF.Data;
using AlgoTeacherWPF.Model;
using AlgoTeacherWPF.View;
using AlgoTeacherWPF.ViewModel.Commands;
using System.Collections.Generic;
using System.Linq;

namespace AlgoTeacherWPF.ViewModel
{
    public class MainWindowViewModel : BaseViewModel
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
            var selectedAlgorithm = GetSelectedAlgorithm(algorithmId);
            if (selectedAlgorithm == null)
                return;
            new AlgorithmDetailWindow(selectedAlgorithm).Show();
        }

        private Algorithm? GetSelectedAlgorithm(int algorithmId)
        {
            return _algorithms?.FirstOrDefault(x => x.Id == algorithmId);
        }
    }
}
