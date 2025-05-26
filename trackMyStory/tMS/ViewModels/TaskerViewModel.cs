using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using tMS.Models;



namespace tMS.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class TaskerViewModel
    {
        public ObservableCollection<Category> Categories { get; set; }
        public ObservableCollection<MyTask> Tasks { get; set; }

        public TaskerViewModel()
        {
            FillData();
            Tasks.CollectionChanged += Tasks_ColectionChanged;


        }


        private void Tasks_ColectionChanged(Object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            UpdateData();
        }

        private void FillData()
        {
            Categories = new ObservableCollection<Category>
            {
                new Category
                {
                    Id = 1,
                    CategoryName = ".NET Maui Course",
                    Color = "#CF14DF"
                },
                new Category
                {
                    Id = 2,
                    CategoryName = "Tutorials",
                    Color = "#DF6F14"
                },
                new Category
                {
                    Id = 3,
                    CategoryName = "Shopping",
                    Color = "#14DF80"
                },
            };
            Tasks = new ObservableCollection<MyTask>
            {
                new MyTask
                {
                    TaskName = "Upload Excercise Files",
                    Completed = false,
                    CategoryId = 1
                },
                new MyTask
                {
                    TaskName = "Make Video",
                    Completed = true,
                    CategoryId = 1
                },
                new MyTask
                {
                    TaskName = "Drink Coffee",
                    Completed = false,
                    CategoryId = 1
                },
                new MyTask
                {
                    TaskName = "Pet Cats",
                    Completed = false,
                    CategoryId = 2
                },
                new MyTask
                {
                    TaskName = "Sleep",
                    Completed = false,
                    CategoryId = 3
                }
            };
            UpdateData();
        }

        public void UpdateData()
        {
            foreach (var c in Categories)
            {
                var tasks = from t in Tasks where t.CategoryId == c.Id select t;
                var completed = from t in tasks where t.Completed == true select t;
                var notCompleted = from t in tasks where t.Completed == false select t;

                c.PendingTasks = notCompleted.Count();
                c.Percentage = (float)completed.Count() / (float)tasks.Count();
            }
            foreach (var t in Tasks)
            {
                var catColor = (from c in Categories where c.Id == t.CategoryId select c.Color).FirstOrDefault();
                t.TaskColor = catColor;
            }
        }
    }
}
