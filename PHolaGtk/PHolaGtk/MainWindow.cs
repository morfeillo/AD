using System;
using Gtk;

public partial class MainWindow: Gtk.Window
{	
	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();
	}

	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}

	protected void OnButton1Clicked (object sender, EventArgs e)
	{
		//throw new NotImplementedException ();
		Console.WriteLine ("Has hecho click en aceptar");
		//label prop para poner en el label lo q quieras
		//entry1.text para poner el texto que hay en el entry.
		labelSaludo.LabelProp = "Hola " + entry.Text;
	}
	protected void OnActionActivated (object sender, EventArgs e)
	{
		throw new NotImplementedException ();
	}
	
}
