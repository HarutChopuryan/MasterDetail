using MasterDetail.UI.Base;
using Xamarin.Forms;

namespace MasterDetail.UI.Main
{
    public interface ISelectedItemDetailsViewModel
    {
        string DbName { get; set; }

        string Name { get; set; }

        ImageSource ImageSource { get; set; }

        IAsyncCommand ShowTappedImgCommand { get; set; }
    }
}