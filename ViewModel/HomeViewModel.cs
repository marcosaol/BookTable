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

namespace BookTable.ViewModel
{
    public partial class HomeViewModel : ObservableObject
    {
        private Thickness _buttonMargin;
        public HomeViewModel()
        {
            ButtonMargin = new Thickness(0, DeviceInfoModel.ScreenHeight - 250, 0, 0);
            //Create the command for showing a popup
            ShowOptionsCommand = new AsyncRelayCommand(ShowOptionsAsync);
        }
        //Initialize the command as asyn
        public IAsyncRelayCommand ShowOptionsCommand { get; }

        public Thickness ButtonMargin
        {
            get => _buttonMargin;
            set
            {
                //Compares if the actual value is different of the value assigned at the construtor
                if (_buttonMargin != value)
                {
                    _buttonMargin = value;
                    OnPropertyChanged(nameof(ButtonMargin));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
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
                    // Realize a ação necessária com base na escolha do usuário
                }
            }
        }
    }
}
