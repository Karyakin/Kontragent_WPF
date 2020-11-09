using Kontragent.Helper;
using Kontragent.RiskInterface;


namespace Kontragent.ViewModel.Risk
{
    public class NegativeRiskCheckBoxViewModel : BaseViewModel, INegativeRiskCheckBoxParametr
    {
        private bool _value;
        private int _risk;

        public NegativeRiskCheckBoxViewModel(int risk)
        {
            Risk = risk;
            // Если раскрментировать это RiskCalculator.Note(this), то при загрузке формыбудут подсчитаны все негативные риски
            // и прогрессбар будет -37
            // RiskCalculator.Note(this);// this - передаем тип самого класса, который унаследовани от соответсвующего позитивного или негативного интерфейса и тамк студия понимает метод реализации калькулятора, т.к. в зависимости от позитивного или негативного (есть два конструктора с разной реализацией методов)
        }

        public bool Value
        {
            get => _value;
            set
            {
                _value = value;
                OnPropertyChanged(nameof(Value));
                RiskCalculator.Note(this);// this - передаем тип самого класса, который унаследовани от соответсвующего позитивного или негативного интерфейса и тамк студия понимает метод реализации калькулятора, т.к. в зависимости от позитивного или негативного (есть два конструктора с разной реализацией методов)
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
