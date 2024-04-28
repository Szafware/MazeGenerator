using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MazeGenerator.Ui.Models;

namespace MazeGenerator.Ui.ViewModels
{
    public partial class MazeSettingsViewModel : ObservableObject, IMazeSettingsViewModel
    {
        [ObservableProperty]
        private int _mazeWidth = 10;

        [ObservableProperty]
        private int _mazeHeight = 10;

        public event Func<MazeSettings, Task> OnMazeCreate;

        [RelayCommand]
        public async Task GenerateMaze()
        {
            var mazeSettings = new MazeSettings
            {
                MazeWidth = MazeWidth,
                MazeHeight = MazeHeight
            };

            await OnMazeCreate?.Invoke(mazeSettings);
        }
    }
}
