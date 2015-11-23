using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Windows.Markup;

namespace HangarEstimates.Infrastructure.Converters
{
    public abstract class MultiValueMarkupConverterBase<T> : MarkupExtension, IMultiValueConverter
        where T : class, new()
    {
        private static T _converter = null;

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            if (_converter == null)
                _converter = new T();
            return _converter;
        }

        public abstract object Convert(object[] values, Type targetType, object parameter, CultureInfo culture);
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
