package serpis.ad;

import javax.persistence.Entity;




public class Categoria {

	 private Long id;
	 private String nombre;

@Entity
	 public Categoria() {
		
	}

	public Categoria(String nombre) {
		super();
		this.nombre = nombre;
	}

	public Long getId() {
		return id;
	}

	public void setId(Long id) {
		this.id = id;
	}

	public String getNombre() {
		return nombre;
	}

	public void setNombre(String nombre) {
		this.nombre = nombre;
	}
	 


}
