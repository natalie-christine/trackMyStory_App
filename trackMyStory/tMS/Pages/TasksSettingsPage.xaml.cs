namespace tMS.Pages;
using CommunityToolkit.Maui.Views;
using tMS.Helper;
using tMS.ViewModels;
public partial class TasksSettingsPage : Popup
{
	public TasksSettingsPage(TasksSettingsViewModel tasksSettingsViewModel)
	{
		InitializeComponent();
        BindingContext = tasksSettingsViewModel;
    }

	private void btnClose_Clicked(object sender, EventArgs e)
	{
		Close();
    }
}