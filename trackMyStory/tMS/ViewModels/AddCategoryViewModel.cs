using CommunityToolkit.Maui.Core;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace tMS.ViewModels;

public partial class AddCategoryViewModel : ObservableObject
{
    [ObservableProperty]
    string name = "";

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
    }
}
