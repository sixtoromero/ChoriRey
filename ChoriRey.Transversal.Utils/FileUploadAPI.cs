using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdsPublisher.Transversal.Utils
{
    public class FileUploadAPI
    {
        public IFormFile files { get; set; }
        public string FileBase64 { get; set; }
        //public int? IDCliente { get; set; }
    }
}
