namespace MazeGenerator.Ui;

public partial class App : Application
{
    private readonly int _windowWidth = 1200;
    private readonly int _windowHeight = 900;

    public App()
    {
        InitializeComponent();

        MainPage = new AppShell();
    }

    protected override Window CreateWindow(IActivationState activationState)
    {
        var window = base.CreateWindow(activationState);

        window.Width = _windowWidth;
        window.Height = _windowHeight;

        return window;
    }
}
