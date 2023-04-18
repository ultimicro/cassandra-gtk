namespace CassandraGtk;

using Gtk;

internal sealed class TitleBar : Paned
{
    public TitleBar()
    {
        this.SetStartChild(this.CreateConnectionHeader());
        this.SetEndChild(new HeaderBar());
    }

    private Widget CreateConnectionHeader()
    {
        // Label.
        var label = Label.New("Connections");

        label.AddCssClass("title");

        // New.
        var @new = Button.NewWithLabel("New");

        @new.OnClicked += this.NewConnection;

        // Bar.
        var bar = new HeaderBar()
        {
            TitleWidget = label,
            ShowTitleButtons = false,
        };

        bar.PackEnd(@new);

        return bar;
    }

    private void NewConnection(Button sender, EventArgs e)
    {
        var dialog = new NewConnection();

        dialog.Show();
    }
}
