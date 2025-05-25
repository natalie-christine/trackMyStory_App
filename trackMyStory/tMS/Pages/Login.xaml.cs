using tMS.Helper;
using tMS.ViewModels;

namespace tMS.Pages;

public partial class Login : ContentPage
{
    private SupabaseViewModel supabaseViewModel;

    public Login(SupabaseViewModel _supabaseViewModel)
	{
        InitializeComponent();
        supabaseViewModel = _supabaseViewModel;
        BindingContext = supabaseViewModel;
    }
}