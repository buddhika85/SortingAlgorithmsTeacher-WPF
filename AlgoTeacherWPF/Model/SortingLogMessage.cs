using AlgoTeacherWPF.Model.Enums;

namespace AlgoTeacherWPF.Model
{
    public class SortingLogMessage : ObservableModel
    {
        private int _id;
        public int Id
        {
            get => _id;
            set
            {
                _id = value;
                OnPropertyChanged(nameof(Id));
            }
        }

        private string _message = string.Empty;
        public string Message
        {
            get => _message;
            set
            {
                _message = value;
                OnPropertyChanged(nameof(Message));
            }
        }

        private string _txtColor = "WhiteSmoke";
        public string TxtColor
        {
            get => _txtColor;
            set
            {
                _txtColor = value;
                OnPropertyChanged(nameof(TxtColor));
            }
        }

        private bool _isComparison;
        public bool IsComparison
        {
            get => _isComparison;
            set
            {
                _isComparison = value;
                OnPropertyChanged(nameof(IsComparison));
            }
        }

        private bool _isSwap;
        public bool IsSwap
        {
            get => _isSwap;
            set
            {
                _isSwap = value;
                OnPropertyChanged(nameof(IsSwap));
            }
        }

        private SortLogMessageType _sortLogMessageType;

        public SortLogMessageType SortLogMessageType
        {
            get => _sortLogMessageType;
            set
            {
                _sortLogMessageType = value;
                OnPropertyChanged(nameof(SortLogMessageType));
            }
        }

    }
}
