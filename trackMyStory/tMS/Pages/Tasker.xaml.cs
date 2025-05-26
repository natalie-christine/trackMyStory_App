using tMS.ViewModels;

namespace tMS.Pages;

public partial class Tasker : ContentPage
{
	public Tasker()
	{
		InitializeComponent();
		BindingContext = new TaskerViewModel();
    }

	
}