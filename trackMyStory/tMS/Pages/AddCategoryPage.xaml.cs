using CommunityToolkit.Maui.Views;
using System.Threading.Tasks;
using tMS.Helper;

namespace tMS.Pages;

public partial class AddCategoryPage : Popup
{
	public AddCategoryPage()
	{
		InitializeComponent();
        Color color = ColorHelper.CreateRandomColor();
        ColorPickerCategorie.Red = color.Red;
        ColorPickerCategorie.Green = color.Green;
        ColorPickerCategorie.Blue = color.Blue;
        ColorPickerCategorie_ColorChanged(null, null);
    }

    private void ColorPickerCategorie_ColorChanged(object sender, EventArgs e)
    {
        Color color = Color.FromRgb(ColorPickerCategorie.Red, ColorPickerCategorie.Green, ColorPickerCategorie.Blue);
        entry.BackgroundColor = color;
        entry.TextColor = ColorHelper.CreateTextColor(color);
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        //    if (result != null)
        //    {
        //        categoryName = nameEntry.Text;
        //        selectedColor = colorPicker.SelectedColor;

        //        if (!string.IsNullOrWhiteSpace(categoryName))
        //        {
        //            if (BindingContext is ViewModels.SbTaskViewModel vm)
        //            {
        //                vm.AddCategory(categoryName, selectedColor);
        //            }
        //        }
        //    }
    }

    private async void Button_Clicked_1(object sender, EventArgs e)
    {
        await CloseAsync();
    }
}