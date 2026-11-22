using CommunityToolkit;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GameTemplateMAUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameTemplateMAUI.Pages;

namespace GameTemplateMAUI.ViewModels
{
    public partial class MainPageViewModel:ObservableObject
    {
        [RelayCommand]
        private async Task StartGame()
        {
            await Shell.Current.GoToAsync(nameof(GamePage));
        }
    }
}
