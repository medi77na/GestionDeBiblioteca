using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionDeBiblioteca.Models;

public class Program
{

    // Instancia de biblioteca
    public static Biblioteca biblioteca = new Biblioteca();

    public static void Main(string[] args)
    {
        // Libros quemados
        biblioteca.AgregarLibro(new Libro("Davids", 2020, "Medina David", "12345", "Romance", 10000000));
        biblioteca.AgregarLibro(new Libro("StevenD", 1010, "Urrego Steven", "54321", "Novela", 40000000));
        biblioteca.AgregarLibro(new Libro("Jane", 2015, "Doe Jane", "67890", "Fantasia", 8000000));
        biblioteca.AgregarLibro(new Libro("Jose", 2018, "Perez Jose", "34567", "Aventura", 6000000));
        biblioteca.AgregarLibro(new Libro("Maria", 2021, "Garcia Maria", "98765", "Ciencia Ficción", 12000000));

        MenuOpciones();
    }

    public static int MostrarMenu()
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

            string? entrada = Console.ReadLine();
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

    public static void MenuOpciones()
    {
        int opcion;

        do
        {
            opcion = MostrarMenu();
            switch (opcion)
            {
                case 1:
                    SolicitudCrearLibro();
                    break;
                case 2:
                    SolicitudEliminarLibro();
                    break;
                case 3:
                    SolicitudBuscarLibroPorTitulo();
                    break;
                case 4:
                    SolicitudMostrarLibros();
                    break;
                case 5:
                    SolicitudDescuentoLibro();
                    break;
                case 6:
                    Console.WriteLine("Hasta luego.");
                    Console.Write("Oprima una tecla para continuar: ");
                    Console.ReadKey();
                    break;
                default:
                    Console.Write("Opción incorrecta.");
                    break;
            }
        } while (opcion != 6);

    }

    public static void SolicitudCrearLibro()
    {
        string? titulo = ValidarString("Ingrese el título del libro: ");

        int anoPublicacion = ValidarInt("Ingrese el año de publicación: ");

        string? autor = ValidarString("Ingrese el nombre del autor: ");

        string? isbn = ValidarString("Ingrese el ISBN del libro: ");

        string? genero = ValidarString("Ingrese el género del libro: ");

        var precio = ValidarDouble("Ingrese el precio del libro: ");

        biblioteca.AgregarLibro(new Libro(titulo, anoPublicacion, autor, isbn, genero, precio));

        Console.WriteLine("Libro agregado correctamente...");
        Console.Write("Oprima una tecla para continuar: ");
        Console.ReadKey();
    }

    public static void SolicitudEliminarLibro()
    {
        string? isbn = ValidarString("Ingrese el ISBN del libro: ");
        var libro = biblioteca.BuscarLibroPorIsbn(isbn);

        if (libro != null)
        {
            Console.Write("");
            biblioteca.EliminarLibro(libro);
            Console.WriteLine("Libro eliminado correctamente...");
            Console.Write("Oprima una tecla para continuar: ");
            Console.ReadKey();
        }
        else
        {
            Console.Write("");
            Console.WriteLine("No se encontró el ISBN digitado.");
            Console.Write("Oprima una tecla para continuar: ");
            Console.ReadKey();
        }
    }

    public static void SolicitudBuscarLibroPorTitulo()
    {
        var titulo = ValidarString("Ingrese el título del libro que desea buscar: ");
        biblioteca.BuscarLibroPorTitulo(titulo);
    }

    public static void SolicitudMostrarLibros()
    {
        Console.WriteLine(@$"                                                 LIBROS EN LA BIBLIOTECA");
        Console.WriteLine("---------------------------------------------------------------------------------------------------------------------");
        biblioteca.MostrarLibros();
        Console.Write("Oprima una tecla para continuar: ");
        Console.ReadKey();
        Console.Clear();
    }

    public static void SolicitudDescuentoLibro()
    {
        biblioteca.MostrarLibros();
        string? isbn = ValidarString("Ingrese el ISBN del libro: ");
        var libro = biblioteca.BuscarLibroPorIsbn(isbn);

        if (libro != null)
        {
            Console.Write("");
            double descuento = ValidarDouble("Ingrese el porcentaje de descuento (0-100): ");
            double precio = biblioteca.DescuentoLibro(libro, descuento);
            Console.Clear();
            Console.WriteLine($"Descuento aplicado: {descuento}%. Nuevo precio: {precio:C2}");
            Console.Write("Oprima una tecla para continuar: ");
            Console.ReadKey();
        }
        else
        {
            Console.Write("");
            Console.WriteLine("No se encontró el ISBN digitado.");
            Console.Write("Oprima una tecla para continuar: ");
            Console.ReadKey();
        }
    }

    public static string ValidarString(string text)
    {
        bool bandera = true;
        string? value;
        do
        {
            Console.Write(text);
            value = Console.ReadLine();
            if (string.IsNullOrEmpty(value))
            {
                Console.WriteLine($"Error: {text} no puede estar vacío.");
                Console.Write("Oprima una tecla para continuar: ");
                Console.ReadKey();
                return "";
            }
            else
            {
                bandera = false;
                return value;
            }
        } while (bandera);  
    }

    public static double ValidarDouble(string text)
    {
        bool bandera = true;
        do
        {
            Console.Write(text);
            string? value = Console.ReadLine();

            if (string.IsNullOrEmpty(value) || !Double.TryParse(value, out double result))
            {
                Console.WriteLine("Entrada incorrecta, Digite nuevamente.");
                Console.Write("Oprima una tecla para continuar: ");
                Console.ReadKey();
                return 0;
            }
            else
            {
                bandera = false;
                return result;
            }

        } while (bandera);
    }

    public static int ValidarInt(string text)
    {
        bool bandera = true;
        do
        {
            Console.Write(text);
            string? value = Console.ReadLine();

            if (string.IsNullOrEmpty(value) || !int.TryParse(value, out int result))
            {
                Console.WriteLine("Entrada incorrecta, Digite nuevamente.");
                Console.Write("Oprima una tecla para continuar: ");
                Console.ReadKey();
                return 0;
            }
            else
            {
                bandera = false;
                return result;
            }

        } while (bandera);
    }


}