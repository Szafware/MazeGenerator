using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MazeGenerator.Ui.Enums;

namespace MazeGenerator.Ui.ViewModels;

public partial class MazeCellViewModel : ObservableObject, IMazeCellViewModel
{
    [ObservableProperty]
    private int _row;

    [ObservableProperty]
    private int _column;

    [ObservableProperty]
    private bool _isCellVisible;

    [ObservableProperty]
    private bool _isLeftWallVisible = true;

    [ObservableProperty]
    private bool _isTopWallVisible = true;

    [ObservableProperty]
    private bool _isRightWallVisible = true;

    [ObservableProperty]
    private bool _isBottomWallVisible = true;

    [RelayCommand]
    private void Loaded()
    {
    }

    public void Uncover()
    {
        IsCellVisible = true;
    }

    public void RemoveWall(Directions direction)
    {
        switch (direction)
        {
            case Directions.Left:
                IsLeftWallVisible = false;
                break;
            case Directions.Up:
                IsTopWallVisible = false;
                break;
            case Directions.Right:
                IsRightWallVisible = false;
                break;
            case Directions.Down:
                IsBottomWallVisible = false;
                break;
        }
    }

    public override string ToString()
    {
        return $"X: {Column} | Y: {Row}";
    }
}
