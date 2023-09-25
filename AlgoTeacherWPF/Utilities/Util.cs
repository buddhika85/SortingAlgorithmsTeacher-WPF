using AlgoTeacherWPF.Model.Enums;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace AlgoTeacherWPF.Utilities
{
    public static class Util
    {
        public static void GenerateRandomDataSet(int min, int max, int datSetSize, ComplexityCase complexityCase, ref ObservableCollection<int> unsortedDataSet)
        {
            var tempList = GetRandomIntList(min, max, datSetSize);
            tempList.Sort();
            ArrangeIntListByComplexityCase(complexityCase, tempList);
            PopulateObservableCollection(unsortedDataSet, tempList);
        }

        public static void ReArrangeDataSet(ComplexityCase complexityCase, ref ObservableCollection<int> unsortedDataSet)
        {
            var tempList = unsortedDataSet.ToList();
            tempList.Sort();
            ArrangeIntListByComplexityCase(complexityCase, tempList);
            PopulateObservableCollection(unsortedDataSet, tempList);
        }

        private static void PopulateObservableCollection(ObservableCollection<int> unsortedDataSet, List<int> tempList)
        {
            unsortedDataSet.Clear();
            foreach (var item in tempList)
            {
                unsortedDataSet.Add(item);
            }
        }

        private static void ArrangeIntListByComplexityCase(ComplexityCase complexityCase, List<int> tempList)
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

        private static List<int> GetRandomIntList(int min, int max, int datSetSize)
        {
            Random rnd = new();
            List<int> tempList = new();
            for (var i = 0; i < datSetSize; i++)
            {
                tempList.Add(rnd.Next(min, max + 1));
            }

            return tempList;
        }
    }
}
