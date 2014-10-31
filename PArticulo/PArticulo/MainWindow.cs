using System;
using Gtk;
using System.Data;

using SerpisAd;
using PArticulo;

public partial class MainWindow: Gtk.Window
{	
	private IDbConnection dbConnection;
	private ListStore listStore;
	private ListStore listStoreCat;

	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();

		deleteAction.Sensitive = false;
		editAction.Sensitive = false;
		deleteActionArticulo.Sensitive = false;
		editActionArticulo.Sensitive = false;

		dbConnection = App.Instance.DbConnection;

		treeViewCategoria.AppendColumn ("id", new CellRendererText (), "text", 0);
		treeViewCategoria.AppendColumn ("nombre", new CellRendererText (), "text", 1);
		listStoreCat = new ListStore (typeof(ulong), typeof(string));
		treeViewCategoria.Model = listStoreCat;
		leerCategoria ();


		treeViewCategoria.Selection.Changed += delegate {
			deleteAction.Sensitive= treeViewCategoria.Selection.CountSelectedRows () > 0;
			editAction.Sensitive= treeViewCategoria.Selection.CountSelectedRows () > 0;
		};

		treeViewArticulo.AppendColumn ("id", new CellRendererText (), "text", 0);
		treeViewArticulo.AppendColumn ("nombre", new CellRendererText (), "text", 1);
		treeViewArticulo.AppendColumn ("precio", new CellRendererText (), "text", 2);
		listStore = new ListStore (typeof(ulong), typeof(string),typeof(string));
		treeViewArticulo.Model = listStore;
		leerArticulo ();

		treeViewArticulo.Selection.Changed += delegate {
			deleteActionArticulo.Sensitive= treeViewArticulo.Selection.CountSelectedRows () > 0;
			editActionArticulo.Sensitive= treeViewArticulo.Selection.CountSelectedRows () > 0;
		};



	}


	private void leerCategoria() {
		IDbCommand dbCommand = dbConnection.CreateCommand ();
		dbCommand.CommandText = "select * from categoria";

		IDataReader dataReader = dbCommand.ExecuteReader ();
		while (dataReader.Read()) {
			object id = dataReader ["id"];
			object nombre = dataReader ["nombre"];
			listStoreCat.AppendValues (id, nombre);
		}
		dataReader.Close ();
	}
	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		dbConnection.Close ();
		Application.Quit ();
		a.RetVal = true;
	}

	protected void OnAddActionActivated (object sender, EventArgs e)
	{
		string insertSql = string.Format(
			"insert into categoria (nombre) values ('{0}')",
			"Nuevo " + DateTime.Now
			);
		Console.WriteLine ("insertSql={0}", insertSql);
		IDbCommand dbCommand = dbConnection.CreateCommand ();
		dbCommand.CommandText = insertSql;

		dbCommand.ExecuteNonQuery ();
	}

	protected void OnRefreshActionActivated (object sender, EventArgs e)
	{
		//para articulo
		listStore.Clear ();
		leerArticulo ();
	}

	protected void OnDeleteArticuloActionActivated (object sender, EventArgs e)
	{
		MessageDialog messageDialog = new MessageDialog (
			this,
			DialogFlags.Modal,
			MessageType.Question,
			ButtonsType.YesNo,
			"¿Quieres eliminar el registro?"
			);
		messageDialog.Title = Title;
		ResponseType response = (ResponseType) messageDialog.Run ();
		messageDialog.Destroy ();

		if (response != ResponseType.Yes)
			return;

		TreeIter treeIter;
		treeViewArticulo.Selection.GetSelected (out treeIter);
		object id = listStore.GetValue (treeIter, 0);
		string deleteSql = string.Format ("delete from articulo where id={0}", id);
		IDbCommand dbCommand = dbConnection.CreateCommand ();
		dbCommand.CommandText = deleteSql;
		listStore.Clear ();
		leerArticulo ();
		dbCommand.ExecuteNonQuery ();

	}

	protected void OnEditCategoriaActionActivated (object sender, EventArgs e)
	{
		TreeIter treeIter;
		treeViewCategoria.Selection.GetSelected (out treeIter);
		object id = listStoreCat.GetValue (treeIter, 0);
		CategoriaView categoriaView = new CategoriaView (id);
	}
	protected void OnEditArticuloActionActivated (object sender, EventArgs e)
	{
		TreeIter treeIter;
		treeViewArticulo.Selection.GetSelected (out treeIter);
		object id = listStore.GetValue (treeIter, 0);
		ArticuloView articuloView = new ArticuloView (id);
	}

	private void leerArticulo() {
		IDbCommand dbCommand = dbConnection.CreateCommand ();
		dbCommand.CommandText = "select * from articulo";

		IDataReader dataReader = dbCommand.ExecuteReader ();
		while (dataReader.Read()) {
			object id = dataReader ["id"];
			object nombre = dataReader ["nombre"];
			object precio = dataReader ["precio"].ToString();
			listStore.AppendValues (id, nombre,precio);
		}
		dataReader.Close ();
	}

	protected void OnNewAction2Activated (object sender, EventArgs e)
	{
		//NUEVO ARTICULO
		string insertSql = string.Format(
			"insert into articulo (nombre,precio) values ('Nuevo', '0,0')"
			);

		IDbCommand dbCommand = dbConnection.CreateCommand ();

		dbCommand.CommandText = insertSql;

		dbCommand.ExecuteNonQuery ();

		listStore.Clear ();
		leerArticulo ();
	}

	protected void OnNewAction1Activated (object sender, EventArgs e)
	{
		//NUEVA CATEGORIA
		string insertSql = string.Format(
			"insert into categoria (nombre) values ('{0}')",
			"Nuevo " + DateTime.Now
			);
		IDbCommand dbCommand = dbConnection.CreateCommand ();
		dbCommand.CommandText = insertSql;

		dbCommand.ExecuteNonQuery ();
		listStoreCat.Clear ();
		leerCategoria ();

	}

	protected void OnRefreshAction1Activated (object sender, EventArgs e)
	{
		//para categoria
		listStoreCat.Clear ();
		leerCategoria ();
	}

	protected void OnDeleteActionActivated (object sender, EventArgs e)
	{
		// elimiar categoria

	}

}
