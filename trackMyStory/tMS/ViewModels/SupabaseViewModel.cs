using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Supabase.Postgrest.Responses;
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

        [ObservableProperty]
        private DbCategory? selectedCategory = null;

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

        [RelayCommand]
        async Task LoadCategories()
        {
            try
            {
                var result = await client.From<DbCategory>().Get();
                if (result?.Models != null)
                {
                    Categories.Clear();
                    result!.Models.ForEach(x => Categories.Add(x));
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
            // all filtered tasks
            await DoLoadTasks(null);
        }

        [RelayCommand]
        async Task SelectCategory(string? categoryId)
        {
            if (categoryId == null)
            {
                SelectedCategory = null;
            }
            else
            {
                SelectedCategory = (from c in Categories where c.Id == categoryId select c).First();
            }

            // load filtered tasks
            await DoLoadTasks(SelectedCategory?.Id);
        }

        private async Task DoLoadTasks(string? categoryId)
        {
            try
            {
                ModeledResponse<DbTask> result;
                if (categoryId == null)
                {
                    result = await client.From<DbTask>().Get();
                }
                else
                {
                    result = await client.From<DbTask>().Where(x => x.CategoryId == categoryId).Get();
                }

                if (result?.Models != null)
                {
                    Tasks.Clear();
                    result!.Models.ForEach(x =>
                    {
                        x.Category = (from c in Categories where c.Id == x.CategoryId select c).First();
                        Tasks.Add(x);
                    });
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }
        }
    }
}
