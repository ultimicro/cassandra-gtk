namespace CassandraGtk;

using Gtk;

internal sealed class NewConnection : Window
{
    public NewConnection()
    {
        this.TransientFor = ((Application?)Gio.Application.GetDefault())?.ActiveWindow;
        this.SetModal(true);
    }
}
