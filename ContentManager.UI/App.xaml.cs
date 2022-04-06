using System;

namespace ContentManager.UI;

public partial class App
{
    public App() => Activated += StartElmish;

    private void StartElmish(object? sender, EventArgs e)
    {
        Activated -= StartElmish;
        Core.App.Run(MainWindow);
    }
}