using Xamarin.Forms;

namespace MasterDetail.UI.Main
{
    public interface ISelectedItemDetailsViewModel
    {
        string Name { get; set; }

        ImageSource ImageSource { get; set; }
    }
}