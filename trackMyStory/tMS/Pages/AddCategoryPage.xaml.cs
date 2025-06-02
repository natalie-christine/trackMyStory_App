using CommunityToolkit.Maui.Views;
using System.Threading.Tasks;

namespace tMS.Pages;

public partial class AddCategoryPage : Popup
{
	public AddCategoryPage()
	{
		InitializeComponent();
	}

    private void ColorPickerCategorie_ColorChanged(object sender, EventArgs e)
    {

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