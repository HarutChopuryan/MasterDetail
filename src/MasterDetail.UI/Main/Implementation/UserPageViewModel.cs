using MasterDetail.UI.Base.Implementation;
using PropertyChanged;


namespace MasterDetail.UI.Main.Implementation
{
    [AddINotifyPropertyChangedInterface]
    public class UserPageViewModel : BaseBindableObject, IUserPageViewModel
    {
        public string ImageSource { get; set; }
    }
}