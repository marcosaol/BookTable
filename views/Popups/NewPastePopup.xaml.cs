using CommunityToolkit.Maui.Views;
using BookTable.Models;

namespace BookTable.Views.Popups;

public partial class NewPastePopup : Popup

{
    public string PasteName { get; private set; }
    public NewPastePopup()
	{
		InitializeComponent();
        PasteName = string.Empty;
        this.Size = new Size(DeviceInfoModel.ScreenWidth - 50, DeviceInfoModel.ScreenHeight / 3);

    }
    private void OnCreatePasteClicked(object sender, EventArgs e)
    {
        PasteName = PasteEntry.Text;
        Close();
    }

}