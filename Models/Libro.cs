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
            return $"|  {Titulo,-23}| {Autor,-23}| {ISBN,-16}| {Genero,-18}| {Precio,-25:C2}|";
        }



    }
}