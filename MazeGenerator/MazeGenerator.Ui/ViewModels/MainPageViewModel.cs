using CommunityToolkit.Mvvm.ComponentModel;
using MazeGenerator.Ui.Enums;
using MazeGenerator.Ui.Factories;
using MazeGenerator.Ui.Models;
using System.Collections.ObjectModel;
using System.Security.Cryptography;

namespace MazeGenerator.Ui.ViewModels;

public partial class MainPageViewModel : ObservableObject, IMainPageViewModel
{
    [ObservableProperty]
    private IMazeSettingsViewModel _mazeSettingsViewModel;

    [ObservableProperty]
    private ObservableCollection<IMazeCellViewModel> _mazeCellViewModels = new ObservableCollection<IMazeCellViewModel>();

    // TODO: Grid row/column count should be dependent on those
    //[ObservableProperty]
    //private int _mazeWidth;

    //[ObservableProperty]
    //private int _mazeHeight;

    private readonly IMazeCellViewModelFactory _mazeCellViewModelFactory;

    private readonly int _mazeCellGenerationDelay = 20;

    public MainPageViewModel(
        IMazeSettingsViewModel mazeSettingsViewModel,
        IMazeCellViewModelFactory mazeCellViewModelFactory)
    {
        MazeSettingsViewModel = mazeSettingsViewModel;
        _mazeCellViewModelFactory = mazeCellViewModelFactory;

        MazeSettingsViewModel.OnMazeCreate += OnMazeCreate;
    }

    private async Task OnMazeCreate(MazeSettings mazeSettings)
    {
        MazeCellViewModels.Clear();

        for (int x = 0; x < mazeSettings.MazeWidth; x++)
        {
            for (int y = 0; y < mazeSettings.MazeHeight; y++)
            {
                var mazeCellViewModel = _mazeCellViewModelFactory.Create();
                mazeCellViewModel.Column = x;
                mazeCellViewModel.Row = y;

                MazeCellViewModels.Add(mazeCellViewModel);
            }
        }

        await GenerateMaze(MazeCellViewModels.First(), null);
    }

    private async Task GenerateMaze(IMazeCellViewModel currentCell, IMazeCellViewModel previousCell)
    {
        currentCell.Uncover();
        RemoveWalls(currentCell, previousCell);

        await Task.Delay(_mazeCellGenerationDelay);

        IMazeCellViewModel randomUncoveredNeighborCell = null;

        do
        {
            randomUncoveredNeighborCell = GetRandomUncoveredNeighborCell(currentCell);

            if (randomUncoveredNeighborCell != null)
            {
                await GenerateMaze(randomUncoveredNeighborCell, currentCell);
            } 
        } while (randomUncoveredNeighborCell != null);
    }

    private IMazeCellViewModel GetRandomUncoveredNeighborCell(IMazeCellViewModel mazeCellViewModel)
    {
        var neighborCells = MazeCellViewModels.Where(m => (m.Column == mazeCellViewModel.Column - 1 && m.Row == mazeCellViewModel.Row) ||
                                                          (m.Column == mazeCellViewModel.Column + 1 && m.Row == mazeCellViewModel.Row) ||
                                                          (m.Column == mazeCellViewModel.Column && m.Row - 1 == mazeCellViewModel.Row) ||
                                                          (m.Column == mazeCellViewModel.Column && m.Row + 1 == mazeCellViewModel.Row));

        var uncoveredNeighborCells = neighborCells.Where(m => !m.IsCellVisible).ToList();

        var randomUncoveredNeighborCell = uncoveredNeighborCells.OrderBy(_ => RandomNumberGenerator.GetInt32(0, 5)).FirstOrDefault();

        return randomUncoveredNeighborCell;
    }

    private void RemoveWalls(IMazeCellViewModel currentCell, IMazeCellViewModel previousCell)
    {
        if (previousCell == null)
        {
            return;
        }

        if (previousCell.Column < currentCell.Column)
        {
            previousCell.RemoveWall(Directions.Right);
            currentCell.RemoveWall(Directions.Left);
            return;
        }

        if (previousCell.Column > currentCell.Column)
        {
            previousCell.RemoveWall(Directions.Left);
            currentCell.RemoveWall(Directions.Right);
            return;
        }

        if (previousCell.Row < currentCell.Row)
        {
            previousCell.RemoveWall(Directions.Down);
            currentCell.RemoveWall(Directions.Up);
            return;
        }

        if (previousCell.Row > currentCell.Row)
        {
            previousCell.RemoveWall(Directions.Up);
            currentCell.RemoveWall(Directions.Down);
            return;
        }
    }
}
