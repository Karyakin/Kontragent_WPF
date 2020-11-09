using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Kontragent.Converters
{
    /// <summary>
    /// Данный метод конвертирует булевское значение для всплывающей подсказки
    /// </summary>
    public class BoolToStringErrorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            ///проверяем что в value нам пришло Bool, если value будет bool, то flag станет типом Bool и примет значение, которое
            ///придет из vlue
            ///данный конвертер вызывается из xaml явно
            if (value is bool flag)
            {
                if (flag == true)
                {
                    return "Сохранить";
                }
                return "Заполните все поля подсвеченные красным треугольником, после это кнопака станет активной";
            }
            return "";
        }
        /// Данный метод не нужен, но он должен быть чтобы реализовать интерфейс IValueConverter
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
