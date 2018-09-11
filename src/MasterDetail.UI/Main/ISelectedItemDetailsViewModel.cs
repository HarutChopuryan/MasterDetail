namespace MasterDetail.UI.Main
{
    public interface ISelectedItemDetailsViewModel
    {
        string Path { get; set; }

        string Type { get; set; }

        string Size { get; set; }

        string Dimension { get; set; }

        string Camera { get; set; }

        string Date { get; set; }
    }
}