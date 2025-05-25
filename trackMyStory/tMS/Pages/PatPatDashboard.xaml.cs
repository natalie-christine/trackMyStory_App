namespace tMS.Pages;

using System.Diagnostics;
using tMS.ViewModels;

public partial class PatPatDashboard : ContentPage
{
	public PatPatDashboard()
	{
		InitializeComponent();

		BindingContext = new ChartsData(); 
    }

    private void PatPatClicked(object sender, EventArgs e)
    {
        // Add your event handling logic here
    }

    private void StarClicked(object sender, EventArgs e)
    {
        
    }
    private void DoneClicked(object sender, EventArgs e)
    {

    }

    private void StepsClicked(object sender, EventArgs e)
    {

    }

    private void EinstellungenClicked(object sender, EventArgs e)
    {
        Debug.WriteLine("EinstellungenClicked");
    }

    private void NullPlanClicked(object sender, EventArgs e)
    {
        Debug.WriteLine("NullPlanClicked");
    }
}