using Xamarin.Forms;

namespace MasterDetail.Forms.Controls.EntryViews
{
    public class PickerEx : Picker
    {
        public static readonly BindableProperty HasErrorsProperty =
            BindableProperty.Create(nameof(HasErrors),
                typeof(bool),
                typeof(PickerEx),
                false);

        public bool HasErrors
        {
            get => (bool) GetValue(HasErrorsProperty);
            set => SetValue(HasErrorsProperty, value);
        }
    }
}