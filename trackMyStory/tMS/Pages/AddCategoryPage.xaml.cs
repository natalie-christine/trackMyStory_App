using CommunityToolkit.Maui.Views;
using tMS.Helper;
using tMS.ViewModels;

namespace tMS.Pages;

public partial class AddCategoryPage : Popup
{
	public AddCategoryPage(AddCategoryViewModel addCategoryViewModel)
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
    }

    private async void Button_Clicked_1(object sender, EventArgs e)
    {
        await CloseAsync();
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