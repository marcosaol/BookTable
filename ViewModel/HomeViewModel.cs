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
        public ObservableCollection<Arquive> Arquives { get; set; }
        [ObservableProperty]
        private double _heightPaste;
        [ObservableProperty]
        private double _widthPaste;
        [ObservableProperty]
        private Thickness _buttonMargin;
        public HomeViewModel()
        {
            LoadPastesAsync();
            Pastes = new ObservableCollection<Paste>();
            Arquives = new ObservableCollection<Arquive>();
            HeightPaste = DeviceInfoModel.ScreenHeight - DeviceInfoModel.ScreenHeight / 6;
            WidthPaste = DeviceInfoModel.ScreenWidth + 10;
            ButtonMargin = new Thickness(0, DeviceInfoModel.ScreenHeight - DeviceInfoModel.ScreenHeight/3.6, 0, 0);
            //Create the command for showing a popup
            ShowOptionsCommand = new AsyncRelayCommand(ShowOptionsAsync);
        }
        //Initialize the command as asyn
        public IAsyncRelayCommand ShowOptionsCommand { get; }


        //This happens whe the user click the button
        private async Task ShowOptionsAsync()
        {
            // This clarify that this call need to be in a page
            if (Application.Current.MainPage is Page page)
            {
                //Creates the SelectionPopup
                var result = new SelectionPopup();
                await page.ShowPopupAsync(result);
                // Processes the choice of the user
                if (result.Choice == 1)
                {
                    var popup = new NewPastePopup();
                    await page.ShowPopupAsync(popup);
                    var newPaste = new Paste { Name = popup.PasteName};
                    Pastes.Add(new Paste { Name = popup.PasteName });
                    await DatabaseHelper.Database.InsertAsync(newPaste);
                }
            }
        }
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
