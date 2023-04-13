namespace CassandraGtk;

using Gtk;

internal sealed class OpenConnection : Dialog
{
    public OpenConnection(Window parent)
        : base("Open a connection", parent, DialogFlags.Modal | DialogFlags.DestroyWithParent | DialogFlags.UseHeaderBar, "Connect", ResponseType.None)
    {
    }
}
