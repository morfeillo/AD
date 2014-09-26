using System;
using MySql.Data.MySqlClient;

namespace PHolaMysql
{
	public class Menu
	{
		public Menu ()
		{
			int numero=5;
			while (numero>0 || numero<4) {
				Console.Clear ();
				Console.WriteLine ("MENU");
				Console.WriteLine ("_____________________________");
				Console.WriteLine ("0.Salir");
				Console.WriteLine ("1.Nuevo");
				Console.WriteLine ("2.Modificar");
				Console.WriteLine ("3.Eliminar");
				Console.WriteLine ("4.Ver");

				string opcion = Console.ReadLine ();
				numero = int.Parse (opcion);

			}

			MySqlConnection mySqlConnection = new MySqlConnection(
				"Server=localhost;Database=dbprueba;User ID=root;Password=sistemas;"); 

			mySqlConnection.Open ();

			MySqlCommand mySqlCommand = mySqlConnection.CreateCommand ();

			string registro;

			switch (numero){
			case 0:
					Console.WriteLine ("Gracias por utilizar el programa... Hasta pronto! ");
					break;
			case 1:
					Console.WriteLine ("Introduzca el registro nuevo");
					registro = Console.ReadLine ();

					break;
				case 2:
					Console.WriteLine ("¿Que registro quiere modificar?");
					registro = Console.ReadLine ();
					break;
				case 3:
					Console.WriteLine ("¿Que registro quiere eliminar?");
					registro = Console.ReadLine ();
					break;
				case 4:
					Console.WriteLine ("¿Que registro quiere ver?");
					registro = Console.ReadLine ();
					break;
				default:
					break;
					}

			mySqlConnection.Close ();
		}

	}
}

