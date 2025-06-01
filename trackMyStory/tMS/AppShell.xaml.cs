using System.Diagnostics;
using tMS.Helper;
using tMS.ViewModels;

namespace tMS
{
    public partial class AppShell : Shell
    {
        private SbLoginViewModel sbLoginViewModel;

        public AppShell()
        {
            InitializeComponent();

            sbLoginViewModel = ServiceHelper.GetService<SbLoginViewModel>();
            sbLoginViewModel.Init();

            BindingContext = sbLoginViewModel;
            sbLoginViewModel.PropertyChanged += SupabaseViewModel_PropertyChanged;

            ColorHelper.SetColor(ColorHelper.CreateRandomColor(), ColorHelper.CreateRandomColor());

            FlyoutBehavior = FlyoutBehavior.Disabled;
        }

        private async void SupabaseViewModel_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "IsLoggedIn")
            {
                Debug.WriteLine(sbLoginViewModel.IsLoggedIn);
                if (sbLoginViewModel.IsLoggedIn)
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
                if (sbLoginViewModel.UserConfig != null)
                {
                    if (sbLoginViewModel.UserConfig.ColorPrimary != null)
                    {
                        ColorHelper.SetColor(Color.FromArgb(sbLoginViewModel.UserConfig.ColorPrimary), null);
                    }
                    if (sbLoginViewModel.UserConfig.ColorSecondary != null)
                    {
                        ColorHelper.SetColor(null, Color.FromArgb(sbLoginViewModel.UserConfig.ColorSecondary));
                    }
                }
            }
        }

        private async Task OnLoggedIn()
        {
            sbLoginViewModel.LoadUserConfigCommand.Execute(null);
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
