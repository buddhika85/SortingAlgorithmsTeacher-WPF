using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace AlgoTeacherWPF.ViewModel
{
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion INotifyPropertyChanged

        protected void ShowInfoMessageBox(string message, string header = "Info")
        {
            MessageBox.Show(message, header, MessageBoxButton.OK, MessageBoxImage.Information, MessageBoxResult.OK);
        }

        protected void ShowSuccessMessageBox(string message, string header = "Success")
        {
            MessageBox.Show(message, header, MessageBoxButton.OK, MessageBoxImage.Asterisk, MessageBoxResult.OK);
        }

        protected void ShowErrorMessageBox(string message, string header = "Error")
        {
            MessageBox.Show(message, header, MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK);
        }
    }
}
