using AlgoTeacherWPF.Model;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace AlgoTeacherWPF.Data
{
    public class JsonDataReader
    {
        private static readonly JsonSerializerOptions Options = new()
        {
            WriteIndented = true
        };

        private static IList<Algorithm> _algorithmList = new List<Algorithm>();

        public static IList<Algorithm> GetAlgorithms()
        {
            if (!_algorithmList.Any())
                DeserializeJson();
            return _algorithmList;
        }

        private static void DeserializeJson()
        {
            var jsonString = File.ReadAllText(App.JsonFilePath);
            var list = JsonSerializer.Deserialize<List<Algorithm>>(jsonString, Options);
            if (list != null)
                _algorithmList = list;
        }
    }
}
