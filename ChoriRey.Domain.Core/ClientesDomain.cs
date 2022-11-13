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
    public class ClientesDomain : MailServer, IClientesDomain
    {
        private readonly IClientesRepository _clienteRepository;
        //private readonly IMicroEmpresasRepository _microempRepository;
        private readonly IPlanesRepository _planRepository;

        public IConfiguration Configuration { get; }

        public ClientesDomain(IClientesRepository clienteRepository, IPlanesRepository planRepository, IConfiguration _configuration)
        {
            _clienteRepository = clienteRepository;
            _planRepository = planRepository;

            Configuration = _configuration;

            senderMail = Configuration["MailServer:SenderMail"];
            password = Configuration["MailServer:Password"];
            host = Configuration["MailServer:Host"];
            port = int.Parse(Configuration["MailServer:Port"]);
            ssl = bool.Parse(Configuration["MailServer:SSL"]);

            initializeSmtpClient();
        }

        public async Task<bool> InsertAsync(Clientes cliente)
        {
            var resp = await _clienteRepository.InsertAsync(cliente);
            if (resp)
            {
                this.SendEmail(cliente);
            }

            return resp;
        }

        public async Task<bool> UpdateAsync(Clientes cliente)
        {
            return await _clienteRepository.UpdateAsync(cliente);
        }

        public async Task<bool> DeleteAsync(int? IDCliente)
        {
            return await _clienteRepository.DeleteAsync(IDCliente);
        }

        public async Task<Clientes> GetAsync(int? IDCliente)
        {
            return await _clienteRepository.GetAsync(IDCliente);
        }

        public async Task<IEnumerable<Clientes>> GetAllAsync()
        {
            return await _clienteRepository.GetAllAsync();
        }

        public async Task<bool> SetActivation(string Correo)
        {
            return await _clienteRepository.SetActivation(Correo);
        }
        
        public bool SendEmail(Clientes user)
        {
            try
            {
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
                string URLAct = Configuration["MailServer:URL"] + user.Correo;
                #endregion

                #region Formato Correo Electrónico
                Contenido =
                "<div style='background-color: white; width: 100%; padding: 5px 5px 5px 5px'>" +
                        "<div style='border: 1px solid gray; width: 700px; max-width: 700px'>" +
                            "<div id='divEncabezado' style='" + AlineaCENTER + " " + FuenteGrande + " padding: 5px 20px 5px 20px'>" +
                                "Registro de Usuario" +
                            "</div>" +
                            "<div id='divInfoFecha' style='" + AlineaJUSTIFY + " background-color: " + NumColorVerde + "; color: white; " + FuenteMediana + " padding: 5px 20px 5px 20px'>" +
                                "Fecha: " + DateTime.Now.ToString("yyyy/MM/dd") + " Hora: " + DateTime.Now.ToString("HH:mm:ss") +
                            "</div>" +
                            "<div id='divInfoCliente' style='" + AlineaJUSTIFY + " " + FuenteMediana + " padding: 5px 20px 5px 20px'>" +
                                "Señor(a),\n" + user.Nombres + " " + user.Apellidos +
                            "</div>" +
                            "<div id='divInfoTransaccion' style='" + AlineaJUSTIFY + " " + FuenteMediana + " padding: 5px 20px 5px 20px'>" +
                                "Estamos enviando información relevante de su registro con el usuario: <label>" + user.Correo + "</label>" +
                            "</div>" +
                            "<div id='divDetalle'>" +
                                "<table style='width: 100%;'>" +                                    
                                    "<tr>" +
                                        "<td style='width: 40%; border: 5px solid white; " + FondoGrisLetraBlanca + FuenteNormal + " padding: 5px 20px 5px 20px'>Nombres" +
                                        "</td>" +
                                        "<td style='width: 60%; border: 5px solid white; " + FondoBlancoLetraGris + FuenteNormal + " padding: 5px 20px 5px 20px'>" + user.Nombres +
                                        "</td>" +
                                    "</tr>" +
                                    "<tr>" +
                                        "<td style='width: 40%; border: 5px solid white; " + FondoGrisLetraBlanca + FuenteNormal + " padding: 5px 20px 5px 20px'>Apellidos" +
                                        "</td>" +
                                        "<td style='width: 60%; border: 5px solid white; " + FondoBlancoLetraGris + FuenteNormal + " padding: 5px 20px 5px 20px'>" + user.Apellidos +
                                        "</td>" +
                                    "</tr>" +                                    
                                    "<tr>" +
                                        "<td style='width: 40%; border: 5px solid white; " + FondoGrisLetraBlanca + FuenteNormal + " padding: 5px 20px 5px 20px'>Email" +
                                        "</td>" +
                                        "<td style='width: 60%; border: 5px solid white; " + FondoBlancoLetraGris + FuenteNormal + " padding: 5px 20px 5px 20px'>" + user.Correo +
                                        "</td>" +
                                    "</tr>" +                                    
                                    "<tr>" +
                                        "<td style='width: 40%; border: 5px solid white; " + FondoGrisLetraBlanca + FuenteNormal + " padding: 5px 20px 5px 20px'>Usuario" +
                                        "</td>" +
                                        "<td style='width: 60%; border: 5px solid white; " + FondoBlancoLetraGris + FuenteNormal + " padding: 5px 20px 5px 20px'>" + user.Correo +
                                        "</td>" +
                                    "</tr>" +
                                    "<tr>" +
                                        "<td style='width: 40%; border: 5px solid white; " + FondoGrisLetraBlanca + FuenteNormal + " padding: 5px 20px 5px 20px'>Contraseña" +
                                        "</td>" +
                                        "<td style='width: 60%; border: 5px solid white; " + FondoBlancoLetraGris + FuenteNormal + " padding: 5px 20px 5px 20px'>" + user.Password +
                                        "</td>" +
                                    "</tr>" +
                                "</table>" +
                            "</div>" +
                            "<div id='divInfoAdicional' style='" + AlineaJUSTIFY + " " + FuenteNormal + " padding: 30px 20px 30px 20px; color: gray'>" +
                                "Para su activación por favor click sobre el siguiente enlace, o si prefiere copie y pegue en su navegador web favorito " + "<a href='" + URLAct + "'>" + URLAct +
                            "</div>" +
                            "<div id='divNoImprimir' style='" + AlineaCENTER + " " + FuentePequeña + " padding: 0px 20px 5px 20px; color: gray'>" +
                                "Cuidemos el medio ambiente. Por favor no imprima este e-mail si no es necesario." +
                            "</div>" +
                        "</div>" +
                    "</div>";
                #endregion

                sendMail(
                    subject: "Notificación de Registro",
                    body: Contenido,
                    recipientMail: new List<string> { user.Correo }
                );

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            //return null;
        }

        public async Task<bool> SendEmailInfoPago(Clientes user)
        {
            try
            {
                //IMicroEmpresasRepository iMicroEmpRep;
                //MicroEmpresasDomain iMicroEmp = new MicroEmpresasDomain(_microempRepository, Configuration);
                PlanesDomain iPlanDomain = new PlanesDomain(_planRepository, Configuration);
                //MicroEmpresas iMicroEmpModel = new MicroEmpresas();
                Planes iPlanModel = new Planes();
                //iMicroEmpModel = await iMicroEmp.GetAsync(user.IDMicroempresa);
                iPlanModel = await iPlanDomain.GetAsync(user.IDPlan);


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
                string URLAct = Configuration["MailServer:URL"] + user.Correo;
                #endregion

                #region Formato Correo Electrónico
                Contenido =
                "<div style='background-color: white; width: 100%; padding: 5px 5px 5px 5px'>" +
                        "<div style='border: 1px solid gray; width: 700px; max-width: 700px'>" +
                            "<div id='divEncabezado' style='" + AlineaCENTER + " " + FuenteGrande + " padding: 5px 20px 5px 20px'>" +
                                "Información del pago" +
                            "</div>" +
                            "<div id='divInfoFecha' style='" + AlineaJUSTIFY + " background-color: " + NumColorVerde + "; color: white; " + FuenteMediana + " padding: 5px 20px 5px 20px'>" +
                                "Fecha: " + DateTime.Now.ToString("yyyy/MM/dd") + " Hora: " + DateTime.Now.ToString("HH:mm:ss") +
                            "</div>" +
                            "<div id='divInfoCliente' style='" + AlineaJUSTIFY + " " + FuenteMediana + " padding: 5px 20px 5px 20px'>" +
                                "Señor(a),\n" + user.Nombres + " " + user.Apellidos +
                            "</div>" +
                            "<div id='divInfoTransaccion' style='" + AlineaJUSTIFY + " " + FuenteMediana + " padding: 5px 20px 5px 20px'>" +
                                "Estamos enviando información relevante de su pago a la factura: <label>" + user.IDFactura + "</label>" +
                            "</div>" +
                            "<div id='divDetalle'>" +
                                "<table style='width: 100%;'>" +                                    
                                    "<tr>" +
                                        "<td style='width: 40%; border: 5px solid white; " + FondoGrisLetraBlanca + FuenteNormal + " padding: 5px 20px 5px 20px'>Plan" +
                                        "</td>" +
                                        "<td style='width: 60%; border: 5px solid white; " + FondoBlancoLetraGris + FuenteNormal + " padding: 5px 20px 5px 20px'>" + iPlanModel.Titulo +
                                        "</td>" +
                                    "</tr>" +
                                    "<tr>" +
                                        "<td style='width: 40%; border: 5px solid white; " + FondoGrisLetraBlanca + FuenteNormal + " padding: 5px 20px 5px 20px'>Detalle" +
                                        "</td>" +
                                        "<td style='width: 60%; border: 5px solid white; " + FondoBlancoLetraGris + FuenteNormal + " padding: 5px 20px 5px 20px'>" + iPlanModel.Detalle +
                                        "</td>" +
                                    "</tr>" +
                                    "<tr>" +
                                        "<td style='width: 40%; border: 5px solid white; " + FondoGrisLetraBlanca + FuenteNormal + " padding: 5px 20px 5px 20px'>Precio" +
                                        "</td>" +
                                        "<td style='width: 60%; border: 5px solid white; " + FondoBlancoLetraGris + FuenteNormal + " padding: 5px 20px 5px 20px'>" + iPlanModel.Precio.ToString("c") +
                                        " USD</td>" +
                                    "</tr>" +                                    
                                "</table>" +
                            "</div>" +
                            "<div id='divInfoAdicional' style='" + AlineaJUSTIFY + " " + FuenteNormal + " padding: 30px 20px 30px 20px; color: gray'>" +
                                "Por favor guarde este correo para evitar inconvenientes más adelante. " + 
                            "</div>" +
                            "<div id='divNoImprimir' style='" + AlineaCENTER + " " + FuentePequeña + " padding: 0px 20px 5px 20px; color: gray'>" +
                                "Cuidemos el medio ambiente. Por favor no imprima este e-mail si no es necesario." +
                            "</div>" +
                        "</div>" +
                    "</div>";
                #endregion

                sendMail(
                    subject: "Notificación de Pago",
                    body: Contenido,
                    recipientMail: new List<string> { user.Correo }
                );

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            //return null;
        }

        public async Task<bool> SendMailAsync(Clientes cliente)
        {
            try
            {
                this.SendEmailInfoPago(cliente);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            

        }

        public async Task<Clientes> GetLoginAsync(string Correo, string Password)
        {
            return await _clienteRepository.GetLoginAsync(Correo, Password);
        }
    }
}
