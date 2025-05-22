using tMS.Helper;
using tMS.ViewModels;

namespace tMS.Pages;

public partial class Login : ContentPage
{
    private SupabaseViewModel supabaseViewModel;

    public Login()
	{
        InitializeComponent();
        supabaseViewModel = ServiceHelper.GetService<SupabaseViewModel>();
        BindingContext = supabaseViewModel;
    }
}