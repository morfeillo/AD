using Gtk;
using MySql.Data.MySqlClient;
using System;


public partial class MainWindow: Gtk.Window
{	
	//Se crea aqui para poder usarlo en todos los métodos.
	private ListStore listStore; 
	private MySqlConnection mySqlConnection;
	private MySqlCommand mySqlCommand;
	private MySqlDataReader mySqlDataReader;

	protected void Cargar(){

		//se abre la conexion
		mySqlConnection = new MySqlConnection(
			"Server=localhost;Database=dbprueba;User ID=root;Password=sistemas;");
		mySqlConnection.Open ();


		listStore = new ListStore (typeof(string),typeof(string)); // typeof(string) para decirle el tipo de datos q le vas a meter.


		treeView.Model = listStore; // en java treeView.setModel(listStore);

		mySqlCommand = mySqlConnection.CreateCommand ();
		mySqlCommand.CommandText = string.Format("select * from categoria"); 
		mySqlDataReader = mySqlCommand.ExecuteReader ();

		while (mySqlDataReader.Read()) {
			object id = mySqlDataReader ["id"].ToString();
			object nombre = mySqlDataReader ["nombre"];
			listStore.AppendValues (id, nombre);
		}

		mySqlDataReader.Close ();

	}

	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();
		Cargar ();
		//Añadir columnas, si no hay datos no sale, pero la columna está añadida
		treeView.AppendColumn ("id", new CellRendererText (), "text", 0); // nombre, tipoque vamos a dibujar, tipo texto, columna index
		treeView.AppendColumn ("nombre", new CellRendererText (), "text", 1);
	}


	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		mySqlConnection.Close ();
		Application.Quit ();
		a.RetVal = true;

	}
	protected void OnAddActionActivated (object sender, EventArgs e)
	{


		mySqlCommand.CommandText = string.Format("insert into categoria (nombre) values ('{0}')",
		                                         DateTime.Now); 
		mySqlCommand.ExecuteNonQuery ();
		//lo copia en la base de datos

		//hacemos clear y limpiamos
		listStore.Clear();
		//cargamos clase para reimprimir.
		Cargar ();
		              

	}
	
	protected void OnRefreshActionActivated (object sender, EventArgs e)
	{
		listStore.Clear ();
		Cargar ();

	}

}
