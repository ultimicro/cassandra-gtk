namespace CassandraGtk;

using Gtk;

internal sealed class MainWindow : Window
{
    public MainWindow()
        : base(WindowType.Toplevel)
    {
        this.Titlebar = this.CreateTitlebar();
    }

    protected override void OnDestroyed()
    {
        Application.Quit();
        base.OnDestroyed();
    }

    private HeaderBar CreateTitlebar()
    {
        // Create the bar.
        var bar = new HeaderBar()
        {
            Title = "Cassandra GTK",
            ShowCloseButton = true,
        };

        // Connect button.
        var connect = new Button();

        connect.Label = "Connect";
        connect.Clicked += this.OpenConnection;

        bar.PackStart(connect);

        return bar;
    }

    private void OpenConnection(object? sender, EventArgs e)
    {
        var dialog = new OpenConnection(this);

        dialog.ShowAll();
    }
}
