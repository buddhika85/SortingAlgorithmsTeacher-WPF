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

    }
}
