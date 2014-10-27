using System;
using Gtk;
using System.Data;

using SerpisAd;
using PArticulo;

public partial class MainWindow: Gtk.Window
{	
	private IDbConnection dbConnection;
	private ListStore listStore;

	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();

		deleteAction.Sensitive = false;
		editAction.Sensitive = false;

		dbConnection = App.Instance.DbConnection;

		treeViewCategoria.AppendColumn ("id", new CellRendererText (), "text", 0);
		treeViewCategoria.AppendColumn ("nombre", new CellRendererText (), "text", 1);
		listStore = new ListStore (typeof(ulong), typeof(string));
		treeViewCategoria.Model = listStore;
		leerCategoria ();

		treeViewCategoria.Selection.Changed += selectionChanged;

		treeViewArticulo.AppendColumn ("id", new CellRendererText (), "text", 0);
		treeViewArticulo.AppendColumn ("nombre", new CellRendererText (), "text", 1);
		treeViewArticulo.AppendColumn ("precio", new CellRendererText (), "text", 2);
		/*
		treeViewArticulo.AppendColumn("precio",new CellRendererText (), new TreeCellDataFunc(delegate(TreeViewColumn tree_columm, CellRenderer CellView, TreeModel tree_model, TreeIter iter){
			CellRendererText cellRendererText = (CellRendererText)CellView;
			object value = tree_model.GetValue(iter,0);
			cellRendererText.Text=value.ToString();
		}
		*/
		listStore = new ListStore (typeof(ulong), typeof(string),typeof(string));
		treeViewArticulo.Model = listStore;
		leerArticulo ();

	}


	private void selectionChanged (object sender, EventArgs e) {
		Console.WriteLine ("selectionChanged");
		bool hasSelected = treeViewArticulo.Selection.CountSelectedRows () > 0;
		deleteAction.Sensitive = hasSelected;
		editAction.Sensitive = hasSelected;
	}

	private void leerCategoria() {
		IDbCommand dbCommand = dbConnection.CreateCommand ();
		dbCommand.CommandText = "select * from categoria";

		IDataReader dataReader = dbCommand.ExecuteReader ();
		while (dataReader.Read()) {
			object id = dataReader ["id"];
			object nombre = dataReader ["nombre"];
			listStore.AppendValues (id, nombre);
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
		listStore.Clear ();
		leerCategoria ();
	}

	protected void OnDeleteActionActivated (object sender, EventArgs e)
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
		string deleteSql = string.Format ("delete from categoria where id={0}", id);
		IDbCommand dbCommand = dbConnection.CreateCommand ();
		dbCommand.CommandText = deleteSql;

		dbCommand.ExecuteNonQuery ();
	}

	protected void OnEditActionActivated (object sender, EventArgs e)
	{
		TreeIter treeIter;
		treeViewArticulo.Selection.GetSelected (out treeIter);
		object id = listStore.GetValue (treeIter, 0);
		CategoriaView categoriaView = new CategoriaView (id);
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
}
