namespace AlgoTeacherWPF.Model
{
    public class NumberModel : ObservableModel
    {
        private int _number;

        public int Number
        {
            get => _number;
            set
            {
                _number = value;
                OnPropertyChanged(nameof(Number));
            }
        }



        private string _backgroundColor = "Transparent";

        public string BackgroundColor
        {
            get => _backgroundColor;
            set
            {
                _backgroundColor = value;
                OnPropertyChanged(nameof(BackgroundColor));
            }
        }

        private bool _isRightArrowVisible;

        public bool IsRightArrowVisible
        {
            get => _isRightArrowVisible;
            set
            {
                _isRightArrowVisible = value;
                OnPropertyChanged(nameof(IsRightArrowVisible));
            }
        }


    }
}
