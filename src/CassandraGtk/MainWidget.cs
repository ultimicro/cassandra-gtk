namespace CassandraGtk;

using Gtk;

internal sealed class MainWidget : Paned
{
    public MainWidget()
    {
        this.SetStartChild(CreateLeftPane());
        this.SetEndChild(CreateRightPane());
    }

    private static Widget CreateLeftPane()
    {
        return new ListBox();
    }

    private static Widget CreateRightPane()
    {
        return new Box();
    }
}
