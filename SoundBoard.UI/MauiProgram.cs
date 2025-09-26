using CommunityToolkit.Maui.Core;
using Microsoft.Extensions.Logging;
using Plugin.Maui.Audio;
using SoundBoard.UI.ExtensionMethodes;
using UraniumUI;
using UraniumUI.Dialogs;

namespace SoundBoard.UI
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                    fonts.AddFontAwesomeIconFonts();
                });

            //uraniumui injection
            builder.UseUraniumUI()
                .UseUraniumUIMaterial();

            //custom dependencyInjection
          
            builder.Services.AddService();
            builder.Services.AddCommunityToolkitDialogs();
            //addcustom 

            builder.AddAudio();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
