using CommunityToolkit.Maui;
using LiveChartsCore.SkiaSharpView.Maui;
using Microsoft.Extensions.Logging;
using SkiaSharp.Views.Maui.Controls.Hosting;
using Supabase;
using System.Transactions;
using tMS.Helper;
using tMS.Pages;
using tMS.ViewModels;


namespace tMS
{
    public static class MauiProgram
    { 
        public static MauiApp CreateMauiApp()

        {

            var googleGeocoderApiKey = Properties.Resources.googleGeocoderApiKey;
            var supabaseUrl = Properties.Resources.supabaseUrl;
            var supabaseKey = Properties.Resources.supabaseKey;
            var supabaseOptions = new SupabaseOptions
            {
                AutoRefreshToken = true,
                AutoConnectRealtime = true,
                SessionHandler = new SupabaseSessionHandler()
            };
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit(options =>
                {
                    options.SetShouldEnableSnackbarOnWindows(true);
                })
                .UseSkiaSharp()
                .UseLiveCharts()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                    fonts.AddFont("FABrands.otf", "FABrands");
                    fonts.AddFont("FARegular.otf", "FARegular");
                    fonts.AddFont("FASolid.otf", "FASolid");
                })
                 .Services
                    .AddSingleton(provider => new Supabase.Client(supabaseUrl, supabaseKey, supabaseOptions))
                    .AddSingleton<SbLoginViewModel>()
                    .AddSingleton<SbTaskViewModel>()
                    .AddSingleton<AddCategoryViewModel>()
                    .AddTransientPopup<AddCategoryPage, AddCategoryViewModel>()
                    .AddTransientPopup<TasksSettingsPage, TasksSettingsViewModel>();
                    
            ;

#if DEBUG
            builder.Logging.AddDebug();
#endif

            var app = builder.Build();
            ServiceHelper.Initialize(app.Services);
            return app;
        }
    }
}
