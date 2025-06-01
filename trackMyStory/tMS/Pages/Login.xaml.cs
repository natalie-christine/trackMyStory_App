using tMS.Helper;
using tMS.ViewModels;

namespace tMS.Pages;

public partial class Login : ContentPage
{
    public readonly SbLoginViewModel sbLoginViewModel;

    public Login(SbLoginViewModel _sbLoginViewModel)
	{
        InitializeComponent();
        sbLoginViewModel = _sbLoginViewModel;
        BindingContext = sbLoginViewModel;
    }

    private void Logo_Clicked(object sender, EventArgs e)
    {
        ColorHelper.SetColor(ColorHelper.CreateRandomColor(), ColorHelper.CreateRandomColor());
    }
}