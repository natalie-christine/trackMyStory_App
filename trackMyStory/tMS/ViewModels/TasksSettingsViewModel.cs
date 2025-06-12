using CommunityToolkit.Maui.Core;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Diagnostics;
using tMS.Models;

namespace tMS.ViewModels;

public partial class TasksSettingsViewModel : ObservableObject
{
    [ObservableProperty]
    string name = "";
    [ObservableProperty]
    string colorHex = "#000000"; 

    readonly IPopupService popupService;
    readonly Supabase.Client client;

    
    public TasksSettingsViewModel(IPopupService popupService, Supabase.Client client)
    {
        this.popupService = popupService;
        this.client = client;
    }

    [RelayCommand]
    async Task OnSave()
    {
        //TODD: Implement save logic

    }
}
