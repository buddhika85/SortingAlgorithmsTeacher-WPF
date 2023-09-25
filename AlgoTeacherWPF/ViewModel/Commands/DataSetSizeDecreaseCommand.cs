namespace AlgoTeacherWPF.ViewModel.Commands
{
    public class DataSetSizeDecreaseCommand : BaseCommand
    {
        public AlgorithmDetailViewModel ViewModel { get; set; }

        public DataSetSizeDecreaseCommand(AlgorithmDetailViewModel viewModel)
        {
            ViewModel = viewModel;
        }

        public override bool CanExecute(object? parameter)
        {
            return true;
        }

        public override void Execute(object? parameter)
        {
            ViewModel.DataSetSizeDecrease();
        }
    }
}
