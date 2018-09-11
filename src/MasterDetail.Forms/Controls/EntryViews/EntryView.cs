using Xamarin.Forms;

namespace MasterDetail.Forms.Controls.EntryViews
{
    public class EntryView : BaseEntryView
    {
        public static readonly BindableProperty TextProperty =
            BindableProperty.Create(nameof(Text),
                typeof(string),
                typeof(EntryView),
                null);

        public static readonly BindableProperty IsSpellCheckEnabledProperty =
            BindableProperty.Create(nameof(IsSpellCheckEnabled),
                typeof(bool),
                typeof(EntryEx),
                false);

        public EntryEx TextEntry { get; protected set; }

        public string Text
        {
            get => (string) GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }

        public bool IsSpellCheckEnabled
        {
            get => (bool) GetValue(IsSpellCheckEnabledProperty);
            set => SetValue(IsSpellCheckEnabledProperty, value);
        }

        protected override void Initialize()
        {
            TextEntry = new EntryEx
            {
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            ControlContainer.Content = TextEntry;
            TextEntry.SetBinding(Entry.TextProperty, new Binding(nameof(Text), BindingMode.TwoWay, source: this));
            TextEntry.SetBinding(InputView.IsSpellCheckEnabledProperty,
                new Binding(nameof(IsSpellCheckEnabled), BindingMode.TwoWay, source: this));
        }

        protected override void UpdateErrors(bool hasErrors)
        {
            TextEntry.HasErrors = hasErrors;
        }

        protected override void UpdateTitle(string title, bool showPlaceholder)
        {
            TextEntry.Placeholder = showPlaceholder ? title : null;
        }
    }
}