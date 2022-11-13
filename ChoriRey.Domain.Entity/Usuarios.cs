using System;

namespace AdsPublisher.Domain.Entity
{
    public class Usuarios
    {
        public int IDUsuario { get; set; }
        public int IDCliente { get; set; }
        public string Usuario { get; set; }
        public string Password { get; set; }
        public DateTime? FechaCreacion { get; set; }
    }
}
