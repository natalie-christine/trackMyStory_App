using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Supabase.Postgrest.Responses;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Xml.Linq;
using tMS.Models;

namespace tMS.ViewModels
{
    public partial class SbTaskViewModel : ObservableObject
    {
        private readonly Supabase.Client client;

        [ObservableProperty]
        private ObservableCollection<DbCategory> categories = new ObservableCollection<DbCategory>();

        [ObservableProperty]
        private ObservableCollection<DbTask> tasks = new ObservableCollection<DbTask>();

        [ObservableProperty]
        private DbCategory? selectedCategory = null;

        [ObservableProperty]
        private DbTask? newTask = null;

        public SbTaskViewModel(Supabase.Client _client)
        {
            client = _client;
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

        [RelayCommand]
        void CreateTaskForCategory(string? categoryId)
        {
            NewTask = new DbTask {
                CategoryId = categoryId,
                UserId = client.Auth.CurrentUser.Id,
                Category = (from c in Categories where c.Id == categoryId select c).First()
            };
        }

        [RelayCommand]
        async Task SaveTaskForCategory()
        {
            if (NewTask != null)
            {
                NewTask.Category = null;
                var result = await client.From<DbTask>().Insert(NewTask);
                NewTask = null;
                await DoLoadTasks(SelectedCategory?.Id);
            }
        }

        [RelayCommand]
        void CancelTaskForCategory()
        {
            NewTask = null;
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
