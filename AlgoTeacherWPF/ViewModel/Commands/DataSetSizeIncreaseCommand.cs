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
            if (parameter is not null && int.TryParse(parameter.ToString(), out var currentDataSetSize))
                return currentDataSetSize < ViewModel.MaxDataSetSize;
            return false;
        }

        public override void Execute(object? parameter)
        {
            ViewModel.DataSetSizeIncrease();
        }
    }
}
