using System;

namespace ChoriRey.Domain.Entity
{
    public class Usuarios
    {
        public int IdUsuario { get; set; }
        public string Usuario { get; set; }
        public string Clave { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Correo { get; set; }
        public string Direccion { get; set; }
        public bool Estado { get; set; }
        public DateTime? Fecha_Creacion { get; set; }
    }
}
