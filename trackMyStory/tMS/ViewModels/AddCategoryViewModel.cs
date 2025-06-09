using CommunityToolkit.Maui.Core;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Diagnostics;

namespace tMS.ViewModels;

public partial class AddCategoryViewModel : ObservableObject
{
    [ObservableProperty]
    string name = "";
    [ObservableProperty]
    string colorHex = "#000000"; 

    readonly IPopupService popupService;

    public AddCategoryViewModel(IPopupService popupService)
    {
        this.popupService = popupService;
    }

    void OnCancel()
    {
    }

    [RelayCommand]
    void OnSave()
    {
        Debug.WriteLine($"Saving category: {Name} with color: {ColorHex}");
    }
}
