using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using MasterDetail.Core.Extensions;
using Xamarin.Forms;

namespace MasterDetail.Forms.Converters
{
    public class PlaceholderVisibilityConverter : IValueConverter
    {
        public virtual object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return IsVisible(value);
        }

        internal static bool IsVisible(object value)
        {
            bool isVisible;
            var item = (IEnumerable) value;
            isVisible = item?.Count() == 0;
            return isVisible;
        }

        public virtual object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
