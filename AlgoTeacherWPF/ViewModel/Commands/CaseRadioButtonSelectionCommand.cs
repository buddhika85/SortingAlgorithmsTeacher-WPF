using AlgoTeacherWPF.Model.Enums;

namespace AlgoTeacherWPF.ViewModel.Commands
{
    public class CaseRadioButtonSelectionCommand : BaseCommand
    {
        public AlgorithmDetailViewModel ViewModel { get; set; }

        public CaseRadioButtonSelectionCommand(AlgorithmDetailViewModel viewModel)
        {
            ViewModel = viewModel;
        }

        public override bool CanExecute(object? parameter)
        {
            return true;
        }

        public override void Execute(object? parameter)
        {
            if (parameter is null)
                return;

            switch (parameter.ToString())
            {
                case "Best":
                    ViewModel.SetComplexityCase(ComplexityCase.BestCase);
                    break;
                case "Worst":
                    ViewModel.SetComplexityCase(ComplexityCase.WorstCase);
                    break;
                default:
                    ViewModel.SetComplexityCase(ComplexityCase.AverageCase);
                    break;
            }
        }
    }
}
