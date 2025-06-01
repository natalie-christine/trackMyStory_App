using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Diagnostics;
using tMS.Helper;
using tMS.Models;

namespace tMS.ViewModels
{
    public partial class SbLoginViewModel(Supabase.Client _client) : ObservableObject
    {
        private readonly Supabase.Client client = _client;
        private Supabase.Gotrue.Session? session;

        [ObservableProperty]
        private string loginUsername = "";
        [ObservableProperty]
        private string loginPassword = "";

        [ObservableProperty]
        private bool isLoggedIn = false;
        [ObservableProperty]
        private string? errorMessage = null;
        [ObservableProperty]
        private Supabase.Gotrue.User? user = null;

        [ObservableProperty]
        private DbUserConfig? userConfig = new DbUserConfig();
        [ObservableProperty]
        private bool isUserConfigSaving = false;

        public async Task Init()
        {
            client.Auth.LoadSession();
            session = await client.Auth.RetrieveSessionAsync();
            if (session != null)
            {
                await LoadUserConfig();
            }
            UpdateStatus();
        }

        private void UpdateStatus()
        {
            if (session != null)
            {
                IsLoggedIn = true;
                User = session.User;
            }
            else
            {
                IsLoggedIn = false;
                User = null;
                UserConfig = new DbUserConfig();
            }
        }

        [RelayCommand]
        async Task Login()
        {
            ErrorMessage = null;
            try
            {
                session = await client.Auth.SignIn(LoginUsername, LoginPassword);
                await LoadUserConfig();
            }
            catch (Supabase.Gotrue.Exceptions.GotrueException ex)
            {
                //ErrorMessage = ex.Message;
                ErrorMessage = ex.Reason.ToString();
            }
            UpdateStatus();
        }

        [RelayCommand]
        async Task Logout()
        {
            ErrorMessage = null;
            await client.Auth.SignOut();
            session = null;
            UpdateStatus();
        }

        [RelayCommand]
        async Task LoadUserConfig()
        {
            UserConfig = new DbUserConfig();
            var results = await client.From<DbUserConfig>().Get();
            if (results.Model != null)
            {
                UserConfig = results.Model;
            }
        }

        [RelayCommand]
        async Task SaveUserConfig()
        {
            IsUserConfigSaving = true;
            if (UserConfig != null)
            {
                UserConfig.UserId = session.User.Id;
                try
                {
                    await client.From<DbUserConfig>().Upsert(UserConfig);
                    await ToastHelper.ShowToast("Einstellungen gespeichert!");
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e);
                }

            }
            IsUserConfigSaving = false;
        }
    }
}
