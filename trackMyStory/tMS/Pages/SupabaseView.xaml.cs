
using tMS.Helper;
using tMS.ViewModels;

namespace tMS.Pages;

public partial class SupabaseView : ContentPage
{
    private SupabaseViewModel supabaseViewModel;

	public SupabaseView()
	{
		InitializeComponent();
        supabaseViewModel = ServiceHelper.GetService<SupabaseViewModel>();
        BindingContext = supabaseViewModel;

    }
}