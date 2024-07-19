using GestionDeBiblioteca.Models;

var libro1 = new Libro("Davids",2020,"Medina David","12345","Romance",10000000);
var libro2 = new Libro("StevenD",1010,"Urrego Steven","54321","Novela",40000000);

var biblioteca = new Biblioteca();

biblioteca.AgregarLibro(libro1);

biblioteca.AgregarLibro(libro2);

biblioteca.MostrarLibros();

biblioteca.EliminarLibro(libro1);