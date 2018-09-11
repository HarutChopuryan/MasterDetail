using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MasterDetail.Forms.Controls.EntryViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BaseEntryView
    {
        //Title
        public static readonly BindableProperty TitleProperty =
            BindableProperty.Create(nameof(Title),
                typeof(string),
                typeof(BaseEntryView),
                null,
                propertyChanged: OnTitleChanged);

        public static readonly BindableProperty TitleWidthProperty =
            BindableProperty.Create(nameof(TitleWidth),
                typeof(double),
                typeof(BaseEntryView),
                120d);

        //ShowTitle
        public static readonly BindableProperty ShowTitleProperty =
            BindableProperty.Create(nameof(ShowTitle),
                typeof(bool),
                typeof(BaseEntryView),
                true,
                propertyChanged: OnShowTitleChanged);

        public static readonly BindableProperty ShowPlaceholderProperty =
            BindableProperty.Create(nameof(ShowPlaceholder),
                typeof(bool),
                typeof(BaseEntryView),
                true,
                propertyChanged: OnShowPlaceholderChanged);

        public BaseEntryView()
        {
            InitializeComponent();
            Initialize();
        }

        protected virtual ContentView ControlContainer => Container;

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

        public bool ShowTitle
        {
            get => (bool) GetValue(ShowTitleProperty);
            set => SetValue(ShowTitleProperty, value);
        }

        public bool ShowPlaceholder
        {
            get => (bool) GetValue(ShowPlaceholderProperty);
            set => SetValue(ShowPlaceholderProperty, value);
        }

        private static void OnTitleChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
            var entry = (BaseEntryView) bindable;
            var title = (string) newvalue;
            entry.TitleLabel.Text = title;
            entry.TitleLabel.IsVisible = !string.IsNullOrEmpty(title) && entry.ShowTitle;
            entry.UpdateTitle(title, entry.ShowPlaceholder);
        }

        private static void OnShowTitleChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
            var entry = (BaseEntryView) bindable;
            entry.TitleLabel.IsVisible = !string.IsNullOrEmpty(entry.Title) && entry.ShowTitle;
        }

        private static void OnShowPlaceholderChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
            var entryView = (BaseEntryView) bindable;
            entryView.UpdateTitle(entryView.Title, entryView.ShowPlaceholder);
        }

        protected virtual void Initialize()
        {
        }

        protected virtual void UpdateTitle(string title, bool showPlaceholder)
        {
        }
    }
}