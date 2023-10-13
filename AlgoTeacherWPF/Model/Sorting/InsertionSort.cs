using AlgoTeacherWPF.Model.Enums;
using AlgoTeacherWPF.ViewModel;
using System.Threading.Tasks;

namespace AlgoTeacherWPF.Model.Sorting
{
    public class InsertionSort : AbstractSorter
    {
        public override async Task Sort(AlgorithmDetailViewModel algorithmDetailViewModel)
        {
            await Task.Run(() =>
            {
                SetupSortData(algorithmDetailViewModel);

                for (var i = 1; i < algorithmDetailViewModel.SortedDataSet.Count; i++)
                {
                    var current = algorithmDetailViewModel.SortedDataSet[i].Number;
                    AddNormalLogMessage(algorithmDetailViewModel,
                        $"Current is in index {i} and it is {algorithmDetailViewModel.SortedDataSet[i].Number}");

                    Pause(2);           // half sleep interval pause

                    var j = i - 1;
                    var wasShifted = false;

                    AddNormalLogMessage(algorithmDetailViewModel,
                        $"Comparison index is {j} at this point");


                    while (j >= 0 && algorithmDetailViewModel.SortedDataSet[j].Number > current)
                    {
                        AddComparisonLogMessage(algorithmDetailViewModel, j, i);
                        Pause(2);           // half sleep interval pause

                        // shift left to right - to make space for current
                        algorithmDetailViewModel.SortedDataSet[j + 1].Number = algorithmDetailViewModel.SortedDataSet[j].Number;
                        AddCopyLogMessage(algorithmDetailViewModel,
                            $"Copy left (index {j}) value {algorithmDetailViewModel.SortedDataSet[j].Number} to (index {j + 1}) index");
                        AddCurrentDataSetLogMessage(algorithmDetailViewModel);

                        Pause();
                        wasShifted = true;
                        j--;
                    }

                    if (wasShifted)
                    {
                        AddNormalLogMessage(algorithmDetailViewModel,
                            $"At least one shifting (copying left to right) happened. Move {current} to its correct index which is {j + 1}");
                        algorithmDetailViewModel.SortedDataSet[j + 1].Number = current;

                    }
                    else
                    {
                        AddNormalLogMessage(algorithmDetailViewModel,
                            $"No shifting (copying left to right) happened. {current} is in the correct place as of now.");
                    }

                    Pause();
                }

                AddSortStartEndMessage(algorithmDetailViewModel, false);
                Pause();
            });
        }


        protected void AddComparisonLogMessage(AlgorithmDetailViewModel algorithmDetailViewModel, int j, int i)
        {
            algorithmDetailViewModel.SortResultModel.AddLogMessage(new SortingLogMessage
            {
                IsComparison = true,
                IsSwap = false,
                SortLogMessageType = SortLogMessageType.ComparisonMessage,
                Id = ++algorithmDetailViewModel.SortResultModel.LastLogMessageId,
                Message =
                    $"Comparing {algorithmDetailViewModel.SortedDataSet[j].Number} and {algorithmDetailViewModel.SortedDataSet[i].Number}"
            });
        }
    }
}
