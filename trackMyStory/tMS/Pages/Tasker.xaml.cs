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

	
}