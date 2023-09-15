namespace AlgoTeacherWPF.ViewModel.Commands
{
    public class AlgorithmSelectionCommand : BaseCommand
    {
        private readonly MainWindowViewModel _mainWindowViewModel;

        public AlgorithmSelectionCommand(MainWindowViewModel mainWindowViewModel)
        {
            _mainWindowViewModel = mainWindowViewModel;
        }

        public override bool CanExecute(object? parameter)
        {
            return parameter != null && int.TryParse(parameter.ToString(), out _);
        }

        public override void Execute(object? parameter)
        {
            if (parameter == null)
                return;
            var algorithmId = (int)parameter;
            _mainWindowViewModel.OnAlgorithmSelectionClick(algorithmId);
        }

    }
}
