using AlgoTeacherWPF.Data;
using System.IO;
using System.Windows;

namespace AlgoTeacherWPF;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    public const string JsonFilePath =
        "D:\\buddhika\\work Projects\\SortingAlgorithmsTeacher-WPF\\AlgoTeacherWPF\\Data\\JsonFiles\\algorithms.json";

    public App()
    {
        if (!File.Exists(JsonFilePath))
            throw new FileNotFoundException(JsonFilePath);
    }

    private void Test()
    {
        var algorithms = JsonDataReader.GetAlgorithms();
        //Debug.WriteLine($"List of algorithms: {algorithms}");
    }
}