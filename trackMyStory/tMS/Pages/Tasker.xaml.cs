using CommunityToolkit.Maui;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Views;
using System.Diagnostics;
using System.Threading.Tasks;
using tMS.ViewModels;

namespace tMS.Pages;

public partial class Tasker : ContentPage
{
    private SbTaskViewModel sbTaskViewModel;
    private TasksSettingsViewModel tasksSettingsViewModel;
    private IPopupService popupService;

    public Tasker(SbTaskViewModel _sbTaskViewModel, IPopupService _popupService)
    {
        InitializeComponent();

        popupService = _popupService;

        sbTaskViewModel = _sbTaskViewModel;
        BindingContext = sbTaskViewModel;

        sbTaskViewModel.LoadCategoriesCommand.Execute(this);
        sbTaskViewModel.LoadTasksCommand.Execute(this);

    }

    private async void AddCategory(object sender, EventArgs e)
    {
       await popupService.ShowPopupAsync<AddCategoryViewModel>();
       sbTaskViewModel.LoadCategoriesCommand.Execute(this);

    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        Debug.WriteLine(sender);
    }

    private void TaskComponent_SaveClicked(object sender, EventArgs e)
    {
        sbTaskViewModel.SaveTaskForCategoryCommand.Execute(null);
    }

    private void TaskComponent_CancelClicked(object sender, EventArgs e)
    {
        sbTaskViewModel.CancelTaskForCategoryCommand.Execute(null);
    }

    private async void btnTasksSetting_Clicked(object sender, EventArgs e)
    {
       await popupService.ShowPopupAsync<TasksSettingsViewModel>();

     //   tasksSettingsViewModel.SaveCommand.Execute(this);

    }
}
