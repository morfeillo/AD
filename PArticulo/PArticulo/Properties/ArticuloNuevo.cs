using System;

namespace PArticulo
{
	public partial class ArticuloNuevo : Gtk.Window
	{
		public ArticuloNuevo () : 
				base(Gtk.WindowType.Toplevel)
		{
			this.Build ();
		}
	}
}

