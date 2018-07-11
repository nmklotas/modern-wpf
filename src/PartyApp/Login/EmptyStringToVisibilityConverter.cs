using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace SampleApp.Login
{
    internal class EmptyStringToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) 
            => string.IsNullOrEmpty((string) value) ? Visibility.Collapsed : Visibility.Visible;

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) 
            => throw new NotImplementedException();
    }
}