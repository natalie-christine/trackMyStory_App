namespace tMS.Pages;
using tMS.ViewModels;

public partial class PatPatDashboard : ContentPage
{
	public PatPatDashboard()
	{
		InitializeComponent();

		BindingContext = new ChartsData(); 
    }



}