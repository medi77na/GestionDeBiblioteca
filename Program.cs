using GestionDeBiblioteca.Models;

// Instancia de libros
var libro1 = new Libro("Davids",2020,"Medina David","12345","Romance",10000000);
var libro2 = new Libro("StevenD",1010,"Urrego Steven","54321","Novela",40000000);

// Instancia de biblioteca
var biblioteca = new Biblioteca();

// Método agregar libros a la biblioteca
biblioteca.AgregarLibro(libro1);
biblioteca.AgregarLibro(libro2);


MenuOpciones();

int MostrarMenu()
{
    while (true)
    {
        Console.WriteLine(@"MENU OPCIONES
----------------------------------------------------------------
1. Agregar libro
2. Eliminar libro
3. Buscar libro por título
4. Mostrar todos los libros
5. Agregar descuento a un libro
6. Salir
----------------------------------------------------------------");
        Console.Write("Ingrese una opción: ");

        string entrada = Console.ReadLine();
        bool esConvertible = int.TryParse(entrada, out int opcion);

        if (esConvertible)
        {
            return opcion; 
        }
        else
        {
            Console.WriteLine("Error: La entrada no es un número entero válido. Por favor, intente de nuevo.");
        }
    }
}

void MenuOpciones()
{
    int opcion;

    do
    {
        opcion = MostrarMenu(); 
        switch (opcion)
        {
            case 1:
                biblioteca.AgregarLibro(solicitarInformacionLibro());
                break;
            case 2:
                SolicitarLibroEliminar();
                break;
            case 3:
                BuscarTitulo();
                break;
            case 4:
                biblioteca.MostrarLibros();
                break;
            case 5:
                biblioteca.SolicitarDescuento();
                break;
            case 6:
                Console.WriteLine("Hsta luego.");
                break;
            default:
                Console.Write("Opción incorrecta.");
                break;
        }
    } while (opcion != 6);
    
}

Libro solicitarInformacionLibro()
{
    Console.Write("Ingrese el título del libro: ");
    var titulo = Console.ReadLine();

    Console.Write("Ingrese el año de publicación: ");
    var anoPublicacion = Convert.ToInt32(Console.ReadLine());

    Console.Write("Ingrese el nombre del autor: ");
    var autor = Console.ReadLine();

    Console.Write("Ingrese el ISBN del libro: ");
    var isbn = Console.ReadLine();

    Console.Write("Ingrese el género del libro: ");
    var genero = Console.ReadLine();

    Console.Write("Ingrese el precio del libro: ");
    var precio = Convert.ToDouble(Console.ReadLine());

    Libro libro = new Libro(titulo,anoPublicacion,autor,isbn,genero,precio);

    return libro;
}

void SolicitarLibroEliminar()
{
    Console.Write("Ingrese el ISBN del libro que desea eliminar: ");
    var isbn = Console.ReadLine();
    var libro = biblioteca.Libros.FirstOrDefault(  l => l.ISBN == isbn);
    if (libro!= null)
    {
        biblioteca.EliminarLibro(libro);
        Console.WriteLine("Libro eliminado con éxito.");
    }else
    {
        Console.WriteLine("ISBN no encontrado.");
    }
}

void BuscarTitulo()
{
    Console.Write("Ingrese el título del libro que desea buscar: ");
    var titulo = Console.ReadLine();
    biblioteca.BuscarLibroPorTitulo(titulo);
}