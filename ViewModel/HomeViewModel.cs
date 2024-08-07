using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookTable.Views.Popups;
using BookTable.Models;
using System.Collections.ObjectModel;

namespace BookTable.ViewModel
{
    public partial class HomeViewModel : ObservableObject
    {
     
        public ObservableCollection<Paste> Pastes { get; set; }
        private double _heightPaste;
        private double _widthPaste;
        public HomeViewModel()
        {
            Pastes = new ObservableCollection<Paste>();
            HeightPaste = DeviceInfoModel.ScreenHeight - DeviceInfoModel.ScreenHeight / 3.5;
            WidthPaste = DeviceInfoModel.ScreenWidth + 10;
            //Create the command for showing a popup
            ShowOptionsCommand = new AsyncRelayCommand(ShowOptionsAsync);
        }
        //Initialize the command as asyn
        public IAsyncRelayCommand ShowOptionsCommand { get; }

        public double HeightPaste
        {
            get => _heightPaste;
            set => SetProperty(ref _heightPaste, value);
        }
        public double WidthPaste
        {
            get => _widthPaste;
            set
            {
                _widthPaste = value;
                OnPropertyChanged(nameof(WidthPaste));
            }
        }

        //This happens whe the user click the button
        private async Task ShowOptionsAsync()
        {
            // This clarify that this call need to be im a page
            if (Application.Current.MainPage is Page page)
            {
                //Creates the SelectionPopup
                var result = await page.ShowPopupAsync(new SelectionPopup());
                // Processes the choice of the user
                if (result != null)
                {
                    var popup = new NewPastePopup();
                    await page.ShowPopupAsync(popup);
                    Pastes.Add(new Paste { Name = popup.PasteName });
                }
            }
        }
    }
}
