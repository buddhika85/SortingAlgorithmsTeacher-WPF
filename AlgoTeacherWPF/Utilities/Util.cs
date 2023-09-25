using System;
using System.Collections.ObjectModel;

namespace AlgoTeacherWPF.Utilities
{
    public static class Util
    {
        public static void GenerateRandomDataSet(int min, int max, int datSetSize, ref ObservableCollection<int> unsortedDataSet)
        {
            Random rnd = new();
            unsortedDataSet.Clear();
            for (var i = 0; i < datSetSize; i++)
            {
                unsortedDataSet.Add(rnd.Next(min, max + 1));
            }
        }
    }
}
