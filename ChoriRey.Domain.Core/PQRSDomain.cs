using AdsPublisher.Domain.Entity;
using AdsPublisher.Domain.Interface;
using AdsPublisher.InfraStructure.Interface;
using AdsPublisher.Transversal.Utils;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AdsPublisher.Domain.Core
{
    public class PQRSDomain : MailServer, IPQRSDomain
    {
        private readonly IPQRSRepository _Repository;
        private readonly IClientesRepository _cRepository;        
        public IConfiguration Configuration { get; }

        public PQRSDomain(IPQRSRepository Repository, IClientesRepository clienteRepository, IConfiguration _configuration)
        {
            _Repository = Repository;
            _cRepository = clienteRepository;

            Configuration = _configuration;

            senderMail = Configuration["MailServer:SenderMail"];
            mailAdmon = Configuration["MailServer:MailAdmon"];
            password = Configuration["MailServer:Password"];
            host = Configuration["MailServer:Host"];
            port = int.Parse(Configuration["MailServer:Port"]);
            ssl = bool.Parse(Configuration["MailServer:SSL"]);

            initializeSmtpClient();

        }

        public async Task<bool> InsertAsync(PQRS model)
        {
            //return await _Repository.InsertAsync(model);
            var resp = await _Repository.InsertAsync(model);
            if (resp)
            {
                await this.SendEmail(model);
            }
            return resp;
        }

        public async Task<bool> UpdateAsync(PQRS model)
        {
            return await _Repository.UpdateAsync(model);
        }

        public async Task<bool> DeleteAsync(int IDPQRS)
        {
            return await _Repository.DeleteAsync(IDPQRS);
        }

        public async Task<PQRS> GetAsync(int IDPQRS)
        {
            return await _Repository.GetAsync(IDPQRS);
        }

        public async Task<IEnumerable<PQRS>> GetAllAsync(int IDCliente)
        {
            return await _Repository.GetAllAsync(IDCliente);
        }

        public async Task<bool> SendEmail(PQRS ipqr)
        {
            try
            {
                ClientesDomain dCliente = new ClientesDomain(_cRepository, null, Configuration);
                
                Clientes icliente = await dCliente.GetAsync(ipqr.IDCliente);


                #region VARIABLES CORREO ELECTRONICO
                string CorreoFuente = "font: normal 14px Arial, Verdana, Serif;";
                string CorreoColorRojo = "color: darkred;";

                string NumColorVerde = "#5AC517";

                string FuenteGrande = "font: 2.2rem Arial;";
                string FuenteMediana = "font: 1.2rem Arial;";
                string FuenteNormal = "font: 1rem Arial;";
                string FuentePequeña = "font: 0.7rem Arial;";

                string AlineaCENTER = "text-align: center;";
                string AlineaJUSTIFY = "text-align: justify;";

                string FondoGrisLetraBlanca = "background-color: #AFAFAF; color: white;";
                string FondoBlancoLetraGris = "background-color: #F5F7F8; color: dimgray;";

                string Contenido = string.Empty;
                #endregion

                #region Formato Correo Electrónico
                Contenido =
                "<div style='background-color: white; width: 100%; padding: 5px 5px 5px 5px'>" +
                        "<div style='border: 1px solid gray; width: 700px; max-width: 700px'>" +
                            "<div id='divEncabezado' style='" + AlineaCENTER + " " + FuenteGrande + " padding: 5px 20px 5px 20px'>" +
                                "PQRS - " + ipqr.TipoPeticion +
                            "</div>" +
                            "<div id='divInfoFecha' style='" + AlineaJUSTIFY + " background-color: " + NumColorVerde + "; color: white; " + FuenteMediana + " padding: 5px 20px 5px 20px'>" +
                                "Fecha: " + DateTime.Now.ToString("yyyy/MM/dd") + " Hora: " + DateTime.Now.ToString("HH:mm:ss") +
                            "</div>" +                            
                            "<div id='divInfoTransaccion' style='" + AlineaJUSTIFY + " " + FuenteMediana + " padding: 5px 20px 5px 20px'>" +
                                "Asunto: <label>" + ipqr.Asunto + "</label>" +
                            "</div>" +
                            "<div id='divDetalle'>" +
                                "<table style='width: 100%;'>" +
                                    "<tr>" +
                                        "<td style='width: 40%; border: 5px solid white; " + FondoGrisLetraBlanca + FuenteNormal + " padding: 5px 20px 5px 20px'>Descripción:" +
                                        "</td>" +
                                        "<td style='width: 60%; border: 5px solid white; " + FondoBlancoLetraGris + FuenteNormal + " padding: 5px 20px 5px 20px'>" + ipqr.Descripcion +
                                        "</td>" +
                                    "</tr>" +                                                                        
                                "</table>" +
                            "</div>" +
                            "<div id='divInfoAdicional' style='" + AlineaJUSTIFY + " " + FuenteNormal + " padding: 30px 20px 30px 20px; color: gray'>" +
                                "Muchas gracias por tu aporte, una vez atendamos su petición estaremos en contacto." +
                            "</div>" +
                            "<div id='divNoImprimir' style='" + AlineaCENTER + " " + FuentePequeña + " padding: 0px 20px 5px 20px; color: gray'>" +
                                "Cuidemos el medio ambiente. Por favor no imprima este e-mail si no es necesario." +
                            "</div>" +
                        "</div>" +
                    "</div>";
                #endregion

                List<string> correos = new List<string>();
                correos.Add(icliente.Correo);
                correos.Add(senderMail);

                sendMail(
                    subject: "Notificación de PQRS",
                    body: Contenido,
                    recipientMail: correos
                );

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            //return null;
        }

    }
}
