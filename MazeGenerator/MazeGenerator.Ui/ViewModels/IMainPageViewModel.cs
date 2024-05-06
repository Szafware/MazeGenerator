using System.Collections.ObjectModel;

namespace MazeGenerator.Ui.ViewModels;

public interface IMainPageViewModel
{
    int MazeWidth { get; }
    int MazeHeight { get; }

    ObservableCollection<IMazeCellViewModel> MazeCellViewModels { get; }
    
    IMazeSettingsViewModel MazeSettingsViewModel { get; }
}
