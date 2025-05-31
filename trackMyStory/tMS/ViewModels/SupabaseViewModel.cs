using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Diagnostics;
using tMS.Helper;
using tMS.Models;

namespace tMS.ViewModels
{
    public partial class SupabaseViewModel : ObservableObject
    {
        private readonly Supabase.Client client;
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

        [ObservableProperty]
        private ObservableCollection<DbCategory> categories = new ObservableCollection<DbCategory>();

        [ObservableProperty]
        private ObservableCollection<DbTask> tasks = new ObservableCollection<DbTask>();

        public SupabaseViewModel(Supabase.Client _client)
        {
            client = _client;
        }

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
            // await client.From<Todo>().Where(x => x.UserId == session!.User!.Id).Get();
            if (results.Model != null) {
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

        [RelayCommand]
        async Task LoadCategories()
        {
            try
            {
                var result = await client.From<DbCategory>().Get();
                if (result?.Models != null)
                {
                    Categories.Clear();
                    foreach (var item in result!.Models)
                    {
                        Categories.Add(item);
                    }
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }
        }

        [RelayCommand]
        async Task LoadTasks()
        {
            try
            {
                var result = await client.From<DbTask>().Get();
                if (result?.Models != null)
                {
                    Tasks.Clear();
                    foreach (var item in result!.Models)
                    {
                        Tasks.Add(item);
                    }
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }
        }
    }
}
