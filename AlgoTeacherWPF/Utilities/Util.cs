using AlgoTeacherWPF.Model;
using AlgoTeacherWPF.Model.Enums;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace AlgoTeacherWPF.Utilities
{
    public static class Util
    {
        private const int OneRepeatCount = 5;
        private const int TwoRepeatCount = 8;
        public static void GenerateRandomDataSet(int min, int max, int datSetSize, ComplexityCase complexityCase, ref ObservableCollection<NumberModel> unsortedDataSet)
        {
            var tempList = GetRandomIntList(min, max, datSetSize).OrderBy(x => x.Number).ToList();

            ArrangeIntListByComplexityCase(complexityCase, tempList);
            PopulateObservableCollection(unsortedDataSet, tempList);
        }

        public static void ReArrangeDataSet(ComplexityCase complexityCase, ref ObservableCollection<NumberModel> unsortedDataSet)
        {
            var tempList = unsortedDataSet.ToList().OrderBy(x => x.Number).ToList();
            ArrangeIntListByComplexityCase(complexityCase, tempList);
            PopulateObservableCollection(unsortedDataSet, tempList);
        }

        public static void ReArrangeDataSetToRepeats(ref ObservableCollection<NumberModel> unsortedDataSet)
        {
            switch (unsortedDataSet.Count)
            {
                // index 1,2,3,4
                case <= OneRepeatCount:
                    unsortedDataSet[0] = unsortedDataSet[^1];       // index 0 = index last
                    break;
                // index 1,2,3,4,5,6,7
                case <= TwoRepeatCount:
                    unsortedDataSet[^1] = unsortedDataSet[2];       // index last = index two
                    unsortedDataSet[3] = unsortedDataSet[0];        // index three = index zero
                    break;
                default: // index 1,2,3,4,5,6,7
                    unsortedDataSet[0] = unsortedDataSet[^1];       // index 0 = index last
                    unsortedDataSet[5] = unsortedDataSet[2];        // index 0 = index last
                    unsortedDataSet[7] = unsortedDataSet[4];        // index 0 = index last
                    break;
            }
        }

        private static void PopulateObservableCollection(ObservableCollection<NumberModel> unsortedDataSet, List<NumberModel> tempList)
        {
            unsortedDataSet.Clear();
            foreach (var item in tempList)
            {
                unsortedDataSet.Add(item);
            }
        }

        private static void ArrangeIntListByComplexityCase(ComplexityCase complexityCase, List<NumberModel> tempList)
        {
            switch (complexityCase)
            {
                case ComplexityCase.BestCase:
                    // already sorted
                    break;
                case ComplexityCase.WorstCase:
                    tempList.Reverse();
                    break;
                case ComplexityCase.AverageCase:
                default:
                    // mix first and last
                    (tempList[0], tempList[^1]) = (tempList[^1], tempList[0]);
                    break;
            }
        }

        private static List<NumberModel> GetRandomIntList(int min, int max, int datSetSize)
        {
            Random rnd = new();
            List<NumberModel> tempList = new();
            for (var i = 0; i < datSetSize; i++)
            {
                tempList.Add(new NumberModel { Number = rnd.Next(min, max + 1) });
            }

            return tempList;
        }
    }
}
