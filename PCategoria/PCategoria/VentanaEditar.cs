using System;

namespace PCategoria
{
	public partial class VentanaEditar : Gtk.Window
	{
		public VentanaEditar () : 
				base(Gtk.WindowType.Toplevel)
		{
			this.Build ();
		}
	}
}

