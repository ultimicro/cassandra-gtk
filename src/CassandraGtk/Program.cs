namespace CassandraGtk;

using Gio;
using Gtk;
using Application = Gtk.Application;

public static class Program
{
    public static int Main()
    {
        // Initialize the application.
        var app = Application.New("inc.ultima.cassandra-gtk", ApplicationFlags.DefaultFlags);

        app.OnActivate += OnActivate;

        // Intercept CTRL+C.
        Console.CancelKeyPress += (object? sender, ConsoleCancelEventArgs e) =>
        {
            app.Quit();
            e.Cancel = true;
        };

        // Enter the event loop.
        return app.Run();
    }

    private static void OnActivate(Gio.Application sender, EventArgs e)
    {
        // Create the window.
        var window = ApplicationWindow.New((Application)sender);

        window.DefaultWidth = 1000;
        window.DefaultHeight = 500;

        // Create title bar and main widget.
        var title = new TitleBar();
        var main = new MainWidget();

        title.SetResizeStartChild(false);
        main.SetResizeStartChild(false);

        title.SetResizeEndChild(true);
        main.SetResizeEndChild(true);

        window.Titlebar = title;
        window.Child = main;

        // Synchronize between title bar and main widget.
        title.OnNotify += (sender, e) =>
        {
            var name = e.Pspec.GetName();

            if (name == "position" && main.Position != title.Position)
            {
                main.Position = title.Position;
            }
        };

        main.OnNotify += (sender, e) =>
        {
            var name = e.Pspec.GetName();

            if (name == "position" && title.Position != main.Position)
            {
                title.Position = main.Position;
            }
        };

        // Set initial separator position.
        title.Position = 250;

        window.Show();
    }
}
