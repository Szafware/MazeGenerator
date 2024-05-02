using CommunityToolkit.Maui;
using MazeGenerator.Ui.Factories;
using MazeGenerator.Ui.ViewModels;
using MazeGenerator.Ui.Views;
using Microsoft.Extensions.Logging;

namespace MazeGenerator.Ui;
public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder()
            .UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

#if DEBUG
        builder.Logging.AddDebug();
#endif

        builder.Services.AddTransient<IMainPageViewModel, MainPageViewModel>();
        builder.Services.AddTransient<IMazeCellViewModel, MazeCellViewModel>();
        builder.Services.AddTransient<IMazeSettingsViewModel, MazeSettingsViewModel>();

        //builder.Services.RegisterViewWithViewModel<MainPage, IMainPageViewModel, MainPageViewModel>();
        //builder.Services.RegisterViewWithViewModel<MazeCellView, IMazeCellViewModel, MazeCellViewModel>();
        //builder.Services.RegisterViewWithViewModel<MazeSettingsView, IMazeSettingsViewModel, MazeSettingsViewModel>();

        builder.Services.RegisterView<MainPage, IMainPageViewModel>();
        builder.Services.RegisterView<MazeCellView, IMazeCellViewModel>();
        builder.Services.RegisterView<MazeSettingsView, IMazeSettingsViewModel>();

        builder.Services.AddSingleton<IMazeCellViewModelFactory, MazeCellViewModelFactory>();

        return builder.Build();
    }

    private static void RegisterView<TView, TViewModel>(this IServiceCollection serviceDescriptors)
    where TView : BindableObject, new()
    where TViewModel : class
    {
        serviceDescriptors.AddTransient(sp =>
        {
            var page = new TView
            {
                BindingContext = sp.GetRequiredService<TViewModel>()
            };

            return page;
        });
    }

    // Throws exception "No service for type 'MazeGenerator.Ui.ViewModels.MainPageViewModel' has been registered."
    //private static void RegisterViewWithViewModel<TView, TViewModelInterface, TViewModel>(this IServiceCollection serviceCollection)
    //    where TView : BindableObject, new()
    //    where TViewModelInterface : class
    //    where TViewModel : class, TViewModelInterface
    //{
    //    serviceCollection.AddTransient<TViewModelInterface, TViewModel>();

    //    serviceCollection.AddTransient(sp =>
    //    {
    //        var page = new TView
    //        {
    //            BindingContext = sp.GetRequiredService<TViewModel>()
    //        };

    //        return page;
    //    });
    //}
}
