using eBook.Components;
using eBook.MobileApp.Auth0;
using eBook.MobileApp.Services;
using eBook.Pages.Data;
using eBook.Shared;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Infrastructure;
using Microsoft.Extensions.Logging;

namespace eBook.MobileApp
{
    public static class MauiProgram
    {
        public static string Base = DeviceInfo.Platform == DevicePlatform.Android ? "http://10.0.2.2" : "http://localhost";
        public static string ApiUrl = $"{Base}:41130/";

        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureEssentials()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });

            builder.Services.AddMauiBlazorWebView();
            builder.Services.AddHttpClient<PodcastService>(client =>
            {
                client.BaseAddress = new Uri(ApiUrl);
                client.DefaultRequestHeaders.Add("api-version", "1.0");
            });

#if WINDOWS
            builder.Services.AddSingleton<eBook.Mobile.Shared.INativeAudioService, eBook.Mobile.Shared.Platforms.Windows.NativeAudioService>();
#elif ANDROID
            builder.Services.AddSingleton<eBook.Mobile.Shared.INativeAudioService, eBook.Mobile.Shared.Platforms.Android.NativeAudioService>();
#elif MACCATALYST
            builder.Services.AddSingleton<eBook.Mobile.Shared.INativeAudioService, eBook.Mobile.Shared.Platforms.MacCatalyst.NativeAudioService>();
#elif IOS
            builder.Services.AddSingleton<eBook.Mobile.Shared.INativeAudioService, eBook.Mobile.Shared.Platforms.iOS.NativeAudioService>();
#endif

            builder.Services.AddScoped<ThemeInterop>();
            builder.Services.AddScoped<IAudioInterop, AudioInteropService>();
            builder.Services.AddScoped<LocalStorageInterop>();
            builder.Services.AddScoped<ClipboardInterop>();
            builder.Services.AddScoped<SubscriptionsService>();
            builder.Services.AddScoped<ListenLaterService>();
            builder.Services.AddSingleton<PlayerService>();
            builder.Services.AddScoped<ComponentStatePersistenceManager>();
            builder.Services.AddScoped<PersistentComponentState>(sp => sp.GetRequiredService<ComponentStatePersistenceManager>().State);

#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
    		builder.Logging.AddDebug();
#endif
            builder.Services.AddSingleton(new Auth0Client(new()
            {
                Domain = "<YOUR_AUTH0_DOMAIN>",
                ClientId = "<YOUR_CLIENT_ID>",
                Scope = "openid profile",
                RedirectUri = "myapp://callback"
            }));

            builder.Services.AddAuthorizationCore();
            builder.Services.AddScoped<AuthenticationStateProvider, Auth0AuthenticationStateProvider>();
            return builder.Build();
        }
    }
}
