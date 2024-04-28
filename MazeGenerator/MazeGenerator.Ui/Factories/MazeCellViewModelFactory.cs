using MazeGenerator.Ui.ViewModels;

namespace MazeGenerator.Ui.Factories;

public class MazeCellViewModelFactory : IMazeCellViewModelFactory
{
    private readonly IServiceProvider _serviceProvider;

    public MazeCellViewModelFactory(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public IMazeCellViewModel Create()
    {
        var mazeCellViewModel = _serviceProvider.GetRequiredService<IMazeCellViewModel>();

        return mazeCellViewModel;
    }
}
