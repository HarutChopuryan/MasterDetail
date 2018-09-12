using MasterDetail.UI.Base.Implementation;
using PropertyChanged;

namespace MasterDetail.UI.Main.Implementation
{
    [AddINotifyPropertyChangedInterface]
    public class SelectedItemDetailsViewModel : BaseBindableObject, ISelectedItemDetailsViewModel
    {
        public string Path { get; set; } = "Path";

        public string Type { get; set; } = "Type";

        public string Size { get; set; } = "Size";

        public string Dimension { get; set; } = "Dimension";

        public string Camera { get; set; } = "Camera";

        public string Date { get; set; } = "Date";

        public string Name { get;  set; }
    }
}