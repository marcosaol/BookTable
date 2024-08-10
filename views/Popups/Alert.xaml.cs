using CommunityToolkit.Maui.Views;
using System.Windows.Input;

namespace BookTable.Views.Popups;

public partial class Alert : Popup
{
    public ICommand CloseCommand { get; }
    public Alert(string message)
	{
		InitializeComponent();
        MessageLabel.Text = message;
        CloseCommand = new Command(ClosePopup);
        BindingContext = this;
    }
    private void ClosePopup()
    {
        Close(); 
    }
}