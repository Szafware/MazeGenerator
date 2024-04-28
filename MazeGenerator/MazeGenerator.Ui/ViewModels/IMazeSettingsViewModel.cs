using MazeGenerator.Ui.Models;

namespace MazeGenerator.Ui.ViewModels
{
    public interface IMazeSettingsViewModel
    {
        event Func<MazeSettings, Task> OnMazeCreate;
    }
}
