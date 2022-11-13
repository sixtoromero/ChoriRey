using System;
using System.Collections.Generic;
using System.Text;

namespace AdsPublisher.Application.DTO
{
    public class Perfil_Usuario
    {
        public int IDPerfilUsuario { get; set; }
        public int IDRol { get; set; }
        public int IDPerfil { get; set; }
        public int IDUsuario { get; set; }
        public string Descripcion { get; set; }
        public DateTime? FechaCreacion { get; set; }
    }
}
