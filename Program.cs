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
        Console.Clear();
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
                Console.Clear();
                Console.WriteLine("Error: La entrada no es un número entero válido. Por favor, intente de nuevo.");
                Console.WriteLine("");
                Console.WriteLine("Oprima una tecla para continuar... ");
                Console.ReadKey();
                Console.Clear();
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
                    Console.Clear();
                    SolicitudCrearLibro();
                    break;
                case 2:
                    Console.Clear();
                    SolicitudEliminarLibro();
                    break;
                case 3:
                    Console.Clear();
                    SolicitudBuscarLibroPorTitulo();
                    break;
                case 4:
                    Console.Clear();
                    SolicitudMostrarLibros();
                    break;
                case 5:
                    Console.Clear();
                    SolicitudDescuentoLibro();
                    break;
                case 6:
                    Console.Clear();
                    Console.WriteLine("Hasta luego.");
                    Console.WriteLine("");
                    Console.WriteLine("Oprima una tecla para continuar... ");
                    Console.ReadKey();
                    Console.Clear();
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Error: La entrada no es válida. Por favor, intente de nuevo.");
                    Console.WriteLine("");
                    Console.WriteLine("Oprima una tecla para continuar... ");
                    Console.ReadKey();

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

        Console.Clear();
        Console.WriteLine("Libro agregado correctamente...");
        Console.WriteLine("");
        Console.WriteLine("Oprima una tecla para continuar... ");
        Console.ReadKey();
    }

    public static void SolicitudEliminarLibro()
    {
        SolicitudMostrarLibros();
        string? isbn = ValidarString("Ingrese el ISBN del libro: ");
        var libro = biblioteca.BuscarLibroPorIsbn(isbn);

        if (libro != null)
        {
            Console.Write("");
            biblioteca.EliminarLibro(libro);
            Console.Clear();
            Console.WriteLine("Libro eliminado correctamente...");
            Console.Write("");
            Console.WriteLine("Oprima una tecla para continuar... ");
            Console.ReadKey();
        }
        else
        {
            Console.Write("");
            Console.WriteLine("No se encontró el ISBN digitado.");
            Console.WriteLine("Oprima una tecla para continuar... ");
            Console.ReadKey();
        }
    }

    public static void SolicitudBuscarLibroPorTitulo()
    {
        var titulo = ValidarString("Ingrese el título del libro que desea buscar: ");
        var libro = biblioteca.BuscarLibroPorTitulo(titulo);
        if (libro == null)
        {
            Console.WriteLine("Libro no encontrado.");
            Console.WriteLine("Oprima una tecla para continuar... ");
            Console.ReadKey();
        }
        else
        {
            Console.Clear();
            biblioteca.MostrarEncabezadoLibros();
            Console.WriteLine(libro.ToString());
            Console.WriteLine("");
            Console.WriteLine("Oprima una tecla para continuar... ");
            Console.ReadKey();
        }
    }

    public static void SolicitudMostrarLibros()
    {
        Console.WriteLine(@$"                                                 LIBROS EN LA BIBLIOTECA");
        Console.WriteLine("---------------------------------------------------------------------------------------------------------------------");
        biblioteca.MostrarLibros();
        Console.WriteLine("Oprima una tecla para continuar... ");
        Console.ReadKey();
        Console.WriteLine("");
    }

    public static void SolicitudDescuentoLibro()
    {
        SolicitudMostrarLibros();
        string? isbn = ValidarString("Ingrese el ISBN del libro: ");
        var libro = biblioteca.BuscarLibroPorIsbn(isbn);

        if (libro != null)
        {
            Console.Write("");
            double descuento = ValidarDouble("Ingrese el porcentaje de descuento (0-100): ");
            double precio = biblioteca.DescuentoLibro(libro, descuento);
            Console.Clear();
            Console.WriteLine($"Descuento aplicado: {descuento}%. Nuevo precio: {precio:C2}");
            Console.WriteLine("Oprima una tecla para continuar... ");
            Console.ReadKey();
        }
        else
        {
            Console.Write("");
            Console.WriteLine("No se encontró el ISBN digitado.");
            Console.WriteLine("Oprima una tecla para continuar... ");
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
                Console.Clear();
                Console.WriteLine($"Error: El campo -{text}- no puede estar vacío.");
                Console.WriteLine("");
                Console.WriteLine("Oprima una tecla para continuar... ");
                Console.ReadKey();
                Console.Clear();
            }
            else
            {
                bandera = false;
            }
        } while (bandera);
        return value;
    }

    public static double ValidarDouble(string text)
    {
        bool bandera = true;
        double result = 0;
        do
        {
            Console.Write(text);
            string? value = Console.ReadLine();

            if (string.IsNullOrEmpty(value) || !Double.TryParse(value, out result))
            {
                Console.Clear();
                Console.WriteLine($"Error: El campo -{text}- no fue digtado correctamente.");
                Console.WriteLine("");
                Console.WriteLine("Oprima una tecla para continuar... ");
                Console.ReadKey();
                Console.Clear();
            }
            else
            {
                bandera = false;
            }
        } while (bandera);
        return result;
    }

    public static int ValidarInt(string text)
    {
        bool bandera = true;
        int result = 0;
        do
        {
            Console.Write(text);
            string? value = Console.ReadLine();

            if (string.IsNullOrEmpty(value) || !int.TryParse(value, out result))
            {
                Console.Clear();
                Console.WriteLine($"Error: El campo -{text}- no fue digtado correctamente.");
                Console.WriteLine("");
                Console.WriteLine("Oprima una tecla para continuar... ");
                Console.ReadKey();
                Console.Clear();
            }
            else
            {
                bandera = false;
            }

        } while (bandera);
        return result;
    }
}