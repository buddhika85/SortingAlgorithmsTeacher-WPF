using AlgoTeacherWPF.Model.Enums;

namespace AlgoTeacherWPF.ViewModel.Commands
{
    public class SelectSortSpeedCommand : BaseCommand
    {
        public AlgorithmDetailViewModel ViewModel { get; set; }
        public SelectSortSpeedCommand(AlgorithmDetailViewModel viewModel)
        {
            ViewModel = viewModel;
        }

        public override bool CanExecute(object? parameter)
        {
            return true;
        }

        public override void Execute(object? parameter)
        {
            switch (parameter as string)
            {
                case "oneX": ViewModel.SetSortSpeed(SortSpeed.OneX); break;
                case "twoX": ViewModel.SetSortSpeed(SortSpeed.TwoX); break;
                case "fourX": ViewModel.SetSortSpeed(SortSpeed.FourX); break;
                case "fiveX": ViewModel.SetSortSpeed(SortSpeed.FiveX); break;
                default: ViewModel.SetSortSpeed(SortSpeed.ThreeX); break;
            }
        }
    }
}
