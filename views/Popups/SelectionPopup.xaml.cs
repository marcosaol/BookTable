using CommunityToolkit.Maui.Views;
using BookTable.Models;

namespace BookTable.Views.Popups;

public partial class SelectionPopup : Popup
{
	public SelectionPopup()
	{
		InitializeComponent();

        this.Size = new Size(DeviceInfoModel.ScreenWidth-50, DeviceInfoModel.ScreenHeight/3);
    }
}