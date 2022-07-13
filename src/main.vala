class CassandraGtk : Gtk.Application {
    public CassandraGtk () {
        Object (application_id: "inc.ultima.cassandra-gtk");
    }

    protected override void activate () {
        // Creat main window.
        var window = new Gtk.ApplicationWindow (this);

        window.title = "Cassandra GTK";
        window.show_menubar = true;

        this.menubar = this.create_menu_bar ();

        // Show main window.
        window.show ();
    }

    private GLib.MenuModel create_menu_bar () {
        var bar = new GLib.Menu ();

        bar.append_submenu ("_File", this.create_file_menu ());

        return bar;
    }

    private GLib.MenuModel create_file_menu () {
        var menu = new GLib.Menu ();

        // Open Connection.
        var open_connection = new GLib.MenuItem ("_Open Connection...", null);

        menu.append_item (open_connection);

        // Exit.
        var section = new GLib.Menu ();
        var exit = new GLib.MenuItem ("_Exit", null);

        section.append_item (exit);

        menu.append_section (null, section);

        return menu;
    }
}

int main (string[] args) {
    var app = new CassandraGtk ();

    try {
        if (!app.register (null)) {
            stderr.printf ("The application is already running");
            return 1;
        }
    } catch (GLib.Error ex) {
        stderr.printf ("%s", ex.message);
        return 1;
    }

    return app.run (args);
}
