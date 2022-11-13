using System;
using System.Collections.Generic;
using System.Text;

namespace AdsPublisher.Domain.Entity
{
    public class Clientes
    {
        public int IDCliente { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public int? Sexo { get; set; }        
        public DateTime? FechaCumpleanos { get; set; }
        public string Correo { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public bool Activo { get; set; }
        public string Foto { get; set; }

        //Propiedades no propias de el modelo        
        public string Password { get; set; }
        public string Token { get; set; }

        //Propiedades que no son del modelo
        public int IDFactura { get; set; }
        public int IDMicroempresa { get; set; }
        public int IDPlan { get; set; }
        public int IDUsuario { get; set; }

    }
}
