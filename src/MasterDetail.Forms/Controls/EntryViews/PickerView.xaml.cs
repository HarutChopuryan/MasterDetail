using System.Collections;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MasterDetail.Forms.Controls.EntryViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PickerView
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

        public static readonly BindableProperty ItemsSourceProperty =
            BindableProperty.Create(nameof(ItemsSource),
                typeof(IList),
                typeof(PickerView),
                null,
                BindingMode.TwoWay);

        public static readonly BindableProperty SelectedItemProperty =
            BindableProperty.Create(nameof(SelectedItem),
                typeof(object),
                typeof(PickerView),
                null,
                BindingMode.TwoWay);

        public static readonly BindableProperty SelectedIndexProperty =
            BindableProperty.Create(nameof(SelectedIndex),
                typeof(int),
                typeof(PickerView),
                -1,
                BindingMode.TwoWay);

        private BindingBase _itemDisplayBinding;

        public PickerView()
        {
            InitializeComponent();
            Picker.SetBinding(Picker.ItemsSourceProperty,
                new Binding(ItemsSourceProperty.PropertyName, BindingMode.TwoWay, source: this));
            Picker.SetBinding(Picker.SelectedItemProperty,
                new Binding(SelectedItemProperty.PropertyName, BindingMode.TwoWay, source: this));
            Picker.SetBinding(Picker.SelectedIndexProperty,
                new Binding(SelectedIndexProperty.PropertyName, BindingMode.TwoWay, source: this));
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

        public IList ItemsSource
        {
            get => (IList) GetValue(ItemsSourceProperty);
            set => SetValue(ItemsSourceProperty, value);
        }

        public object SelectedItem
        {
            get => GetValue(SelectedItemProperty);
            set => SetValue(SelectedItemProperty, value);
        }

        public int SelectedIndex
        {
            get => (int) GetValue(SelectedIndexProperty);
            set => SetValue(SelectedIndexProperty, value);
        }

        public BindingBase ItemDisplayBinding
        {
            get => _itemDisplayBinding;
            set
            {
                if (_itemDisplayBinding != value)
                {
                    _itemDisplayBinding = value;
                    Picker.ItemDisplayBinding = value;
                }
            }
        }
    }
}