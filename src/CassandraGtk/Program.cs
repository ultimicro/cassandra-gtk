namespace CassandraGtk;

using GLib;
using Application = Gtk.Application;

public static class Program
{
    public static void Main()
    {
        // Initialize GTK.
        Application.Init();

        // Intercept CTRL+C.
        Console.CancelKeyPress += (object? sender, ConsoleCancelEventArgs e) =>
        {
            Application.Quit();
            e.Cancel = true;
        };

        // Initialize the application.
        using var app = new Application("inc.ultima.cassandra-gtk", ApplicationFlags.None);

        if (!app.Register(Cancellable.Current))
        {
            // The application is already running.
            return;
        }

        // Create the main window.
        var window = new MainWindow();
        app.AddWindow(window);

        // Enter the event loop.
        window.ShowAll();
        Application.Run();
    }
}
