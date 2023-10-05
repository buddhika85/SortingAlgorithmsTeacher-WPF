using AlgoTeacherWPF.ViewModel;
using System.Windows;

namespace AlgoTeacherWPF.View
{
    /// <summary>
    /// Interaction logic for SortingLogMessagesWindow.xaml
    /// </summary>
    public partial class SortingLogMessagesWindow : Window
    {
        public SortingLogMessagesWindow(AlgorithmDetailViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}
