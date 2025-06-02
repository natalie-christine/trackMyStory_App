using CommunityToolkit.Maui.Views;
using tMS.ViewModels;

namespace tMS.Pages;

public partial class Tasker : ContentPage
{
    public Tasker()
    {
        InitializeComponent();
    }

    private async void AddCategory(object sender, EventArgs e)
    {

        AddCategoryPage addCategoryPage = new AddCategoryPage();
        this.ShowPopup(addCategoryPage);



        //    string categoryName = string.Empty;
        //    Color selectedColor = Colors.Blue;

        //    var nameEntry = new Entry { Placeholder = "Name der Kategorie" };
        //    var colorPicker = new Components.ColorPicker
        //    {
        //        HorizontalOptions = LayoutOptions.Center,
        //        VerticalOptions = LayoutOptions.Center
        //    };

        //    var stack = new VerticalStackLayout
        //    {
        //        Spacing = 15,
        //        Children = { nameEntry, colorPicker }
        //    };

        //    var content = new ContentView { Content = stack };



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
}
