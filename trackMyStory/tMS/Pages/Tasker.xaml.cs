using CommunityToolkit.Maui.Views;
using tMS.ViewModels;

namespace tMS.Pages;

public partial class Tasker : ContentPage
{
    private SbTaskViewModel sbTaskViewModel;

    public Tasker(SbTaskViewModel _sbTaskViewModel)
    {
        InitializeComponent();

        sbTaskViewModel = _sbTaskViewModel;
        BindingContext = sbTaskViewModel;

        sbTaskViewModel.LoadCategoriesCommand.Execute(this);
        sbTaskViewModel.LoadTasksCommand.Execute(this);
    }

    private async void AddCategory(object sender, EventArgs e)
    {

        AddCategoryPage addCategoryPage = new AddCategoryPage();
        this.ShowPopup(addCategoryPage);
    }
}
