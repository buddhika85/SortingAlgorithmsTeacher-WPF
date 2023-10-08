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
                for (var round = 0; round < algorithmDetailViewModel.SortedDataSet.Count - 1; round++)
                {
                    var minIndex = round;       // assume the min index
                    for (var i = round + 1; i < algorithmDetailViewModel.SortedDataSet.Count; i++)
                    {
                        if (algorithmDetailViewModel.SortedDataSet[i].Number <
                            algorithmDetailViewModel.SortedDataSet[minIndex].Number)
                        {
                            // new min index is found
                            minIndex = i;
                        }
                    }

                    if (round != minIndex)
                    {
                        // rounds index is not in correct place, there is min value/min index
                        // swap - round index with min index
                        Swap(algorithmDetailViewModel, round, minIndex, SwapInterval);
                    }
                    else
                    {
                        // round index is in the correct place
                        // no swap
                    }
                }
            });
        }
    }
}
