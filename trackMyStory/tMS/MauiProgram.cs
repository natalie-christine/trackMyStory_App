using CommunityToolkit.Maui;
using LiveChartsCore.SkiaSharpView.Maui;
using Microsoft.Extensions.Logging;
using SkiaSharp.Views.Maui.Controls.Hosting;
using Supabase;
using System.Transactions;
using tMS.Helper;
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
                .UseMauiCommunityToolkit()
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
                    .AddSingleton(provider =>
                    {
                        var vm = new SupabaseViewModel(provider.GetService<Supabase.Client>());
                        vm.Init();
                        return vm;
                    })
                    ;
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
