using System.Diagnostics;
using tMS.Helper;
using tMS.ViewModels;

namespace tMS
{
    public partial class AppShell : Shell
    {
        private SupabaseViewModel supabaseViewModel;

        public AppShell()
        {
            InitializeComponent();
            supabaseViewModel = ServiceHelper.GetService<SupabaseViewModel>();
            BindingContext = supabaseViewModel;
            supabaseViewModel.PropertyChanged += SupabaseViewModel_PropertyChanged;

            ColorHelper.SetColor(ColorHelper.CreateRandomColor(), ColorHelper.CreateRandomColor());

            FlyoutBehavior = FlyoutBehavior.Disabled;
        }

        private async void SupabaseViewModel_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "IsLoggedIn")
            {
                Debug.WriteLine(supabaseViewModel.IsLoggedIn);
                if (supabaseViewModel.IsLoggedIn)
                {
                    await OnLoggedIn();
                }
                else
                {
                    await OnLoggedOut();
                }
            }
            if (e.PropertyName == "UserConfig")
            {
                if (supabaseViewModel.UserConfig != null)
                {
                    if (supabaseViewModel.UserConfig.ColorPrimary != null)
                    {
                        ColorHelper.SetColor(Color.FromArgb(supabaseViewModel.UserConfig.ColorPrimary), null);
                    }
                    if (supabaseViewModel.UserConfig.ColorSecondary != null)
                    {
                        ColorHelper.SetColor(null, Color.FromArgb(supabaseViewModel.UserConfig.ColorSecondary));
                    }
                }
            }
        }

        private async Task OnLoggedIn()
        {
            supabaseViewModel.LoadUserConfigCommand.Execute(null);
            FlyoutBehavior = FlyoutBehavior.Flyout;
            await GoToAsync("//MainPage");
        }

        private async Task OnLoggedOut()
        {
            FlyoutBehavior = FlyoutBehavior.Disabled;
            await GoToAsync("//Login");
        }
    }
}
