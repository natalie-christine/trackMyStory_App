namespace tMS.Pages;
using tMS.ViewModels;
using Windows.ApplicationModel.VoiceCommands;

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

}