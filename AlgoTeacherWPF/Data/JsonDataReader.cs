using AlgoTeacherWPF.Model;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace AlgoTeacherWPF.Data
{
    public static class JsonDataReader
    {
        private static readonly JsonSerializerOptions Options = new()
        {
            WriteIndented = true
        };

        private static IList<Algorithm>? _algorithmList = new List<Algorithm>();

        static JsonDataReader()
        {
            DeserializeJson();
        }

        public static IList<Algorithm>? GetAlgorithms()
        {
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
