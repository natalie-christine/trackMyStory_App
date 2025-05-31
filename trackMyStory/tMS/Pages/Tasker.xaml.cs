using tMS.ViewModels;

namespace tMS.Pages;

public partial class Tasker : ContentPage
{
    private SupabaseViewModel supabaseViewModel;

    public Tasker(SupabaseViewModel _supabaseViewModel)
	{
		InitializeComponent();

        supabaseViewModel = _supabaseViewModel;
        BindingContext = supabaseViewModel;

        supabaseViewModel.LoadCategoriesCommand.Execute(this);
        supabaseViewModel.LoadTasksCommand.Execute(this);
    }

	
}