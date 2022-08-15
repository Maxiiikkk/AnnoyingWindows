namespace AnnoyingWindows;

static class AnnoyingWindows
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();
        Application.Run(new AnnoyingWindowsForm());
    }
}