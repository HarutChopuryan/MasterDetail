using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace MasterDetail.Forms.Controls
{
    public class ViewButton : ContentView
    {
        public static readonly BindableProperty CommandProperty = BindableProperty.Create(nameof(Command),
            typeof(ICommand),
            typeof(ViewButton),
            null);

        public static readonly BindableProperty IsExecutableProperty = BindableProperty.Create(nameof(IsExecutable),
            typeof(bool),
            typeof(ViewButton),
            true);

        public ViewButton()
        {
            BackgroundColor = Color.Transparent;
        }

        public ICommand Command
        {
            get => (ICommand) GetValue(CommandProperty);
            set => SetValue(CommandProperty, value);
        }

        public bool IsExecutable
        {
            get => (bool) GetValue(IsExecutableProperty);
            set => SetValue(IsExecutableProperty, value);
        }

        public event EventHandler<EventArgs> Clicked;

        public void InvokeClicked(object sender, EventArgs args)
        {
            Clicked?.Invoke(sender, args);
        }
    }
}