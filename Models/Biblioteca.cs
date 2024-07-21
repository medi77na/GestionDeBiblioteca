using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionDeBiblioteca.Models
{
    public class Biblioteca
    {

        public List<Libro> Libros;

        //Método Constructor
        public Biblioteca()
        {
            Libros = new List<Libro>();
        }

        public void AgregarLibro(Libro libro)
        {
            Libros.Add(libro);
        }

        public void EliminarLibro(Libro libro)
        {
            Libros.Remove(libro);
        }

        public void MostrarLibros()
        {


            if (Libros.Count == 0)
            {
                Console.WriteLine("No hay libros en la biblioteca.");
                Console.WriteLine("");
            }
            else
            {
                MostrarEncabezadoLibros();
                foreach (var libro in Libros)
                {
                    Console.WriteLine(libro.ToString());
                }
                Console.WriteLine("---------------------------------------------------------------------------------------------------------------------");
                Console.WriteLine("");
            }
        }

        public double DescuentoLibro(Libro libro, double value)
        {
            libro.Precio -= libro.Precio * value / 100;
            return libro.Precio;
        }

        public Libro? BuscarLibroPorIsbn(string isbn)
        {
            var libro = Libros.FirstOrDefault(libro => libro.ISBN == isbn);
            if (libro == null)
            {
                return null;
            }
            else
            {
                return libro;
            }
        }

        public Libro? BuscarLibroPorTitulo(string titulo)
        {
            var libro = Libros.FirstOrDefault(libro => libro.Titulo.ToLower() == titulo.ToLower());

            if (libro == null)
            {
                return null;
            }
            else
            {
                return libro;
            }
        }

        public Libro? BuscarLibroPorAutor(string autor)
        {
            var libro = Libros.FirstOrDefault(libro => libro.Autor == autor);
            if (libro == null)
            {
                return null;
            }
            else
            {
                return libro;
            }
        }

        public void MostrarEncabezadoLibros()
        {
            Console.WriteLine(@"| Título                  | Autor                  | ISBN            | Género            | Precio                   |");
            Console.WriteLine("---------------------------------------------------------------------------------------------------------------------");
        }

        public override string ToString()
        {
            return $"Biblioteca con {Libros.Count} libros.";
        }
    }
}