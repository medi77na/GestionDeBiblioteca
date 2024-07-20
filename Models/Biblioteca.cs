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

        public void BuscarLibroPorTitulo(string titulo)
        {
            var valorRetorno = Libros.FirstOrDefault(libro => libro.Titulo.ToLower() == titulo.ToLower());

            if (valorRetorno == null)
            {
                Console.WriteLine("No se encontró el libro");
            }
            else
            {
                Console.WriteLine("Libro encontrado:");
                Console.WriteLine(valorRetorno.ToString());
            }

            Console.Write("Oprima una tecla para continuar: ");
            Console.ReadKey();
        }

        public void EliminarLibro(Libro libro)
        {
            Libros.Remove(libro);
        }

        public void MostrarLibros()
        {
            Console.WriteLine(@$"                                  LIBROS EN LA BIBLIOTECA:");
            Console.WriteLine("--------------------------------------------------------------------------------------------");
            if (Libros.Count == 0)
            {
                Console.WriteLine("No hay libros en la biblioteca.");
            }
            else
            {
                Console.WriteLine(@"| Título             | Autor             | ISBN       | Género       | Precio              |");
                Console.WriteLine("--------------------------------------------------------------------------------------------");

                foreach (var libro in Libros)
                {
                    Console.WriteLine(libro.ToString());
                }
                Console.WriteLine("--------------------------------------------------------------------------------------------");
                Console.WriteLine("");
                Console.Write("Oprima una tecla para continuar: ");
                Console.ReadKey();
            }
        }

        public void SolicitarDescuento()
        {
            MostrarLibros();
            Console.Write("Ingrese el ISBN del libro: ");
            var isbn = Console.ReadLine();

            var libro = Libros.FirstOrDefault(libro => libro.ISBN == isbn);
            if (libro != null)
            {
                Console.Write("Ingrese el porcentaje de descuento (0-100): ");
                var descuento = Convert.ToDouble(Console.ReadLine());
                libro.AplicarDescuento(descuento);
            }
        }

        public override string ToString()
        {
            return $"Biblioteca con {Libros.Count} libros.";
        }
    }
}