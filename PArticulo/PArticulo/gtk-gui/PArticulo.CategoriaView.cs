
// This file has been generated by the GUI designer. Do not modify.
namespace PArticulo
{
	public partial class CategoriaView
	{
		private global::Gtk.UIManager UIManager;
		private global::Gtk.Action saveAction;
		private global::Gtk.VBox vbox5;
		private global::Gtk.Toolbar toolbar4;
		private global::Gtk.HBox hbox1;
		private global::Gtk.Label Nombre;
		private global::Gtk.Entry entryNombre;

		protected virtual void Build ()
		{
			global::Stetic.Gui.Initialize (this);
			// Widget PArticulo.CategoriaView
			this.UIManager = new global::Gtk.UIManager ();
			global::Gtk.ActionGroup w1 = new global::Gtk.ActionGroup ("Default");
			this.saveAction = new global::Gtk.Action ("saveAction", null, null, "gtk-save");
			w1.Add (this.saveAction, null);
			this.UIManager.InsertActionGroup (w1, 0);
			this.AddAccelGroup (this.UIManager.AccelGroup);
			this.Name = "PArticulo.CategoriaView";
			this.Title = global::Mono.Unix.Catalog.GetString ("CategoriaView");
			this.WindowPosition = ((global::Gtk.WindowPosition)(4));
			// Container child PArticulo.CategoriaView.Gtk.Container+ContainerChild
			this.vbox5 = new global::Gtk.VBox ();
			this.vbox5.Name = "vbox5";
			this.vbox5.Spacing = 6;
			// Container child vbox5.Gtk.Box+BoxChild
			this.UIManager.AddUiFromString ("<ui><toolbar name='toolbar4'><toolitem name='saveAction' action='saveAction'/></toolbar></ui>");
			this.toolbar4 = ((global::Gtk.Toolbar)(this.UIManager.GetWidget ("/toolbar4")));
			this.toolbar4.Name = "toolbar4";
			this.toolbar4.ShowArrow = false;
			this.vbox5.Add (this.toolbar4);
			global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.vbox5 [this.toolbar4]));
			w2.Position = 0;
			w2.Expand = false;
			w2.Fill = false;
			// Container child vbox5.Gtk.Box+BoxChild
			this.hbox1 = new global::Gtk.HBox ();
			this.hbox1.Name = "hbox1";
			this.hbox1.Spacing = 6;
			// Container child hbox1.Gtk.Box+BoxChild
			this.Nombre = new global::Gtk.Label ();
			this.Nombre.Name = "Nombre";
			this.Nombre.LabelProp = global::Mono.Unix.Catalog.GetString ("Nombre: ");
			this.hbox1.Add (this.Nombre);
			global::Gtk.Box.BoxChild w3 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.Nombre]));
			w3.Position = 0;
			w3.Expand = false;
			w3.Fill = false;
			// Container child hbox1.Gtk.Box+BoxChild
			this.entryNombre = new global::Gtk.Entry ();
			this.entryNombre.CanFocus = true;
			this.entryNombre.Name = "entryNombre";
			this.entryNombre.IsEditable = true;
			this.entryNombre.InvisibleChar = '•';
			this.hbox1.Add (this.entryNombre);
			global::Gtk.Box.BoxChild w4 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.entryNombre]));
			w4.Position = 1;
			this.vbox5.Add (this.hbox1);
			global::Gtk.Box.BoxChild w5 = ((global::Gtk.Box.BoxChild)(this.vbox5 [this.hbox1]));
			w5.Position = 1;
			w5.Expand = false;
			w5.Fill = false;
			this.Add (this.vbox5);
			if ((this.Child != null)) {
				this.Child.ShowAll ();
			}
			this.DefaultWidth = 400;
			this.DefaultHeight = 300;
			this.Show ();
			this.saveAction.Activated += new global::System.EventHandler (this.OnSaveActionActivated);
		}
	}
}
