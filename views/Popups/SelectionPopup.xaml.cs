using CommunityToolkit.Maui.Views;
using BookTable.Models;

namespace BookTable.Views.Popups;

public partial class SelectionPopup : Popup
{
    public int Choice { get; private set; }
	public SelectionPopup()
	{
		InitializeComponent();
        this.Size = new Size(DeviceInfoModel.ScreenWidth-50, DeviceInfoModel.ScreenHeight/3);
    }
    private void OnCancelClicked(object sender, EventArgs e)
    {
        Close(null); 
    }

    private void OnNewPasteClicked(object sender, EventArgs e)
    {
        Choice = 1;
        Close();
    }
    private void OnOpenArquiveClicked(object sender, EventArgs e)
    {
        Choice = 2;
        Close();
    }
}