using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MasterDetail.Forms.Controls.EntryViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FailureView
    {
        public static readonly BindableProperty MessageProperty =
            BindableProperty.Create(nameof(Message),
                typeof(string),
                typeof(FailureView),
                null);

        public static readonly BindableProperty TryAgainCommandProperty =
            BindableProperty.Create(nameof(TryAgainCommand),
                typeof(ICommand),
                typeof(FailureView),
                null);

        public FailureView()
        {
            InitializeComponent();
        }

        public string Message
        {
            get => (string) GetValue(MessageProperty);
            set => SetValue(MessageProperty, value);
        }

        public ICommand TryAgainCommand
        {
            get => (ICommand) GetValue(TryAgainCommandProperty);
            set => SetValue(TryAgainCommandProperty, value);
        }
    }
}