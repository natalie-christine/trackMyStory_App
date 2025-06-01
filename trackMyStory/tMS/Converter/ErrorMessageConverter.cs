using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tMS.Converter
{
    public class ErrorMessageConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            var error = value?.ToString();
            return error switch
            {
                "UserBadPhoneNumber" => "Das ist keine gültige E-Mail Adresse!",
                "UserBadLogin" => "Die Login-Daten sind nicht gültig!",
                _ => error,
            };
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
