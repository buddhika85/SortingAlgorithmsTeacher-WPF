namespace AlgoTeacherWPF.ViewModel.Commands
{
    public class ResetCommand : BaseCommand
    {
        public AlgorithmDetailViewModel ViewModel { get; set; }

        public ResetCommand(AlgorithmDetailViewModel viewModel)
        {
            ViewModel = viewModel;
        }

        public override bool CanExecute(object? parameter)
        {
            return true;
        }

        public override void Execute(object? parameter)
        {
            ViewModel.Reset();
        }
    }
}
