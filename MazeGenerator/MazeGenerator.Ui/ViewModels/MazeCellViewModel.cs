using CommunityToolkit.Mvvm.ComponentModel;

namespace MazeGenerator.Ui.ViewModels;

public partial class MazeCellViewModel : ObservableObject, IMazeCellViewModel
{
    [ObservableProperty]
    private int _row;

    [ObservableProperty]
    private int _column;

    [ObservableProperty]
    private string _test;
}
