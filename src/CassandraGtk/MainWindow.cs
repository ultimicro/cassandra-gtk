namespace CassandraGtk;

using Gtk;

internal sealed class MainWindow : Window
{
    public MainWindow()
        : base(WindowType.Toplevel)
    {
        this.Titlebar = CreateTitlebar();
    }

    protected override void OnDestroyed()
    {
        Application.Quit();
        base.OnDestroyed();
    }

    private static HeaderBar CreateTitlebar()
    {
        // Create the bar.
        var bar = new HeaderBar()
        {
            Title = "Cassandra GTK",
            ShowCloseButton = true,
        };

        // Connect button.
        var connect = new Button()
        {
            Label = "Connect",
        };

        bar.PackStart(connect);

        return bar;
    }
}
