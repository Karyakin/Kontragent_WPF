using Kontragent.Helper;
using Kontragent.RiskInterface;
using ReactiveValidation;
using ReactiveValidation.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kontragent.ViewModel.Risk
{
    public class RiskCreatedDateViewModel : BaseViewModel, IRiskCreatedDateParametr
    {
        private DateTime _value;
        private int _risk;

        private IObjectValidator GetValidator()
        {
            var organizationBuilder = new ValidationBuilder<RiskCreatedDateViewModel>();
            organizationBuilder.RuleFor(x => x.Value).LessThan(DateTime.Now).WithMessage("Укажите корректную дату");
            return organizationBuilder.Build(this/*методу нужна ЭТА ViewModel*/);// после созданных правил тут мы создаем саму инициализацию. Билдер сбилдся.
        }

        private RiskCreatedDateViewModel()
        {
            Validator = GetValidator();// без инициализации это свойство NULL.
            Value = DateTime.Now;
        }



        public RiskCreatedDateViewModel(int risk) : this()
        {
            Risk = risk;
            //RiskCalculator.Note(this);// this - передаем тип самого класса, который унаследовани от соответсвующего позитивного или негативного интерфейса и тамк студия понимает метод реализации калькулятора , т.к. в зависимости от позитивного или негативного (есть два конструктора с разной реализацией методов)
        }

        public DateTime Value
        {
            get => _value;
            set
            {
                _value = value;
                OnPropertyChanged(nameof(Value));
                // RiskCalculator.Note(this);// this - передаем тип самого класса, который унаследовани от соответсвующего позитивного или негативного интерфейса и тамк студия понимает метод реализации калькулятора , т.к. в зависимости от позитивного или негативного (есть два конструктора с разной реализацией методов)
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

