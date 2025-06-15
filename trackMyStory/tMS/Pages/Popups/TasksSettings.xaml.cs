namespace tMS.Pages.Popups;
using CommunityToolkit.Maui.Views;
using tMS.Helper;
using tMS.ViewModels;
public partial class TasksSettings : ContentView
{
    private TasksSettingsViewModel tasksSettingsViewModel;

    public TasksSettings(TasksSettingsViewModel _tasksSettingsViewModel)
	{
		InitializeComponent();
        tasksSettingsViewModel = _tasksSettingsViewModel;
        BindingContext = tasksSettingsViewModel;
    }
}