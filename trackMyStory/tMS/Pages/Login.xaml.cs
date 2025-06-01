using tMS.Helper;
using tMS.ViewModels;

namespace tMS.Pages;

public partial class Login : ContentPage
{
    public readonly SupabaseViewModel supabaseViewModel;

    public Login(SupabaseViewModel _supabaseViewModel)
	{
        InitializeComponent();
        supabaseViewModel = _supabaseViewModel;
        BindingContext = supabaseViewModel;
    }

    private void Logo_Clicked(object sender, EventArgs e)
    {
        ColorHelper.SetColor(ColorHelper.CreateRandomColor(), ColorHelper.CreateRandomColor());
    }
}