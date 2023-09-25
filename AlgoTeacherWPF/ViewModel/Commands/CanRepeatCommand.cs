namespace AlgoTeacherWPF.ViewModel.Commands
{
    public class CanRepeatCommand : BaseCommand
    {
        private const string Yes = "Yes";
        private const string No = "No";

        public AlgorithmDetailViewModel ViewModel { get; set; }

        public CanRepeatCommand(AlgorithmDetailViewModel viewModel)
        {
            ViewModel = viewModel;
        }

        public override bool CanExecute(object? parameter)
        {
            return true;
        }

        public override void Execute(object? parameter)
        {
            if (parameter?.ToString() is null || parameter.ToString()!.Equals(No))
            {
                ViewModel.SetCanRepeat(false);
                return;
            }
            ViewModel.SetCanRepeat(true);
        }
    }
}
