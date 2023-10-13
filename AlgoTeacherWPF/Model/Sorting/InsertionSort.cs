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
                for (var i = 1; i < algorithmDetailViewModel.SortedDataSet.Count; i++)
                {
                    var current = algorithmDetailViewModel.SortedDataSet[i];
                    var j = i - 1;
                    var wasShifted = false;
                    while (j >= 0 && algorithmDetailViewModel.SortedDataSet[j].Number > current.Number)
                    {
                        // shift left to right - to make space for current
                        algorithmDetailViewModel.SortedDataSet[j + 1].Number = algorithmDetailViewModel.SortedDataSet[j].Number;
                        wasShifted = true;
                        j--;
                    }
                    if (wasShifted)
                        algorithmDetailViewModel.SortedDataSet[j + 1].Number = current.Number;
                }
            });
        }
    }
}
