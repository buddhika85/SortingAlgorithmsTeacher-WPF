using System;
using System.Windows.Input;

namespace AlgoTeacherWPF.ViewModel.Commands
{
    public class AlgorithmSelectionCommand : ICommand
    {
        private readonly MainWindowViewModel _mainWindowViewModel;

        public AlgorithmSelectionCommand(MainWindowViewModel mainWindowViewModel)
        {
            _mainWindowViewModel = mainWindowViewModel;
        }

        public bool CanExecute(object? parameter)
        {
            return parameter != null && int.TryParse(parameter.ToString(), out _);
        }

        public void Execute(object? parameter)
        {
            if (parameter == null)
                return;
            var algorithmId = (int)parameter;
            _mainWindowViewModel.OnAlgorithmSelectionClick(algorithmId);
        }

        public event EventHandler? CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }
    }
}
