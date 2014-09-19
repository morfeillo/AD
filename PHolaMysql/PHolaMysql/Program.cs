using System;
using MySql.Data.MySqlClient;

namespace PHolaMysql
{
	class MainClass
	{
		public static void Main (string[] args)
		{

			//Se crea la conexión

			MySqlConnection mySqlConnection = new MySqlConnection(
				"Server=localhost;Database=dbprueba;User ID=root;Password=sistemas;"); 

			//Se abre la conexión

			mySqlConnection.Open ();

			//Para INSERT

			MySqlCommand mySqlCommand = mySqlConnection.CreateCommand ();
			mySqlCommand.CommandText = string.Format("insert into categoria (nombre) values ('{0}')",
			                                         DateTime.Now); 
			// {0} sustitucion de cadenas por lo que hay fuera, en este caso el DateTime.Now 
			//SOLO ACONSEJABLE CUANDO EL DATO NO SEA INTRODUCIDO POR EL USUARIO.PUEDEN ROBAR DATOS O USAR CODIGO MALICISO

			mySqlCommand.ExecuteNonQuery ();
			//ejecutar comandos de SQL de actualizacion y inserccion.

//___________________________________________________________________________________________________________

			//Para el SELECT


			MySqlCommand mySqlCommand1 = mySqlConnection.CreateCommand ();

			//sentencia select

			mySqlCommand1.CommandText = string.Format("select * from categoria"); 


			MySqlDataReader mySqlDataReader = mySqlCommand1.ExecuteReader ();

			//Devuelve el numero de campos que hay.
			Console.WriteLine ("FieldCount={0}",mySqlDataReader.FieldCount);

			//Devuelve las columnas con el nombre de la las columnas.
			for (int index=0; index < mySqlDataReader.FieldCount; index++) {
				Console.WriteLine ("colum {0} ={1}", index, mySqlDataReader.GetName (index));
			}
			//si se el read esta ok, es true guarda los reader en un object(OBJETO DE MAXIMA ESCALA, CUALQUIER COSAS ES UN OBJECT)
			// IMPRIME POR PANTALLA EL ID Y EL NOMBRE
			while (mySqlDataReader.Read()) {
				object id = mySqlDataReader ["id"];
				object nombre = mySqlDataReader ["nombre"];
				Console.WriteLine ("id={0} nombre={1}", id, nombre);
			}


			//Se cierra la conexión SIEMPRE SE CIERRA LA CONEXION!!
			mySqlConnection.Close ();
		}
	}
}
