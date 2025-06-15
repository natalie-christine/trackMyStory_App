using tMS.Helper;

namespace tMS
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            ColorHelper.ToggleDarkMode();
        }

        private async void NavPatPatDashboard_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//PatPatDashboard");
        }

        private async void NavTasksDashboard_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//Tasker");
        }

        private async void NavEinstellungen_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//Settings");
        }
    }

}
