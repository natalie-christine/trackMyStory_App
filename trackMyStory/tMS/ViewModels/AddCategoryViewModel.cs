using CommunityToolkit.Maui;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Diagnostics;
using tMS.Models;

namespace tMS.ViewModels;

public partial class AddCategoryViewModel : ObservableObject
{
    [ObservableProperty]
    string name = "";
    [ObservableProperty]
    string colorHex = "#000000"; 

    readonly IPopupService popupService;
    readonly Supabase.Client client;

    
    public AddCategoryViewModel(IPopupService popupService, Supabase.Client client)
    {
        this.popupService = popupService;
        this.client = client;
    }

    [RelayCommand]
    async Task Save()
    {
        Debug.WriteLine($"Saving category: {Name} with color: {ColorHex}");

        try
        {
            var result = await client.From<DbCategory>().Insert(new DbCategory()
            {
                UserId = client.Auth.CurrentSession?.User.Id ?? string.Empty,
                Name = name,
                Color = ColorHex
            });
            await popupService.ClosePopupAsync(AppShell.Current);
        }
        catch
        {
            new Exception("Fehler beim Speichern der Kategorie. Bitte versuche es erneut.");
        }

    }

    [RelayCommand]
    async Task Cancel()
    {
        await popupService.ClosePopupAsync(AppShell.Current);
    }
}
