using System;
using System.Data;

using SerpisAd;
using PArticulo;

namespace PArticulo
{
	public partial class NuevoArticulo : Gtk.Window
	{
		public NuevoArticulo () : 
				base(Gtk.WindowType.Toplevel)
		{
			this.Build ();

		}
		public NuevoArticulo(object id) : this() {
			this.id = id;
			IDbCommand dbCommand = 
				App.Instance.DbConnection.CreateCommand ();
			dbCommand.CommandText = String.Format (
				"select * from articulo where id={0}", id
				);

			IDataReader dataReader = dbCommand.ExecuteReader ();
			dataReader.Read ();

			entryArticulo.Text = dataReader ["nombre"].ToString ();
			entryPrecio.Text = dataReader ["precio"].ToString ();
			entryCategoria.Text = dataReader ["categoria"].ToString ();

			dataReader.Close ();
		}
	}
}

