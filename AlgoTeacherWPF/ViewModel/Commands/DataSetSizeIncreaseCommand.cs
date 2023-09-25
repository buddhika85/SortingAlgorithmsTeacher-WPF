namespace AlgoTeacherWPF.ViewModel.Commands
{
    public class DataSetSizeIncreaseCommand : BaseCommand
    {
        public AlgorithmDetailViewModel ViewModel { get; set; }

        public DataSetSizeIncreaseCommand(AlgorithmDetailViewModel viewModel)
        {
            ViewModel = viewModel;
        }

        public override bool CanExecute(object? parameter)
        {
            return true;
        }

        public override void Execute(object? parameter)
        {
            ViewModel.DataSetSizeIncrease();
        }
    }
}
