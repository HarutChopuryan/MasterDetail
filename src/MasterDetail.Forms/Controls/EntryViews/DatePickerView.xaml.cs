using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MasterDetail.Forms.Controls.EntryViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DatePickerView
    {
        public static readonly BindableProperty TitleProperty =
            BindableProperty.Create(nameof(Title),
                typeof(string),
                typeof(PickerView),
                null);

        public static readonly BindableProperty TitleWidthProperty =
            BindableProperty.Create(nameof(TitleWidth),
                typeof(double),
                typeof(PickerView),
                120d);

        public DatePickerView()
        {
            InitializeComponent();
        }

        public string Title
        {
            get => (string) GetValue(TitleProperty);
            set => SetValue(TitleProperty, value);
        }

        public double TitleWidth
        {
            get => (double) GetValue(TitleWidthProperty);
            set => SetValue(TitleWidthProperty, value);
        }
    }
}