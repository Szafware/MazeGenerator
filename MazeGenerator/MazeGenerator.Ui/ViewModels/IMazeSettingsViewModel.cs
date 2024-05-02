using CommunityToolkit.Mvvm.Input;
using MazeGenerator.Ui.Models;

namespace MazeGenerator.Ui.ViewModels
{
    public interface IMazeSettingsViewModel
    {
        int MazeWidth { get; set; }

        int MazeHeight { get; set; }

        event Func<MazeSettings, Task> OnMazeCreate;

        IAsyncRelayCommand GenerateMazeCommand { get; }
    }
}
