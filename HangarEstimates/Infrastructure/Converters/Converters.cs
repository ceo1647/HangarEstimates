using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Data;
using HangarEstimates.Domain;

namespace HangarEstimates.Infrastructure.Converters
{
    public class LenghtConverter : MarkupConverterBase<LenghtConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var dval = (double) value;
            return string.Format("L = {0}", dval);
        }
    }

    public class WidthConverter : MarkupConverterBase<WidthConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var dval = (double)value;
            return string.Format("B = {0}", dval);
        }
    }

    public class HeightConverter : MarkupConverterBase<HeightConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var dval = (double)value;
            return string.Format("H = {0}", dval);
        }
    }

    //public class ClientConverter : MultiValueMarkupConverterBase<ClientConverter>
    //{
    //    public override object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
    //    {
    //        if (values == null)
    //            return string.Empty;

    //        if (values.Length == 0)
    //            return string.Empty;

    //        var name = values[0].ToString();

    //        var contacts = values[1] as IEnumerable<Contact>;
    //        if (contacts == null || !contacts.Any())
    //            return name;

    //        return string.Format("{0}\r\nКонтакты:{1}", name, String.Join(";\r\n", contacts.Select(x => string.Format("{0}, тел. {1}", x.Name, x.PhoneNumber))));
    //    }
    //}

    public class ClientNameConverter : MarkupConverterBase<ClientNameConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var client = value as Client;
            if (client != null)
            {
                return string.Format("{0}{1}", client.Name, client.Contacts.Any() ?  "\r\nКонтакты: " + String.Join(";\r\n", client.Contacts.Select(x => string.Format("{0}, тел. {1}", x.Name, x.PhoneNumber))) : string.Empty);
            }

            return string.Empty;
        }
    }

}
