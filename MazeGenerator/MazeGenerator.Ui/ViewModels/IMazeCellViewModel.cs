using CommunityToolkit.Mvvm.Input;
using MazeGenerator.Ui.Enums;

namespace MazeGenerator.Ui.ViewModels;

public interface IMazeCellViewModel
{
    int Row { get; set; }
    int Column { get; set; }

    bool IsCellVisible { get; }

    bool IsLeftWallVisible { get; }
    bool IsTopWallVisible { get; }
    bool IsRightWallVisible { get; }
    bool IsBottomWallVisible { get; }

    IRelayCommand LoadedCommand { get; }

    void Uncover();
    void RemoveWall(Directions direction);
}
