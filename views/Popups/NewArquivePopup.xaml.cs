using CommunityToolkit.Maui.Views;
using BookTable.Models;

namespace BookTable.Views.Popups;

public partial class NewArquivePopup : Popup

{
    public string ArquiveName { get; private set; }
    public NewArquivePopup()
    {
        InitializeComponent();
        ArquiveName = string.Empty;
        this.Size = new Size(DeviceInfoModel.ScreenWidth - 50, DeviceInfoModel.ScreenHeight / 3);

    }
    private void OnCreateArquiveClicked(object sender, EventArgs e)
    {
        ArquiveName = PasteEntry.Text;
        Close();
    }

}