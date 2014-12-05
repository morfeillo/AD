using Gtk;
using MySql.Data.MySqlClient;
using System;
using System.Data;


public partial class MainWindow: Gtk.Window
{	
	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();

		MySqlConnection MySqlConnection = new MySqlConnection (
			"DataSource=localhost;Database=dbprueba;User ID=root;Password=sistemas");
		MySqlConnection.Open ();
		string selectSql = "select * from articulo";

		IDbDataAdapter dbDataAdapter = new MySqlDataAdapter (selectSql,MySqlConnection);

		DataSet dataSet = new DataSet ();

		dbDataAdapter.Fill (dataSet);
	}

	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}
}
