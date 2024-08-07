namespace BookTable.Views;
using BookTable.ViewModel;
public partial class HomeView : ContentPage
{
	public HomeView()
	{
		InitializeComponent();
		BindingContext = new HomeViewModel();
        
    }
}