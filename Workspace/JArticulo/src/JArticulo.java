import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.Scanner;


public class JArticulo {

	private static Scanner scanner= new Scanner(System.in);
	
	public static void main(String[] args) throws ClassNotFoundException, SQLException {
	
		Connection connection = DriverManager.getConnection(
				"jdbc:mysql://localhost/dbprueba?user=root&password=sistemas"
			);
		

	System.out.println("______________Menu______________ ");
	System.out.println("|0.- Salir                      |");
	System.out.println("|1.- Nuevo                      |");
	System.out.println("|2.- Editar                     |");
	System.out.println("|3.- Eliminar                   |");
	System.out.println("|4.- Visualizar                 |");
	System.out.println("|_______________________________| ");
	
	System.out.println("Introduzca la opción a realizar");
	int opcion = scanner.nextInt();
	scanner.reset();
	switch (opcion){
		case 0: 
			System.exit(0); 
			break;
		case 1: 
			System.out.println("Introduzca el nuevo registro");
			System.out.println("Nuevo Nombre: ");
			String nombre= scanner.nextLine();
			nombre=scanner.nextLine();
			System.out.println("Nueva Categoria: ");
			int categoria= scanner.nextInt();
			System.out.println("Nuevo precio: ");
			float precio = scanner.nextFloat();
			
			System.out.println("El nombre que has introducido es: "+nombre);
			System.out.println("La categoria que has introducido es: "+categoria);
			System.out.println("El precio que has introducido es: "+precio);
		
			PreparedStatement preparedStatement = connection.prepareStatement("INSERT INTO articulo (nombre,categoria,precio) VALUES (?,?,?)");
			
			preparedStatement.setString(1, nombre);
			preparedStatement.setInt(2, categoria);
			preparedStatement.setFloat(3, precio);
			int resultSet = preparedStatement.executeUpdate();
			
		//	resultSet.close();
			preparedStatement.close();
			connection.close();
			break;
		case 2: 
			
			break;
		case 3: 
			
			break;
		case 4:
			PreparedStatement preparedStatementVisualizar = connection.prepareStatement("select * from categoria where id = ?");
			preparedStatementVisualizar.setLong(1, 7);
			ResultSet resultSet4 = preparedStatementVisualizar.executeQuery();
			
			while (resultSet4.next()) 
				System.out.printf("id=%4s nombre=%s\n", 
					resultSet4.getObject("id"), resultSet4.getObject("nombre"));
			resultSet4.close();
			preparedStatementVisualizar.close();
			connection.close();
			
			break;
	}
	
	
	
	connection.close();
	}
}
