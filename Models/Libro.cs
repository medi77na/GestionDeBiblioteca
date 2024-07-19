using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionDeBiblioteca.Models
{
    public class Libro : Publicacion
    {

        public string? Autor { get; set; }
        public string? ISBN { get; set; }
        public string? Genero { get; set; }
        public double Precio { get; set; }

        public Libro(string titulo, int anoPublicacion, string autor, string isbn, string genero, double precio)
            : base(titulo, anoPublicacion)
        {
            Autor = autor;
            ISBN = isbn;
            Genero = genero;
            Precio = precio;
        }

        public override string ToString()
        {
            return $"|  {Titulo,-18}| {Autor,-18}| {ISBN,-11}| {Genero,-13}| {Precio,-20:C2}|";
        }

        public void AplicarDescuento(double value)
        {
            Precio -= (Precio * value) / 100;
            Console.WriteLine($"Descuento aplicado: {value}%. Nuevo precio: {Precio:C2}");
            Console.Write("Oprima una tecla para continuar: ");
            Console.ReadKey();
        }

    }
}