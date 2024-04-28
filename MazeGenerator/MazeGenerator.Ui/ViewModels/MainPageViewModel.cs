using CommunityToolkit.Mvvm.ComponentModel;
using MazeGenerator.Ui.Factories;
using MazeGenerator.Ui.Models;
using System.Collections.ObjectModel;

namespace MazeGenerator.Ui.ViewModels;

public partial class MainPageViewModel : ObservableObject, IMainPageViewModel
{
    [ObservableProperty]
    private IMazeSettingsViewModel _mazeSettingsViewModel;

    [ObservableProperty]
    private ObservableCollection<IMazeCellViewModel> _mazeCellViewModels = new ObservableCollection<IMazeCellViewModel>();

    [ObservableProperty]
    private int _mazeWidth = 10;

    [ObservableProperty]
    private int _mazeHeight = 10;

    private readonly IMazeCellViewModelFactory _mazeCellViewModelFactory;

    private readonly int _mazeCellGenerationDelay = 2;

    public MainPageViewModel(
        IMazeSettingsViewModel mazeSettingsViewModel,
        IMazeCellViewModelFactory mazeCellViewModelFactory)
    {
        MazeSettingsViewModel = mazeSettingsViewModel;
        _mazeCellViewModelFactory = mazeCellViewModelFactory;

        _mazeSettingsViewModel.OnMazeCreate += OnMazeCreate;
    }

    private async Task OnMazeCreate(MazeSettings mazeSettings)
    {
        MazeCellViewModels.Clear();

        MazeWidth = mazeSettings.MazeWidth;
        MazeHeight = mazeSettings.MazeHeight;

        for (int x = 0; x < MazeWidth; x++)
        {
            for (int y = 0; y < MazeWidth; y++)
            {
                var mazeCellViewModel = _mazeCellViewModelFactory.Create();
                mazeCellViewModel.Column = x;
                mazeCellViewModel.Row = y;

                MazeCellViewModels.Add(mazeCellViewModel);

                await Task.Delay(_mazeCellGenerationDelay);
            }
        }
    }

    private void AddTestMazeCell()
    {
        var mazeCellViewModel = _mazeCellViewModelFactory.Create();

        mazeCellViewModel.Row = 2;
        mazeCellViewModel.Column = 2;
        mazeCellViewModel.Test = "Lalala";

        MazeCellViewModels.Add(mazeCellViewModel);
    }
}
