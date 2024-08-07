namespace BookTable.views;

public partial class HomeView : ContentPage
{
	public HomeView()
	{
		InitializeComponent();
        //Here we divided the height of the screen by the density for the sake of having the unity in pixels
        var screenHeight = DeviceDisplay.MainDisplayInfo.Height / DeviceDisplay.MainDisplayInfo.Density;
        //This create the margin for the button be exibited in the low part of the screen
        ButtonFrame.Margin = new Thickness(20, screenHeight-250, 20, 20);
    }
}