using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
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
        private List<Todo>? todos = null;

        [ObservableProperty]
        private Todo? newTodo = new Todo();

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
                LoadTodos();
            }
            UpdateStatus();
        }

        [RelayCommand]
        async Task Login()
        {
            ErrorMessage = null;
            try
            {
                session = await client.Auth.SignIn(LoginUsername, LoginPassword);
                LoadTodos();
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
        async Task LoadTodos()
        {
            Todos = null;
            var results = await client.From<Todo>().Get();
            // await client.From<Todo>().Where(x => x.UserId == session!.User!.Id).Get();
            Todos = results.Models;
        }

        [RelayCommand]
        async Task SaveNewTodo()
        {
            if (NewTodo != null)
            {
                NewTodo.Done = false;
                NewTodo.UserId = session.User.Id;
                await client.From<Todo>().Insert(NewTodo);
                NewTodo = new Todo();

                LoadTodos();
            }
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
            }
            Todos = null;
        }
    }
}
