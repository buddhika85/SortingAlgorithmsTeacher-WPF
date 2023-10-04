using AlgoTeacherWPF.Model;
using LiveCharts;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace AlgoTeacherWPF.ViewModel
{
    public class SortVisualizationChartViewModel
    {
        public ChartValues<int> NumbersToSort { get; set; }
        public string[] NumberLabels { get; set; }
        private SortVisualizationChartViewModel()
        {
            NumbersToSort = new();
            NumberLabels = Array.Empty<string>();
        }

        public static SortVisualizationChartViewModel LoadViewModel(ObservableCollection<NumberModel> dataSet, Action<Task> onLoaded = null)
        {
            var viewModel = new SortVisualizationChartViewModel();
            viewModel.Load(dataSet).ContinueWith(t => onLoaded?.Invoke(t));
            return viewModel;
        }


        public async Task Load(ObservableCollection<NumberModel> dataSet)
        {
            await Task.Run(() =>
            {
                NumbersToSort = new ChartValues<int>(dataSet.Select(x => x.Number));
                NumberLabels = dataSet.Select(x => x.Number.ToString()).ToArray();
            });
        }
    }
}
