using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using ReactiveValidation;


namespace Kontragent.ViewModel
{
    /// <summary>
    /// Это некий класс сборщик, который будет содержать все необходимые свойства и методы необходимые для работы с валидацией.
    /// </summary>
     public class BaseViewModel : ValidatableObject, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
