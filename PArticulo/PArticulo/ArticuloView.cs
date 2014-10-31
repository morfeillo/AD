using System;
using System.Data;

using SerpisAd;
using PArticulo;

namespace PArticulo
{
	public partial class ArticuloView : Gtk.Window
	{
		private object id;
		public ArticuloView () : base(Gtk.WindowType.Toplevel)
		{
			this.Build ();
		}
		public ArticuloView(object id) : this() {
			this.id = id;
			IDbCommand dbCommand = 
				App.Instance.DbConnection.CreateCommand ();
			dbCommand.CommandText = String.Format (
				"select * from articulo where id={0}", id
				);

			IDataReader dataReader = dbCommand.ExecuteReader ();
			dataReader.Read ();

			entryArticulo.Text = dataReader ["nombre"].ToString ();
			entryPrecio.Text = dataReader ["precio"].ToString ().Replace(',','.');
			entryCategoria.Text = dataReader ["categoria"].ToString ();

			dataReader.Close ();
		}

		protected void OnSaveActionActivated (object sender, EventArgs e)
		{
			IDbCommand dbCommand = 
				App.Instance.DbConnection.CreateCommand ();
			dbCommand.CommandText = String.Format (
				"update articulo set nombre=@nombre, categoria=@categoria, precio=@precio where id={0}", id
				);

			dbCommand.AddParameter ("nombre", entryArticulo.Text);
			dbCommand.AddParameter ("categoria", entryCategoria.Text);
			dbCommand.AddParameter ("precio", entryPrecio.Text.Replace(',','.'));

			dbCommand.ExecuteNonQuery ();

			Destroy ();
	}
}
}

