using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionDeBiblioteca.Models
{
    public class Publicacion
    {
        public string Titulo { get; set; }
        public int AnoPublicacion { get; set; }

        public Publicacion(string titulo, int anoPublicacion)
        {
            Titulo = titulo;
            AnoPublicacion = anoPublicacion;
        }

    }
}