﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ChoriRey.Application.DTO
{
    public class ClientesDTO
    {
        public int IdCliente { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public string Estado { get; set; }
        public DateTime Fecha_Registro { get; set; }
        public int IdUsuario { get; set; }
    }
}
