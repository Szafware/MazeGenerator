using System.Collections.ObjectModel;

namespace MazeGenerator.Ui.ViewModels;

public interface IMainPageViewModel
{
    ObservableCollection<IMazeCellViewModel> MazeCellViewModels { get; }
    
    IMazeSettingsViewModel MazeSettingsViewModel { get; }

    int MazeWidth { get; set; }

    int MazeHeight { get; set; }
}
