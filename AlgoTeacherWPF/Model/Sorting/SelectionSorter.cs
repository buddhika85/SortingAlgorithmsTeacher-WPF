using AlgoTeacherWPF.Model.Enums;
using AlgoTeacherWPF.ViewModel;
using System.Threading.Tasks;

namespace AlgoTeacherWPF.Model.Sorting
{
    public class SelectionSorter : AbstractSorter
    {
        public override async Task Sort(AlgorithmDetailViewModel algorithmDetailViewModel)
        {
            await Task.Run(() =>
            {
                SetupSortData(algorithmDetailViewModel);

                for (var round = 0; round < algorithmDetailViewModel.SortedDataSet.Count - 1; round++)
                {

                    var minIndex = round;       // assume the min index
                    AddNormalLogMessage(algorithmDetailViewModel,
                        $"Round {round + 1}, min index is assumed as {minIndex} and it has value {algorithmDetailViewModel.SortedDataSet[minIndex].Number}");
                    for (var i = round + 1; i < algorithmDetailViewModel.SortedDataSet.Count; i++)
                    {
                        AddComparisonLogMessage(algorithmDetailViewModel, minIndex, i);
                        if (algorithmDetailViewModel.SortedDataSet[i].Number <
                            algorithmDetailViewModel.SortedDataSet[minIndex].Number)
                        {
                            AddNormalLogMessage(algorithmDetailViewModel,
                                $"Round {round + 1}, new min index ({i}) found. " +
                                $"Min index value {algorithmDetailViewModel.SortedDataSet[i].Number}");
                            // new min index is found
                            minIndex = i;
                        }
                    }


                    if (round != minIndex)
                    {
                        AddNormalLogMessage(algorithmDetailViewModel,
                            $"Round {round + 1}, Final min index ({minIndex}) is different from original min index {round}. So, they will be swapped." +
                            $"Min index value {algorithmDetailViewModel.SortedDataSet[minIndex].Number}");
                        AddSwapLogMessage(algorithmDetailViewModel, round, minIndex);
                        // rounds index is not in correct place, there is min value/min index
                        // swap - round index with min index
                        Swap(algorithmDetailViewModel, round, minIndex, SwapInterval);
                    }
                    else
                    {
                        // round index is in the correct place
                        AddNormalLogMessage(algorithmDetailViewModel,
                            $"Round {round + 1}, No new min index found.");
                        // no swap
                        AddNoSwapLogMessage(algorithmDetailViewModel);
                    }

                    AddNormalLogMessage(algorithmDetailViewModel,
                        $"Round {round + 1}, completed.");
                    AddCurrentDataSetLogMessage(algorithmDetailViewModel);
                }

                AddSortStartEndMessage(algorithmDetailViewModel, false);
            });
        }

        // overloaded
        protected void AddComparisonLogMessage(AlgorithmDetailViewModel algorithmDetailViewModel, int index, int minIndex)
        {
            algorithmDetailViewModel.SortResultModel.AddLogMessage(new SortingLogMessage
            {
                IsComparison = true,
                IsSwap = false,
                SortLogMessageType = SortLogMessageType.ComparisonMessage,
                Id = ++algorithmDetailViewModel.SortResultModel.LastLogMessageId,
                Message =
                    $"Comparing {algorithmDetailViewModel.SortedDataSet[minIndex].Number} and {algorithmDetailViewModel.SortedDataSet[index].Number}"
            });
        }
    }
}
