namespace CassandraGtk;

using Gtk;

internal sealed class NewConnection : Window
{
    public NewConnection()
    {
        this.Titlebar = this.CreateTitleBar();
        this.Child = this.CreateMainWidget();
        this.DefaultWidth = 500;
        this.TransientFor = ((Application?)Gio.Application.GetDefault())?.ActiveWindow;
        this.SetModal(true);
    }

    private Widget CreateTitleBar()
    {
        // Label.
        var label = Label.New("New Connection");

        label.AddCssClass("title");

        // Cancel.
        var cancel = Button.NewWithLabel("Cancel");

        cancel.OnClicked += (sender, e) => this.Close();

        // Save.
        var save = Button.NewWithLabel("Save");

        save.AddCssClass("suggested-action");

        // Bar.
        var bar = new HeaderBar()
        {
            TitleWidget = label,
            ShowTitleButtons = false,
        };

        bar.PackStart(cancel);
        bar.PackEnd(save);

        return bar;
    }

    private Widget CreateMainWidget()
    {
        var box = new Box()
        {
            MarginTop = 15,
            MarginBottom = 15,
            MarginStart = 15,
            MarginEnd = 15,
        };

        box.SetOrientation(Orientation.Vertical);

        box.Append(this.CreateContactPointsWidget());

        return box;
    }

    private Widget CreateContactPointsWidget()
    {
        var main = Box.New(Orientation.Vertical, 6);

        // Label.
        var label = Label.New("Contact Points:");

        label.Halign = Align.Start;

        main.Append(label);

        // List.
        var editor = Box.New(Orientation.Horizontal, 6);
        var list = new ColumnView()
        {
            Hexpand = true,
            Reorderable = false,
        };

        var address = ColumnViewColumn.New("Address", null);
        var port = ColumnViewColumn.New("Port", null);

        address.Expand = true;

        list.AppendColumn(address);
        list.AppendColumn(port);

        editor.Append(list);

        // Actions.
        var actions = Box.New(Orientation.Vertical, 6);
        var @new = Button.NewWithLabel("New");
        var remove = Button.NewWithLabel("Remove");
        var up = Button.NewWithLabel("Up");
        var down = Button.NewWithLabel("Down");

        actions.Append(@new);
        actions.Append(remove);
        actions.Append(up);
        actions.Append(down);

        editor.Append(actions);
        main.Append(editor);

        return main;
    }
}
