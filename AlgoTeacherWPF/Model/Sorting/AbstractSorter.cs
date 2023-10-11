using AlgoTeacherWPF.Model.Enums;
using AlgoTeacherWPF.ViewModel;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AlgoTeacherWPF.Model.Sorting
{
    public abstract class AbstractSorter : ObservableModel
    {
        protected const int SwapIntervalOneX = 4000;
        protected const int SwapIntervalTwoX = 3000;
        protected const int SwapIntervalThreeX = 2000;
        protected const int SwapIntervalFourX = 1000;
        protected const int SwapIntervalFiveX = 100;

        protected int SwapInterval = SwapIntervalThreeX;

        public abstract Task Sort(AlgorithmDetailViewModel algorithmDetailViewModel);

        protected virtual void SetupSortData(AlgorithmDetailViewModel algorithmDetailViewModel)
        {
            ResetSortResult(algorithmDetailViewModel);
            AddSortStartEndMessage(algorithmDetailViewModel, true);
            AddCurrentDataSetLogMessage(algorithmDetailViewModel);
            SetSwapInterval(algorithmDetailViewModel.SortSpeed);
        }

        protected virtual void AddSortStartEndMessage(AlgorithmDetailViewModel algorithmDetailViewModel, bool isStart)
        {
            algorithmDetailViewModel.SortResultModel.AddLogMessage(new SortingLogMessage
            {
                IsSwap = false,
                IsComparison = false,
                SortLogMessageType = isStart ? SortLogMessageType.SortStartMessage : SortLogMessageType.SortCompleteMessage,
                Id = ++algorithmDetailViewModel.SortResultModel.LastLogMessageId,
                Message = isStart ?
                    $"{algorithmDetailViewModel.Algorithm.Name} Starts." :
                    $"{algorithmDetailViewModel.Algorithm.Name} Completed"

            });
        }

        protected virtual void AddCurrentDataSetLogMessage(AlgorithmDetailViewModel algorithmDetailViewModel)
        {
            algorithmDetailViewModel.SortResultModel.AddLogMessage(new SortingLogMessage
            {
                IsSwap = false,
                IsComparison = false,
                SortLogMessageType = SortLogMessageType.NormalMessage,
                Id = ++algorithmDetailViewModel.SortResultModel.LastLogMessageId,
                Message =
                    $"Now Data set looks like - {string.Join(", ", algorithmDetailViewModel.SortedDataSet.Select(x => x.Number))}"
            });
        }

        protected virtual void AddNormalLogMessage(AlgorithmDetailViewModel algorithmDetailViewModel, string message)
        {
            algorithmDetailViewModel.SortResultModel.AddLogMessage(new SortingLogMessage
            {
                IsSwap = false,
                IsComparison = false,
                SortLogMessageType = SortLogMessageType.NormalMessage,
                Id = ++algorithmDetailViewModel.SortResultModel.LastLogMessageId,
                Message = message
            });
        }

        protected virtual void AddNoSwapLogMessage(AlgorithmDetailViewModel algorithmDetailViewModel, int left)
        {
            algorithmDetailViewModel.SortResultModel.AddLogMessage(new SortingLogMessage
            {
                IsSwap = false,
                IsComparison = false,
                SortLogMessageType = SortLogMessageType.NonSwapMessage,
                Id = ++algorithmDetailViewModel.SortResultModel.LastLogMessageId,
                Message =
                    $"No swap. Because  {algorithmDetailViewModel.SortedDataSet[left].Number} <= {algorithmDetailViewModel.SortedDataSet[left + 1].Number}"
            });
        }

        protected virtual void AddNoSwapLogMessage(AlgorithmDetailViewModel algorithmDetailViewModel)
        {
            algorithmDetailViewModel.SortResultModel.AddLogMessage(new SortingLogMessage
            {
                IsSwap = false,
                IsComparison = false,
                SortLogMessageType = SortLogMessageType.NonSwapMessage,
                Id = ++algorithmDetailViewModel.SortResultModel.LastLogMessageId,
                Message = "No swap."
            });
        }

        protected virtual void AddSwapLogMessage(AlgorithmDetailViewModel algorithmDetailViewModel, int left)
        {
            algorithmDetailViewModel.SortResultModel.AddLogMessage(new SortingLogMessage
            {
                IsSwap = true,
                IsComparison = false,
                SortLogMessageType = SortLogMessageType.SwapMessage,
                Id = ++algorithmDetailViewModel.SortResultModel.LastLogMessageId,
                Message =
                    $"Swapping {algorithmDetailViewModel.SortedDataSet[left].Number} and {algorithmDetailViewModel.SortedDataSet[left + 1].Number}," +
                    $"Because  {algorithmDetailViewModel.SortedDataSet[left].Number} > {algorithmDetailViewModel.SortedDataSet[left + 1].Number}"
            });
        }

        protected virtual void AddSwapLogMessage(AlgorithmDetailViewModel algorithmDetailViewModel, int left, int right)
        {
            algorithmDetailViewModel.SortResultModel.AddLogMessage(new SortingLogMessage
            {
                IsSwap = true,
                IsComparison = false,
                SortLogMessageType = SortLogMessageType.SwapMessage,
                Id = ++algorithmDetailViewModel.SortResultModel.LastLogMessageId,
                Message =
                    $"Swapping {algorithmDetailViewModel.SortedDataSet[left].Number} and {algorithmDetailViewModel.SortedDataSet[right].Number}," +
                    $"Because  {algorithmDetailViewModel.SortedDataSet[left].Number} > {algorithmDetailViewModel.SortedDataSet[right].Number}"
            });
        }

        protected virtual void AddComparisonLogMessage(AlgorithmDetailViewModel algorithmDetailViewModel, int index)
        {
            algorithmDetailViewModel.SortResultModel.AddLogMessage(new SortingLogMessage
            {
                IsComparison = true,
                IsSwap = false,
                SortLogMessageType = SortLogMessageType.ComparisonMessage,
                Id = ++algorithmDetailViewModel.SortResultModel.LastLogMessageId,
                Message =
                    $"Comparing {algorithmDetailViewModel.SortedDataSet[index].Number} and {algorithmDetailViewModel.SortedDataSet[index + 1].Number}"
            });
        }

        protected virtual void ResetSortResult(AlgorithmDetailViewModel algorithmDetailViewModel)
        {
            algorithmDetailViewModel.SortResultModel.Comparisons = 0;
            algorithmDetailViewModel.SortResultModel.Swaps = 0;
            algorithmDetailViewModel.SortResultModel.TotalOperations = 0;
        }

        protected virtual void Swap(AlgorithmDetailViewModel algorithmDetailViewModel, int left, int right)
        {

            algorithmDetailViewModel.SortedDataSet[left].BackgroundColor = "#ADD8E6";                                               // color what is about to be swapped
            algorithmDetailViewModel.SortedDataSet[right].BackgroundColor = "#ADD8E6";                                              // color what is about to be swapped
            algorithmDetailViewModel.SortedDataSet[left].IsRightArrowVisible = true;                                                // show arrow

            Pause(2);                                                                                                               // wait half of swap interval
            (algorithmDetailViewModel.SortedDataSet[left].Number, algorithmDetailViewModel.SortedDataSet[right].Number) =
                (algorithmDetailViewModel.SortedDataSet[right].Number, algorithmDetailViewModel.SortedDataSet[left].Number);        // swap
            algorithmDetailViewModel.SortedDataSet[left].IsRightArrowVisible = false;                                               // hide arrow

            Pause(2);                                                                                                               // wait half of swap interval

            algorithmDetailViewModel.SortedDataSet[left].BackgroundColor = "Transparent";                                           // un color after swapping
            algorithmDetailViewModel.SortedDataSet[right].BackgroundColor = "Transparent";                                          // un color after swapping

            algorithmDetailViewModel.SetupSortVisualizationChartViewModel();
        }

        protected virtual void SetSwapInterval(SortSpeed speed)
        {
            SwapInterval = speed switch
            {
                SortSpeed.OneX => SwapIntervalOneX,
                SortSpeed.TwoX => SwapIntervalTwoX,
                SortSpeed.ThreeX => SwapIntervalThreeX,
                SortSpeed.FourX => SwapIntervalFourX,
                SortSpeed.FiveX => SwapIntervalFiveX,
                _ => throw new ArgumentOutOfRangeException(nameof(speed), speed,
                    $"Error - unidentified swap interval {speed}")
            };
        }

        protected void Pause(int divisionFactor = 0)
        {
            if (divisionFactor <= 0)
                Thread.Sleep(SwapInterval);
            else
                Thread.Sleep(SwapInterval / divisionFactor);
        }
    }
}
