using Xamarin.Forms;

namespace MasterDetail.Forms.Controls.EntryViews
{
    public class DatePickerEx : DatePicker
    {
        public static readonly BindableProperty HasErrorsProperty =
            BindableProperty.Create(nameof(HasErrors),
                typeof(bool),
                typeof(DatePickerEx),
                false);

        public bool HasErrors
        {
            get => (bool) GetValue(HasErrorsProperty);
            set => SetValue(HasErrorsProperty, value);
        }
    }
}