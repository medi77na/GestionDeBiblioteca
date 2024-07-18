using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionDeBiblioteca.Models
{
    public class Publicacion
    {
        public string Titulo { get; set; }
        public DateOnly AnoPublicacion { get; set; }

        public Publicacion(string titulo, DateOnly anoPublicacion)
        {
            Titulo = titulo;
            AnoPublicacion = anoPublicacion;
        }

    }
}