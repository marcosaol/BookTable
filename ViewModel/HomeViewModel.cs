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
        private Thickness _buttonMargin;
        public HomeViewModel()
        {
            LoadPastesAsync();
            Pastes = new ObservableCollection<Paste>();
            HeightPaste = DeviceInfoModel.ScreenHeight - DeviceInfoModel.ScreenHeight / 6;
            WidthPaste = DeviceInfoModel.ScreenWidth + 10;
            ButtonMargin = new Thickness(0, DeviceInfoModel.ScreenHeight - DeviceInfoModel.ScreenHeight/3.6, 0, 0);
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
            set => SetProperty(ref _widthPaste, value);
        }
        public Thickness ButtonMargin
        {
            get => _buttonMargin;
            set => SetProperty(ref _buttonMargin, value);
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
                    var newPaste = new Paste { Name = popup.PasteName};
                    Pastes.Add(new Paste { Name = popup.PasteName });
                    await DatabaseHelper.Database.InsertAsync(newPaste);
                }
            }
        }
        [RelayCommand]
        public async Task LoadPastesAsync()
        {
            var pastes = await DatabaseHelper.Database.Table<Paste>().ToListAsync();

            if (Pastes.Count > 0)
                Pastes.Clear();

            foreach (var paste in pastes)
            {
                Pastes.Add(paste); 
            }
        }
    }
}
