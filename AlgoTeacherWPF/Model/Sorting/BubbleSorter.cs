using AlgoTeacherWPF.ViewModel;
using System.Threading.Tasks;

namespace AlgoTeacherWPF.Model.Sorting
{
    public class BubbleSorter : AbstractSorter
    {

        public async Task Sort(AlgorithmDetailViewModel algorithmDetailViewModel)
        {
            await Task.Run(() =>
            {
                ResetSortResult(algorithmDetailViewModel);
                AddSortStartEndMessage(algorithmDetailViewModel, true);
                AddCurrentDataSetLogMessage(algorithmDetailViewModel);

                var swapInterval = GetSwapInterval(algorithmDetailViewModel.SortSpeed);
                for (var round = 0; round < algorithmDetailViewModel.SortedDataSet.Count - 1; round++)
                {
                    for (var i = 0; i < algorithmDetailViewModel.SortedDataSet.Count - round - 1; i++)
                    {
                        AddComparisonLogMessage(algorithmDetailViewModel, i);
                        ++algorithmDetailViewModel.SortResultModel.Comparisons;
                        ++algorithmDetailViewModel.SortResultModel.TotalOperations;

                        if (algorithmDetailViewModel.SortedDataSet[i].Number > algorithmDetailViewModel.SortedDataSet[i + 1].Number)
                        {
                            AddSwapLogMessage(algorithmDetailViewModel, i);
                            Swap(algorithmDetailViewModel, i, i + 1, swapInterval);
                            AddCurrentDataSetLogMessage(algorithmDetailViewModel);
                            ++algorithmDetailViewModel.SortResultModel.Swaps;
                            ++algorithmDetailViewModel.SortResultModel.TotalOperations;
                        }
                        else
                        {
                            // no swap 
                            AddNoSwapLogMessage(algorithmDetailViewModel, i);
                        }
                    }
                }

                AddSortStartEndMessage(algorithmDetailViewModel, false);
            });
        }
    }
}
