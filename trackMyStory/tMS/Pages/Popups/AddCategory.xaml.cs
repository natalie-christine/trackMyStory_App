using CommunityToolkit.Maui.Views;
using tMS.Helper;
using tMS.ViewModels;

namespace tMS.Pages.Popups;

public partial class AddCategory : ContentView
{
	public AddCategory(AddCategoryViewModel addCategoryViewModel)
	{
		InitializeComponent();
        BindingContext = addCategoryViewModel;
        btnRandomColor(null, null);
    }

    private void ColorPickerCategorie_ColorChanged(object sender, EventArgs e)
    {
        Color color = Color.FromRgb(ColorPickerCategorie.Red, ColorPickerCategorie.Green, ColorPickerCategorie.Blue);
        entry.BackgroundColor = color;
        entry.TextColor = ColorHelper.CreateTextColor(color);
        entry.PlaceholderColor = ColorHelper.CreatePlaceholderTextColor(color);
    }

   private void btnRandomColor(object sender, EventArgs e)
    {
        Color color = ColorHelper.CreateRandomColor();
        ColorPickerCategorie.Red = color.Red;
        ColorPickerCategorie.Green = color.Green;
        ColorPickerCategorie.Blue = color.Blue;
        ColorPickerCategorie_ColorChanged(null, null);
    }
}