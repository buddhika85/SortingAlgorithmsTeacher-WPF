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
            if (parameter is not null && int.TryParse(parameter.ToString(), out var currentDataSetSize))
                return currentDataSetSize > ViewModel.MinDataSetSize;
            return false;
        }

        public override void Execute(object? parameter)
        {
            ViewModel.DataSetSizeDecrease();
        }
    }
}
