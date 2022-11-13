using System;

namespace AdsPublisher.Application.DTO
{
    public class UsuariosDTO
    {
        public int IDUsuario { get; set; }
        public int IDCliente { get; set; }
        public string Usuario { get; set; }
        public string Password { get; set; }
        public DateTime? FechaCreacion { get; set; }
    }
}
