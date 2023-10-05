namespace AlgoTeacherWPF.ViewModel.Commands
{
    public class LogWindowOpenCommand : BaseCommand
    {
        public AlgorithmDetailViewModel ViewModel { get; set; }

        public LogWindowOpenCommand(AlgorithmDetailViewModel viewModel)
        {
            ViewModel = viewModel;
        }
        public override bool CanExecute(object? parameter)
        {
            return true;
        }

        public override void Execute(object? parameter)
        {
            ViewModel.OpenLogMessagesWindow();
        }
    }
}
