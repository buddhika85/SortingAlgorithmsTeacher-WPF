﻿namespace AlgoTeacherWPF.ViewModel.Commands
{
    public class SortCommand : BaseCommand
    {
        public AlgorithmDetailViewModel ViewModel { get; set; }

        public SortCommand(AlgorithmDetailViewModel viewModel)
        {
            ViewModel = viewModel;
        }

        public override bool CanExecute(object? parameter)
        {
            return true;
        }

        public override void Execute(object? parameter)
        {
            ViewModel.Sort();
        }
    }
}
