using AlgoTeacherWPF.Model;
using AlgoTeacherWPF.ViewModel;
using System.Windows;

namespace AlgoTeacherWPF.View
{
    /// <summary>
    /// Interaction logic for AlgorithmDetailWindow.xaml
    /// </summary>
    public partial class AlgorithmDetailWindow : Window
    {

        public AlgorithmDetailWindow(Algorithm algorithm)
        {
            InitializeComponent();
            DataContext = new AlgorithmDetailViewModel(algorithm);
        }
    }
}
