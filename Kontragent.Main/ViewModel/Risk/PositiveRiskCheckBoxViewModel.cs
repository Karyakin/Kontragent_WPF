using Kontragent.Helper;
using Kontragent.RiskInterface;


namespace Kontragent.ViewModel.Risk
{
    public class PositiveRiskCheckBoxViewModel : BaseViewModel, IPositiveRiskCheckBoxParametr
    {
        private bool _value;
        private int _risk;

        public PositiveRiskCheckBoxViewModel(int risk)
        {
            Risk = risk;
            RiskCalculator.Note(this);// this - передаем тип самого класса, который унаследовани от соответсвующего позитивного или негативного интерфейса и тамк студия понимает метод реализации калькулятора , т.к. в зависимости от позитивного или негативного (есть два конструктора с разной реализацией методов)
        }

        public bool Value
        {
            get => _value;
            set
            {
                _value = value;
                OnPropertyChanged(nameof(Value));
                RiskCalculator.Note(this);// this - передаем тип самого класса, который унаследовани от соответсвующего позитивного или негативного интерфейса и тамк студия понимает метод реализации калькулятора , т.к. в зависимости от позитивного или негативного (есть два конструктора с разной реализацией методов)
            }
        }

        public int Risk
        {
            get => _risk;
            set
            {
                _risk = value;
                OnPropertyChanged(nameof(Risk));
            }
        }
    }
}
