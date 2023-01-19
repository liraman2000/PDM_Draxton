using System.Net.Mail;
using System.Net.Mime;
using System.Net;
using System.Text;

namespace PDM_Draxton.utilidades
{
    public class Email
    {

        public bool enviaCorreo(String Clave,String Archivo, String user, String email, String Negocio, int DocsTotales, int Incidencias, int IncidenciasActivas, String Estatus, String fecha, String msgAsuntoMail, String DestinosEmail, String Comentarios,String DescPeriodo, out String msgError)
            {
            Boolean boolProcess = true;
            fecha = DateTime.Now.ToString("yyyy-MM-dd");
            msgError = String.Empty;
            string msgEnvia = String.Empty;

            //if (Clave != "ABIERTO")
            //    msgEnvia = "<table WIDTH='80%' style='border: 2px solid black; border-collapse: collapse; margin: 20px;margin: 0 auto;'>    " +
            //        "<tr style = 'border: 1px solid black; border-collapse: collapse;padding: 15px;' ><th><img src= 'wwwroot/img/logoGis.png' align = 'left' ></th>" +
            //        "<th style = 'font-size: 20px; padding: 15px; color:#003366' align = 'left'>< H1 > Comercio Exterior </H1 ></th><th></th></tr><tr>" +
            //        "<td style = 'font-size: 18px; border: 2px solid #003366; border-collapse: collapse; padding: 15px;' colspan = '3' > " + msgAsuntoMail + " </td></tr>" +
            //        "<tr style = 'font-size: 18px; ' ><tr style = 'font-size: 18px;' >" +
            //        "<td style = 'font-weight:bold;padding: 5px;' > Negocio </td>" +
            //        "<td style = 'padding: 5px;text-align: center;' colspan = '2' > " + Negocio + " </td></tr>" +
            //        "<tr style = 'font-size: 18px;' ><td style = 'font-weight:bold;padding: 5px;' > Documentos Totales </td>" +
            //        "<td style = 'padding: 5px;text-align: center;' colspan = '2' > " + DocsTotales + "</td></tr>" +
            //        "<tr style = 'font-size: 18px;' ><td style = 'font-weight:bold;padding: 5px;' > Incidencias </td>" +
            //        "<td style = 'padding: 5px;text-align: center;' colspan = '2' > " + Incidencias + " </td></tr>" +
            //        "<tr style = 'font-size: 18px;' ><td style = 'font-weight:bold;padding: 5px;' > Incidencias Activas </td>" +
            //        "<td style = 'padding: 5px;text-align: center;' colspan = '2' > " + IncidenciasActivas + " </td></tr>" +
            //        "<tr style = 'font-size: 18px;' ><td style = 'font-weight:bold;padding: 5px;' > Estatus Anterior </td>" +
            //        "<td style = 'padding: 5px;text-align: center;' colspan = '2' > " + Estatus + " </td></tr>" +
            //        "<tr style = 'font-size: 18px;' ><td style = 'font-weight:bold;padding: 5px;' > Fecha </td>" +
            //        "<td style = 'padding: 5px;text-align: center;' colspan = '2' > " + fecha + " </td></tr>" +
            //        "<tr style = 'font-size: 18px;' >< td style = 'font-weight:bold;padding: 5px;' > Comentarios </ td > " +
            //        "<td style = 'padding: 5px;text-align: center;' colspan = '2' > " + Comentarios + " </td></tr></table> ";
            //else
            //    msgEnvia = "<table WIDTH='80%' style='border: 2px solid black; border-collapse: collapse; margin: 20px;margin: 0 auto;'>" +
            //                "<tr style = 'border: 1px solid black; border-collapse: collapse;padding: 15px;' ><th><img src = '//wwwroot/img/logoGis.png' align = 'left' ></th>" +
            //                "<th style = 'font-size: 20px; padding: 15px; color:#003366' align = 'left'><H1> Comercio Exterior </H1></th><th></th></tr><tr>" +
            //                "<td style = 'font-size: 18px; border: 2px solid #003366; border-collapse: collapse; padding: 15px;' colspan = '3' > " + msgAsuntoMail + " </td></tr>" +
            //                "<tr style = 'font-size: 18px; ' ><tr style = 'font-size: 18px;' >" +
            //                "<td style = 'font-weight:bold;padding: 5px;'> Nombre del Archivo cargado: </td>" +
            //                "<td style = 'padding: 5px;text-align: center;' colspan = '2' > " + Archivo + " </td></tr>" +
            //                "<tr style = 'font-size: 18px;' >" +
            //                "<td style = 'font-weight:bold;padding: 5px;' > Cantidad de registros cargados: </td>" +
            //                "<td style = 'padding: 5px;text-align: center;' colspan = '2' > " + DocsTotales + " </td></tr><tr style = 'font-size: 18px;' >" +
            //                "<td style = 'font-weight:bold;padding: 5px;' > Fecha de carga</td>" + fecha +
            //                "<td style = 'padding: 5px;text-align: center;' colspan = '2' > " + Incidencias + " </td></tr><tr style = 'font-size: 18px;' >" +
            //                "<td style = 'font-weight:bold;padding: 5px;' > Usuario que carga: </td> " + 
            //                "<td style = 'padding: 5px;text-align: center;' colspan = '2' > " + user + " </td></tr><tr style = 'font-size: 18px;' >" +
            //                "<td style = 'font-weight:bold;padding: 5px;' > Correo: </td>" +
            //                "<td style = 'padding: 5px;text-align: center;' colspan = '2' > " + email + " </td></tr>" +
            //                "<td style = 'font-weight:bold;padding: 5px;' > Comentarios </td>" +
            //                "<td style = 'padding: 5px;text-align: center;' colspan = '2' > " + Comentarios + " </td> </tr></table> ";

            if (Clave != "ABIERTO")
                msgEnvia = "<table WIDTH='80%' style='border: 2px solid black; border-collapse: collapse; margin: 20px;margin: 0 auto;'>    " +
                    "<tr style='border: 1px solid black; border-collapse: collapse;padding: 15px;'><th><img src='https://www.gis.com.mx/wp-content/themes/GIS/images/gislogo1.png' align='left'></th>" +
                    "<th style='font-size: 20px; padding: 15px; color:#003366' align='left'><H1> Comercio Exterior </H1></th><th></th></tr><tr>" +
                    "<td style='font-size: 18px; border: 2px solid #003366; border-collapse: collapse; padding: 15px;' colspan='3'> " + msgAsuntoMail + " </td></tr>" +
                    "<tr style='font-size: 18px;'><tr style='font-size: 18px;'>" +
                    "<td style='font-weight:bold;padding:5px;'> Negocio </td>" +
                    "<td style='padding:5px;text-align: center;' colspan='2'> " + Negocio + " </td></tr>" +
                    "<tr style='font-size: 18px;'><td style='font-weight:bold;padding:5px;'> Periodo </td>" +
                    "<td style='padding:5px;text-align: center;' colspan='2'> " + DescPeriodo + "</td></tr>" +
                    "<tr style='font-size: 18px;'><td style='font-weight:bold;padding:5px;'> Documentos Totales </td>" +
                    "<td style='padding:5px;text-align: center;' colspan='2'> " + DocsTotales + "</td></tr>" +
                    "<tr style='font-size: 18px;'><td style='font-weight:bold;padding:5px;'> Incidencias </td>" +
                    "<td style='padding:5px;text-align: center;' colspan='2'> " + Incidencias + " </td></tr>" +
                    "<tr style='font-size: 18px;'><td style='font-weight:bold;padding:5px;'> Incidencias Activas </td>" +
                    "<td style='padding:5px;text-align: center;' colspan='2'> " + IncidenciasActivas + " </td></tr>" +
                    "<tr style='font-size: 18px;'><td style='font-weight:bold;padding:5px;'> Estatus Anterior </td>" +
                    "<td style='padding:5px;text-align: center;' colspan='2'> " + Estatus + " </td></tr>" +
                    "<tr style='font-size: 18px;'><td style='font-weight:bold;padding:5px;'> Fecha </td>" +
                    "<td style='padding:5px;text-align: center;' colspan='2'> " + fecha + " </td></tr>" +
                    "<tr style='font-size: 18px;'><td style='font-weight:bold;padding:5px;'> Comentarios </td> " +
                    "<td style='padding:5px;text-align: center;' colspan='2'> " + Comentarios + " </td></tr></table> ";
            else
                msgEnvia = "<table WIDTH='80%' style='border: 2px solid black; border-collapse: collapse; margin: 20px;margin: 0 auto;'>" +
                            "<tr style='border: 1px solid black; border-collapse: collapse;padding: 15px;'><th><img src='https://www.gis.com.mx/wp-content/themes/GIS/images/gislogo1.png' align='left'></th>" +
                            "<th style='font-size: 20px; padding: 15px; color:#003366' align='left'><H1> Comercio Exterior </H1></th><th></th></tr><tr>" +
                            "<td style='font-size: 18px; border: 2px solid #003366; border-collapse: collapse; padding: 15px;' colspan='3'>" + msgAsuntoMail + " </td></tr>" +
                            "<tr style='font-size: 18px;'><tr style='font-size: 18px;'>" +
                            "<td style='font-weight:bold;padding:5px;'> Nombre del Archivo cargado: </td>" +
                            "<td style='padding:5px;text-align: center;' colspan='2'>" + Archivo + " </td></tr>" +
                            "<tr style='font-size: 18px;'>" +
                            "<td style='font-weight:bold;padding:5px;'> Cantidad de registros cargados: </td>" +
                            "<td style='padding:5px;text-align: center;' colspan='2'>" + DocsTotales + " </td></tr><tr style='font-size: 18px;'>" +
                            "<td style='font-weight:bold;padding:5px;'> Fecha de carga: </td>" +
                            "<td style='padding:5px;text-align: center;' colspan='2'>" + fecha + " </td></tr><tr style='font-size: 18px;'>" +
                            "<td style='font-weight:bold;padding:5px;'> Usuario que carga: </td>" +
                            "<td style='padding:5px;text-align: center;' colspan='2'>" + user + " </td></tr><tr style='font-size: 18px;'>" +
                            "<td style='font-weight:bold;padding:5px;'> Correo: </td>" +
                            "<td style='padding:5px;text-align: center;' colspan='2'>" + email + " </td></tr><tr style='font-size: 18px;'>" +
                            "<td style='font-weight:bold;padding:5px;'> Comentarios </td>" +
                            "<td style='padding:5px;text-align: center;' colspan='2'>" + Comentarios + " </td> </tr></table>";
            try
            {


                AlternateView plainView =
                AlternateView.CreateAlternateViewFromString(String.Empty,
                             Encoding.UTF8,
                             MediaTypeNames.Text.Plain);

                AlternateView htmlView =
                AlternateView.CreateAlternateViewFromString(msgEnvia,
                             Encoding.UTF8,
                             MediaTypeNames.Text.Html);


                MailMessage msg = new MailMessage();
                try
                {

                    if (DestinosEmail.Length > 0)
                    {

                        String[] strCorreos = DestinosEmail.Split('|');
                        foreach (String correo in strCorreos)
                        {
                            if (!correo.Trim().ToString().Equals(String.Empty))
                            {
                                if (correo.Contains("@"))
                                {
                                    MailAddress mailAddress = new MailAddress(correo);
                                    if (!msg.To.Contains(mailAddress))
                                    {
                                        msg.To.Add(new MailAddress(correo));
                                    }

                                }
                            }
                        }
                    }
                }
                catch (Exception)
                {



                }

                msg.Subject = "Avisos comercio exterior";

                msg.AlternateViews.Add(plainView);


                msg.AlternateViews.Add(htmlView);

                SmtpClient client = new SmtpClient();

                msg.From = new MailAddress("avisos.proveedores@gis.com.mx", "Avisos comercio exterior");
                client.UseDefaultCredentials = false;
                client.Port = 25;
                client.Host = "correo.gis.com.mx";
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.EnableSsl = false;
                client.Send(msg);

            }
            catch (Exception ex)
            {
                msgError = ex.Message;
                boolProcess = false;
            }


            return boolProcess;
        }

        public bool PruebaEnviaCorreo(String Asunto, String DestinosEmail, String FromEmail, String FromNombreEmail, out String msgError)
        {

            String msgEnvia = "<table WIDTH='30%' style='border: 2px solid black; border-collapse: collapse; margin: 20px;margin: 0 auto;'>   <tr style='border: 1px solid black; border-collapse: collapse;padding: 15px;'>       <th colspan='2' style='font-size: 20px; padding: 15px;'>Comercio Exterior</th>     </tr>     <tr>       <td colspan='2' style='font-size: 18px; border: 1px solid black; border-collapse: collapse; padding: 15px;'>Texto por definir...</td>     </tr>     <tr style='font-size: 18px; '>     <tr style='font-size: 18px;'>     <td style='font-weight:bold;padding: 5px;'>Negocio</td>       <td style='padding: 5px;text-align: center;' >17°C</td>     </tr>     <tr style='font-size: 18px;'>       <td style='font-weight:bold;padding: 5px;'>Docomentos Totales</td>       <td style='padding: 5px;text-align: center;'>E 11 km/h</td>     </tr>   <tr style='font-size: 18px;'>         <td style='font-weight:bold;padding: 5px;'>Incidencias</td>           <td style='padding: 5px;text-align: center;'>E 11 km/h</td>         </tr>        <tr style='font-size: 18px;'>         <td style='font-weight:bold;padding: 5px;'>Incidencias Activas</td>           <td style='padding: 5px;text-align: center;'>E 11 km/h</td>         </tr>          <tr style='font-size: 18px;'>         <td style='font-weight:bold;padding: 5px;'>Estatus</td>           <td style='padding: 5px;text-align: center;'>E 11 km/h</td>         </tr>         <tr style='font-size: 18px;'>         <td style='font-weight:bold;padding: 5px;'>Fecha</td>           <td style='padding: 5px;text-align: center;'>E 11 km/h</td>         </tr>   </table>";

            Boolean boolProcess = true;
            msgError = String.Empty;

            MailMessage mmsg = new MailMessage();
            mmsg.To.Add(DestinosEmail);
            mmsg.Subject = Asunto;
            mmsg.SubjectEncoding = Encoding.UTF8;
            mmsg.Bcc.Add(DestinosEmail); // Encia copias cpp
            mmsg.Body = msgEnvia;
            mmsg.BodyEncoding = Encoding.UTF8;
            mmsg.IsBodyHtml = true; // Le dice al sistema que el body del mail lo estoy agregando en formato html
            mmsg.From = new MailAddress(FromEmail);

            // Cliente Correo
            SmtpClient cliente = new SmtpClient();
            cliente.Credentials = new NetworkCredential("fcosaucedon@gmail.com", "google310782");
            cliente.Port = 465;
            cliente.EnableSsl = true;
            cliente.Host = "smtp.gmail.com";

            try
            {
                cliente.Send(mmsg);
                //XtraMessageBox.Show("Correo enviado con exito...!");
            }
            catch (Exception e)
            {
                string x = e.Message;
                //XtraMessageBox.Show("Error al enviar el Correo: " + e.Message);
            }

            return boolProcess;
        }

        public String formatoHtmlProoveedor_1_20200716()
        {
            String strResult = String.Empty;

            StringBuilder msgReturn = new StringBuilder();
            try
            {
                msgReturn.AppendLine("<img width=\"200\" src=\"cid:logo\">");
                msgReturn.AppendLine("<p style=\"text - align: justify;\">Estimados Proveedores:</p>");
                msgReturn.AppendLine("<p style=\"text-align: justify;\"><br/> Como se mencion&oacute; en comunicados anteriores, el<strong> 16 de junio del 2020 se lanz&oacute; en las empresas de Grupo Industrial Saltillo una nueva plataforma para el registro de sus facturas.</strong></p>");
                msgReturn.AppendLine("<p style=\"text-align: justify;\">A partir de esa fecha<strong>, esta es la &uacute;nica forma para registrar tus facturas para pago.</strong></p>");
                msgReturn.AppendLine("<p style=\"text-align: justify;\">Te pedimos que consultes el video y la gu&iacute;a r&aacute;pida que se adjunta para conocer c&oacute;mo realizar el registro de tus facturas en el portal:</p>");
                msgReturn.AppendLine("<p style=\"text-align: center;\"><a href=\"https://sway.office.com/Km0yunI5fi8QWVaK?ref=Link\">https://sway.office.com/Km0yunI5fi8QWVaK?ref=Link</a></p>");
                msgReturn.AppendLine("<p style=\"text-align: justify;\">En el Portal adem&aacute;s podr&aacute;s consultar el estatus de las facturas.</p>");
                msgReturn.AppendLine("<p style=\"text-align: justify;\">Si no tienes usuario o contrase&ntilde;a para acceder al portal, env&iacute;a un correo a <a href=\"mailto:datosmaestros.csc@gis.com.mx\">datosmaestros.csc@gis.com.mx</a>&nbsp;adjuntando RFC, raz&oacute;n social, nombre completo del contacto, n&uacute;mero de tel&eacute;fono y correo electr&oacute;nico.</p>");
                msgReturn.AppendLine("<p style=\"text-align: justify;\"><strong>Nota: Cabe mencionar que con Draxton iniciamos con esta forma de registro a finales de 2019.</strong></p>");
                msgReturn.AppendLine("<p style=\"text-align: justify;\">Agradecemos su apoyo y quedamos a sus ordenes,</p>");
                msgReturn.AppendLine("<p style=\"text-align: center;\">Atentamente,</p>");
                msgReturn.AppendLine("<p style=\"text-align: center;\">GRUPO INDUSTRIAL SALTILLO SA DE CV</p>");
                msgReturn.AppendLine("<p style=\"text-align: center;\">AGUAS INDUSTRIALES DE SALTILLO SA DE CV</p>");
                msgReturn.AppendLine("<p style=\"text-align: center;\">AXIMUS SA DE CV</p>");
                msgReturn.AppendLine("<p style=\"text-align: center;\">AZENTI SA DE CV</p>");
                msgReturn.AppendLine("<p style =\"text-align: center;\">&nbsp;</p>");

                msgReturn.AppendLine("<p style=\"text-align: center;\"><img width=\"800\" src=\"cid:imagen\"></p>");


                strResult = msgReturn.ToString();

            }
            catch (Exception ex)
            {
                msgReturn.AppendLine(ex.ToString());
            }
            return strResult;
        }

        public String formatoHtmlProveedor()
        {
            String strResult = String.Empty;

            StringBuilder msgReturn = new StringBuilder();
            try
            {
                msgReturn.AppendLine("<table style=\"max-Width: 1000px; width: 100%;\"><tbody><tr style=\"height: 18px;\"><td style=\"width: 100%; height: 18px;\">&nbsp;<big><big>Estimado Proveedor:</big></big></td></tr><tr style=\"height: 18px;\"><td style=\"width: 100%; height: 18px;\">&nbsp;</td></tr><tr style=\"height: 52px;\"><td style=\"width: 100%; text-align: justify; height: 50px;\">&nbsp;<big><big>En las empresas de Grupo Industrial Saltillo estamos comprometidos en promover la mejora continua de nuestros procesos administrativos</big></big>.</td></tr><tr style=\"height: 36px;\"><td style=\"width: 100%; text-align: justify; height: 50px;\">&nbsp;<big><big>En los pr&oacute;ximos d&iacute;as estaremos lanzando la nueva funcionalidad del Portal de Proveedores, la cual ofrecer&aacute; beneficios importantes para ustedes.</big></big></td></tr><tr style=\"height: 54px;\"><td style=\"width: 100%; text-align: justify; height: 50px;\">&nbsp;<big><big>El portal de proveedores (iSupplier) ser&aacute; el &uacute;nico medio para <strong>registrar tus facturas para su proceso de pago, adem&aacute;s te permitir&aacute; visualizar el estatus de la misma</strong>. Esto se podr&aacute; realizar de una forma muy sencilla al relacionar las &oacute;rdenes de compra con tus facturas.</big></big></td></tr><tr style=\"height: 36px;\"><td style=\"width: 100%; text-align: justify; height: 50px;\">&nbsp;<big><big>Estamos seguros que esta mejora garantizar&aacute; que tu factura est&aacute; en proceso de pago de acuerdo a las condiciones pactadas.</big></big></td></tr><tr style=\"height: 36px;\"><td style=\"width: 100%; text-align: justify; height: 50px;\">&nbsp;<big><big>Pronto te daremos m&aacute;s informaci&oacute;n sobre las fechas de despliegue de &eacute;sta iniciativa y te enviaremos el video y la gu&iacute;a de operaci&oacute;n para el registro de tus facturas.</big></big></td></tr><tr style=\"height: 18px;\"><td style=\"width: 100%; height: 18px;\">&nbsp;</td></tr><tr style=\"height: 18px;\"><td style=\"width: 100%; text-align: left; height: 18px;\">&nbsp;<big><big>Quedamos a tus &oacute;rdenes.</big></big></td></tr><tr style=\"height: 18px;\"><td style=\"width: 100%; height: 18px;\">&nbsp;</td></tr><tr style=\"height: 46px;\"><td style=\"width: 100%; height: 46px;\"><p style=\"text-align: center;\"><big><big>Atentamente,</big></big></p></td></tr><tr style=\"height: 18px;\"><td style=\"width: 100%; height: 18px;\">&nbsp;</td></tr><tr style=\"height: 18px;\"><td style=\"width: 100%; text-align: center; height: 18px;\"><img width=\"800\" src=\"cid:imagen\"></td></tr></tbody></table><p style=\"text-align: justify;\">&nbsp;</p><p style=\"text-align: justify;\">&nbsp;</p><p style=\"text-align: justify;\"><br /><br /></p><p style=\"text-align: justify;\">&nbsp;</p><p style=\"text-align: justify;\">&nbsp;</p><p style=\"text-align: justify;\">&nbsp;</p><p style=\"text-align: justify;\"><br /> &nbsp;</p><p style=\"text-align: center;\">&nbsp;</p><p style=\"text-align: center;\">&nbsp;</p><p style=\"text-align: center;\">&nbsp;</p>");

                strResult = msgReturn.ToString();

            }
            catch (Exception ex)
            {
                msgReturn.AppendLine(ex.ToString());
            }
            return strResult;
        }

        public String formatoHtmlProveedor2()
        {
            String strResult = String.Empty;

            StringBuilder msgReturn = new StringBuilder();
            try
            {
                msgReturn.AppendLine("<table><tbody><tr><td>&nbsp;<img width=\"200\" src=\"cid:logo\"></td></tr><tr><td>&nbsp;</td></tr><tr><td>&nbsp;</td></tr><tr><td><big><big>Estimado Proveedor:</big></big></td></tr><tr><td>&nbsp;</td></tr><tr><td>&nbsp;<big><big>Como se lo informamos en el comunicado anterior, en las empresas de Grupo Industrial de Saltillo estamos lanzando una nueva plataforma para el registro de sus facturas para pago</big></big>.</td></tr><tr><td>&nbsp;<big><big>A partir del <strong>16 de junio de 2020</strong> deber&aacute;s asociar tus facturas con las órdenes de compra en nuestro portal de proveedores (siguiendo unos sencillos pasos que se describen en el video y la gu&iacute;a r&aacute;pida que se adjunta)</big></big></td></tr><tr><td style=\"text-align: center;\"><a title=\"Video\" href=\"https://sway.office.com/Km0yunI5fi8QWVaK?ref=Link\">https://</a><a title=\"Video\" href=\"https://sway.office.com/Km0yunI5fi8QWVaK?ref=Link\">sway.office.com/Km0yunI5fi8QWVaK?ref=Link</a></td></tr><tr><td>&nbsp;<big><big>Este proceso te permitir&aacute; realizar el registro de tus facturas de una manera m&aacute;s eficiente para procesar el pago oportunamente, adem&aacute;s podr&aacute;s consultar el estatus de las mismas</big></big></td></tr><tr><td><p>&nbsp;<big><big>Si no tienes usuario o contrase&ntilde;a para acceder al portal, env&iacute;a un correo a <a href=\"mailto:datosmaestros.csc@gis.com.mx\">datosmaestros.csc@gis.com.mx</a></big></big><big><big> adjuntando RFC, raz&oacute;n social, nombre completo del contacto, n&uacute;mero de tel&eacute;fono y correo electr&oacute;nico</big></big></p></td></tr><tr><td>&nbsp;</td></tr><tr><td>&nbsp;<big><big>Agradecemos su apoyo y quedamos a sus órdenes,</big></big></td></tr><tr><td>&nbsp;</td></tr><tr><td><p style=\"text-align: center;\"><big><big>Atentamente,</big></big></p></td></tr><tr><td>&nbsp;</td></tr><tr><td style=\"text-align: center;\"><big><big>GRUPO INDUSTRIAL SALTILLO SA DE CV</big></big></td></tr><tr><td style=\"text-align: center;\"><big><big>AGUAS INDUSTRIALES DE SALTILLO SA DE CV</big></big></td></tr><tr><td style=\"text-align: center;\">&nbsp;<big><big>AXIMUS SA DE CV</big></big></td></tr><tr><td style=\"text-align: center;\">&nbsp;<big><big>AZENTI SA DE CV</big></big></td></tr><tr><td style=\"text-align: center;\">&nbsp;</td></tr><tr><td>&nbsp;</td></tr><tr><td><center><img width=\"800\" src=\"cid:imagen\"></center></td></tr></tbody></table><p>&nbsp;</p><p>&nbsp;</p><p><br /><br /></p><p>&nbsp;</p><p>&nbsp;</p><p>&nbsp;</p><p><br /> &nbsp;</p><p>&nbsp;</p><p>&nbsp;</p><p>&nbsp;</p>");

                strResult = msgReturn.ToString();

            }
            catch (Exception ex)
            {
                msgReturn.AppendLine(ex.ToString());
            }
            return strResult;
        }

        public String formatoHtmlProoveedor_31082020()
        {
            String strResult = String.Empty;

            StringBuilder msgReturn = new StringBuilder();
            try
            {
                msgReturn.AppendLine("<table style=\"width: 800px;\">");
                msgReturn.AppendLine("<tbody>");
                msgReturn.AppendLine("<tr>");
                msgReturn.AppendLine("<td style=\"width: 800px;\"><img width=\"200\" src=\"cid:logo\"></td>");
                msgReturn.AppendLine("</tr>");
                msgReturn.AppendLine("<tr>");
                msgReturn.AppendLine("<td style=\"width: 800px;\">");
                msgReturn.AppendLine("<p>Estimados Proveedores:</p>");
                msgReturn.AppendLine("<p>Como se los hemos informado en comunicados anteriores, en las empresas de Grupo Industrial de Saltillo lanzamos una plataforma para el registro de sus facturas para pago.</p>");
                msgReturn.AppendLine("<p>Desde el pasado <strong>16 de junio de 2020</strong> deber&aacute;n asociar sus facturas con las &oacute;rdenes de compra en nuestro portal de proveedores (iSupplier) siguiendo unos sencillos pasos que se describen en el video contenido en el siguiente enlace:</p>");
                msgReturn.AppendLine("<p><a href=\"https://sway.office.com/Km0yunI5fi8QWVaK?ref=Link\">https://sway.office.com/Km0yunI5fi8QWVaK?ref=Link</a></p>");
                msgReturn.AppendLine("<p>De forma adicional, se redise&ntilde;aron dos gu&iacute;as con el objetivo de apoyar a nuestros proveedores en los procesos de registro de sus facturas y en la soluci&oacute;n de casos de operaci&oacute;n, dichas gu&iacute;as se encuentran adjuntas a este comunicado:</p>");
                msgReturn.AppendLine("<ul>");
                msgReturn.AppendLine("<li>Gu&iacute;a r&aacute;pida para registro de facturas (versi&oacute;n en espa&ntilde;ol y versi&oacute;n en ingl&eacute;s)</li>");
                msgReturn.AppendLine("<li>Gu&iacute;a r&aacute;pida de soluciones a casos de operaci&oacute;n</li>");
                msgReturn.AppendLine("</ul>");
                msgReturn.AppendLine("<p>Este proceso y el uso de las gu&iacute;as publicadas les permitir&aacute;n realizar el registro de sus facturas de una manera m&aacute;s eficiente para procesar el pago oportunamente, adem&aacute;s podr&aacute;n consultar el estatus de las mismas.</p>");
                msgReturn.AppendLine("<p>Recuerden que, si no tienen usuario o contrase&ntilde;a para acceder al portal, deber&aacute;n enviar un correo a <a href=\"mailto:datosmaestros.csc@gis.com.mx\">datosmaestros.csc@gis.com.mx</a> adjuntando RFC, raz&oacute;n social, nombre completo del contacto, n&uacute;mero de tel&eacute;fono y correo electr&oacute;nico.</p>");
                msgReturn.AppendLine("<p>Agradecemos su apoyo y quedamos a sus &oacute;rdenes,</p>");
                msgReturn.AppendLine("<p>&nbsp;&nbsp;&nbsp;</p>");
                msgReturn.AppendLine("<p style=\"text-align: center;\">&nbsp;Atentamente,</p>");
                msgReturn.AppendLine("<p style=\"text-align: center;\">GRUPO INDUSTRIAL SALTILLO SAB DE CV &nbsp;</p>");
                msgReturn.AppendLine("<p style=\"text-align: center;\">AGUAS INDUSTRIALES DE SALTILLO SA DE CV</p>");
                msgReturn.AppendLine("<p style=\"text-align: center;\">AXIMUS SA DE CV</p>");
                msgReturn.AppendLine("<p style=\"text-align: center;\">AZENTI SA DE CV</p>");
                msgReturn.AppendLine("<p style=\"text-align: center;\">&nbsp;</p>");
                msgReturn.AppendLine("</td>");
                msgReturn.AppendLine("</tr>");
                msgReturn.AppendLine("<tr>");
                msgReturn.AppendLine("<td style=\"width: 800px; text-align: center;\"><img width=\"800\" src=\"cid:imagen\"></td>");
                msgReturn.AppendLine("</tr>");
                msgReturn.AppendLine("</tbody>");
                msgReturn.AppendLine("</table>");
                msgReturn.AppendLine("<p style=\"text-align: center;\">&nbsp;</p>");



                strResult = msgReturn.ToString();

            }
            catch (Exception ex)
            {
                msgReturn.AppendLine(ex.ToString());
            }
            return strResult;
        }

        //Envia una sola imagen en el body
        public String formato_ImagenBody()
        {
            String strResult = String.Empty;

            StringBuilder msgReturn = new StringBuilder();
            try
            {
                msgReturn.AppendLine("<a href=\"https://interproveedores.gis.com.mx/\"><img width=\"1000\" src=\"cid:imagen\"></a>");

                strResult = msgReturn.ToString();

            }
            catch (Exception ex)
            {
                msgReturn.AppendLine(ex.ToString());
            }
            return strResult;
        }


    }
}
