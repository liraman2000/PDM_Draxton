using System.Data;
using System.Net;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Security.Cryptography;

namespace PDM_Draxton.utilidades
{
    public class Funciones
    {

        #region Encriptar
        public string Encriptar(string textoQueEncriptaremos)
        {
            return Encriptar(textoQueEncriptaremos,
              "GIS17d09/@avz10", "s@lAvz", "MD5", 1, "@1B2c3D4e5F6g7H8", 128);
        }
        private string Encriptar(string textoQueEncriptaremos,
           string passBase, string saltValue, string hashAlgorithm,
           int passwordIterations, string initVector, int keySize)
        {
            byte[] initVectorBytes = Encoding.ASCII.GetBytes(initVector);
            byte[] saltValueBytes = Encoding.ASCII.GetBytes(saltValue);
            byte[] plainTextBytes = Encoding.UTF8.GetBytes(textoQueEncriptaremos);
            PasswordDeriveBytes password = new PasswordDeriveBytes(passBase,
              saltValueBytes, hashAlgorithm, passwordIterations);
            byte[] keyBytes = password.GetBytes(keySize / 8);
            RijndaelManaged symmetricKey = new RijndaelManaged()
            {
                Mode = CipherMode.CBC
            };
            ICryptoTransform encryptor = symmetricKey.CreateEncryptor(keyBytes,
              initVectorBytes);
            MemoryStream memoryStream = new MemoryStream();
            CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor,
             CryptoStreamMode.Write);
            cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
            cryptoStream.FlushFinalBlock();
            byte[] cipherTextBytes = memoryStream.ToArray();
            memoryStream.Close();
            cryptoStream.Close();
            string cipherText = Convert.ToBase64String(cipherTextBytes);
            return cipherText;
        }
        #endregion

        #region Desencriptar
     public string Desencriptar(string textoEncriptado)
        {
            //return Desencriptar(textoEncriptado, "GIS17d09/@avz10", "s@lAvz", "MD5",
            //  1, "@1B2c3D4e5F6g7H8", 128);
              return Desencriptar(textoEncriptado, "GIS17d09/@avz10", "s@lAvz", "MD5",
             1, "@1B2c3D4e5F6g7H8", 128);
        }
        private string Desencriptar(string textoEncriptado, string passBase,
          string saltValue, string hashAlgorithm, int passwordIterations,
          string initVector, int keySize)
        {
            byte[] initVectorBytes = Encoding.ASCII.GetBytes(initVector);
            byte[] saltValueBytes = Encoding.ASCII.GetBytes(saltValue);
            byte[] cipherTextBytes = Convert.FromBase64String(textoEncriptado);
            PasswordDeriveBytes password = new PasswordDeriveBytes(passBase,
              saltValueBytes, hashAlgorithm, passwordIterations);
            byte[] keyBytes = password.GetBytes(keySize / 8);
            RijndaelManaged symmetricKey = new RijndaelManaged()
            {
                Mode = CipherMode.CBC
            };
            ICryptoTransform decryptor = symmetricKey.CreateDecryptor(keyBytes,
              initVectorBytes);
            MemoryStream memoryStream = new MemoryStream(cipherTextBytes);
            CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor,
              CryptoStreamMode.Read);
            byte[] plainTextBytes = new byte[cipherTextBytes.Length];
            int decryptedByteCount = cryptoStream.Read(plainTextBytes, 0,
              plainTextBytes.Length);
            memoryStream.Close();
            cryptoStream.Close();
            string plainText = Encoding.UTF8.GetString(plainTextBytes, 0,
              decryptedByteCount);
            return plainText;
        }
        #endregion
      

        public string limpiarString(String texto)
        {
            string consignos = "áàäéèëíìïóòöúùuñÁÀÄÉÈËÍÌÏÓÒÖÚÙÜÑçÇ";
            string sinsignos = "aaaeeeiiiooouuunAAAEEEIIIOOOUUUNcC";
            StringBuilder textoSinAcentos = new StringBuilder(texto.Length);
            int indexConAcento;
            foreach (char caracter in texto)
            {
                indexConAcento = consignos.IndexOf(caracter);
                if (indexConAcento > -1)
                    textoSinAcentos.Append(sinsignos.Substring(indexConAcento, 1));
                else
                    textoSinAcentos.Append(caracter);
            }
            textoSinAcentos = textoSinAcentos.Replace(Environment.NewLine, "<br>");
            textoSinAcentos = textoSinAcentos.Replace("\r\n", "<br>");
            textoSinAcentos = textoSinAcentos.Replace("\n", "<br>");
            textoSinAcentos = textoSinAcentos.Replace("\r", "<br>");
            textoSinAcentos = textoSinAcentos.Replace("'", "");
            textoSinAcentos = textoSinAcentos.Replace(Convert.ToString((char)92), " ");
            textoSinAcentos = textoSinAcentos.Replace(":", "");
            textoSinAcentos = textoSinAcentos.Replace("(", "");
            textoSinAcentos = textoSinAcentos.Replace(")", "");

            return textoSinAcentos.ToString();
        }

        public string PrettyXml(string xml)
        {
            var stringBuilder = new StringBuilder();

            var element = XElement.Parse(xml);

            var settings = new XmlWriterSettings();
            settings.OmitXmlDeclaration = true;
            settings.Indent = true;
            settings.NewLineOnAttributes = true;

            using (var xmlWriter = XmlWriter.Create(stringBuilder, settings))
            {
                element.Save(xmlWriter);
            }

            return stringBuilder.ToString();
        }

        public byte[] ToByteArray(Stream stream)
        {
            byte[] buffer = null;
            try
            {
                stream.Position = 0;
                buffer = new byte[stream.Length];
                for (int totalBytesCopied = 0; totalBytesCopied < stream.Length;)
                    totalBytesCopied += stream.Read(buffer, totalBytesCopied, Convert.ToInt32(stream.Length) - totalBytesCopied);

            }
            catch (Exception)
            {

            }
            return buffer;
        }

        public String getFechaOfString(String fechaNum)
        {

            String valReturn = null;

            try
            {

                if (fechaNum.Length >= 8)
                {
                    valReturn = fechaNum.Substring(0, 4).ToString() + "-" + fechaNum.Substring(4, 2).ToString() + "-" + fechaNum.Substring(6, 2).ToString() + "T";
                }

                if (fechaNum.Length >= 10)
                {
                    valReturn = valReturn + fechaNum.Substring(8, 2).ToString() + ":";
                }
                else
                {
                    valReturn = valReturn + "00" + ":";
                }

                if (fechaNum.Length >= 12)
                {
                    valReturn = valReturn + fechaNum.Substring(10, 2).ToString() + ":";
                }
                else
                {
                    valReturn = valReturn + "00" + ":";
                }

                if (fechaNum.Length >= 4)
                {
                    valReturn = valReturn + fechaNum.Substring(12, 2).ToString();
                }
                else
                {
                    valReturn = valReturn + "00";
                }


            }
            catch (Exception)
            {
            }

            return valReturn;
        }

        public Stream GenerateStreamFromString(string strData)
        {
            MemoryStream stream = null;
            try
            {
                stream = new MemoryStream();
                StreamWriter writer = new StreamWriter(stream);
                writer.Write(strData);
                writer.Flush();
                stream.Position = 0;
                return stream;
            }
            catch (Exception)
            {
                stream = null;
            }
            return stream;
        }

        public String genPassRandom()
        {
            String pass = String.Empty;
            int passLenght = 8;

            try
            {
                String valuesAlfa = "a|0|A|1|b|2|B|c|3|X|d|4|D|e|E|5|f|F|g|6|G|h|H|7|i|I|j|8|J|k|K|l|L|9|m|M|n|N|o|O|p|P|q|Q|r|R|s|S|t|T|u|U|v|V|w|W|x|X|y|Y|z|Z";
                String valuesSpecials = "&|/|$|!|=|-";

                String[] valuesAlfaArr = valuesAlfa.Split('|');
                String[] valuesSpecialsArr = valuesSpecials.Split('|');

                Random rnd = new Random();


                int pos = rnd.Next(0, valuesSpecialsArr.Length - 1);

                for (int i = 1; i <= passLenght; i++)
                {
                    if (i == 1)
                    {
                        pass = valuesSpecialsArr[pos].ToString();
                    }
                    else
                    {
                        if (i == 2)
                        {
                            pos = rnd.Next(0, valuesAlfaArr.Length - 1);
                            pass = pass + valuesAlfaArr[pos].ToString().ToUpper();
                        }
                        else
                        {
                            pos = rnd.Next(0, valuesAlfaArr.Length - 1);
                            pass = pass + valuesAlfaArr[pos].ToString();
                        }
                    }
                }

                pass = Encriptar(pass);

            }
            catch (Exception)
            {
            }

            return pass;
        }

        //public Boolean fs_LogIn(String usuario, String psw, out String msgError, ref int idTrk)
        //{
        //    idTrk = 15;
        //    Boolean boolProcess = true;
        //    msgError = String.Empty;

        //    String Dominio = "https://fs.gis.com.mx/";
        //    String API = "adfs/services/trust/2005/usernamemixed";

        //    HttpWebResponse response;
        //    StreamReader readerResponse;
        //    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Dominio + API);

        //    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

        //    request.ProtocolVersion = HttpVersion.Version11;
        //    request.Method = WebRequestMethods.Http.Post;
        //    request.ContentType = "application/soap+xml; charset=utf-8";

        //    idTrk = 16;

        //    if (usuario.Contains("@"))
        //    {
        //        usuario = usuario.Split('@')[0].ToString();
        //    }

        //    if (usuario.Length > 20)
        //    {
        //        usuario = usuario.Substring(0, 20);
        //    }

        //    String Content = "<s:Envelope xmlns:s=\"http://www.w3.org/2003/05/soap-envelope\" xmlns:a=\"http://www.w3.org/2005/08/addressing\" xmlns:u=\"http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-utility-1.0.xsd\">" +
        //              "<s:Header><a:Action s:mustUnderstand=\"1\">http://schemas.xmlsoap.org/ws/2005/02/trust/RST/Issue</a:Action><a:ReplyTo><a:Address>http://www.w3.org/2005/08/addressing/anonymous</a:Address></a:ReplyTo><a:To s:mustUnderstand=\"1\">" +
        //              "https://fs.gis.com.mx/adfs/services/trust/2005/usernamemixed</a:To><o:Security s:mustUnderstand=\"1\" xmlns:o=\"http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd\">" +
        //              "<o:UsernameToken><o:Username>gis\\" + usuario + "</o:Username>" +
        //              "<o:Password>" + psw + "</o:Password>" +
        //              "</o:UsernameToken></o:Security></s:Header><s:Body><t:RequestSecurityToken xmlns:t=\"http://schemas.xmlsoap.org/ws/2005/02/trust\">" +
        //              "<wsp:AppliesTo xmlns:wsp=\"http://schemas.xmlsoap.org/ws/2004/09/policy\"><a:EndpointReference><a:Address>http://fs.gis.com.mx/adfs/services/trust</a:Address></a:EndpointReference></wsp:AppliesTo><t:KeyType>http://schemas.xmlsoap.org/ws/2005/05/identity/NoProofKey</t:KeyType><t:RequestType>http://schemas.xmlsoap.org/ws/2005/02/trust/Issue</t:RequestType><t:TokenType>urn:oasis:names:tc:SAML:1.0:assertion</t:TokenType></t:RequestSecurityToken></s:Body></s:Envelope>";

        //    try
        //    {
        //        idTrk = 17;
        //        var dataPost = Encoding.ASCII.GetBytes(Content);
        //        Stream newStream = request.GetRequestStream();
        //        // Send the data.
        //        newStream.Write(dataPost, 0, dataPost.Length);
        //        newStream.Close();
        //        idTrk = 18;
        //        response = (HttpWebResponse)request.GetResponse();

        //        readerResponse = new StreamReader(response.GetResponseStream());

        //        StringReader strReader = new StringReader(readerResponse.ReadToEnd());

        //        idTrk = 19;
        //        String Respuesta = strReader.ReadToEnd();

        //        DataSet dsResp = new DataSet();

        //        StringReader theReader = new StringReader(Respuesta);
        //        dsResp.ReadXml(theReader, XmlReadMode.InferSchema);

        //        String Token = dsResp.Tables["SecurityContextToken"].Rows[0]["Cookie"].ToString();
        //        idTrk = 20;
        //        if (Token == String.Empty)
        //        {
        //            boolProcess = false;
        //            msgError = "Favor de validar usuario y contraseña.";
        //        }

        //    }
        //    catch (System.Net.WebException ex)
        //    {

        //        //try
        //        //{
        //        //    response = (HttpWebResponse)ex.Response;

        //        //    readerResponse = new StreamReader(response.GetResponseStream());

        //        //    StringReader strReader = new StringReader(readerResponse.ReadToEnd());


        //        //    String Respuesta = strReader.ReadToEnd();
        //        //}
        //        //catch (Exception ex)
        //        //{
        //        //    boolProcess = false;
        //        //    msgError = ex.Message;
        //        //}
        //        boolProcess = false;
        //        msgError = ex.Message;

        //    }

        //    return boolProcess;
        //}

        public Boolean fs_LogIn(String usuario, String psw, out String msgError, String lenguaje = "esp")
        {
            Boolean boolProcess = true;
            msgError = String.Empty;

            String Dominio = "https://fs.gis.com.mx/";
            String API = "adfs/services/trust/2005/usernamemixed";

            HttpWebResponse response;
            StreamReader readerResponse;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Dominio + API);

            request.ProtocolVersion = HttpVersion.Version11;
            request.Method = WebRequestMethods.Http.Post;
            request.ContentType = "application/soap+xml; charset=utf-8";


            if (usuario.Contains("@"))
            {
                usuario = usuario.Split('@')[0].ToString();
            }

            if (usuario.Length > 20)
            {
                usuario = usuario.Substring(0, 20);
            }

            String Content = "<s:Envelope xmlns:s=\"http://www.w3.org/2003/05/soap-envelope\" xmlns:a=\"http://www.w3.org/2005/08/addressing\" xmlns:u=\"http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-utility-1.0.xsd\">" +
                      "<s:Header><a:Action s:mustUnderstand=\"1\">http://schemas.xmlsoap.org/ws/2005/02/trust/RST/Issue</a:Action><a:ReplyTo><a:Address>http://www.w3.org/2005/08/addressing/anonymous</a:Address></a:ReplyTo><a:To s:mustUnderstand=\"1\">" +
                      "https://fs.gis.com.mx/adfs/services/trust/2005/usernamemixed</a:To><o:Security s:mustUnderstand=\"1\" xmlns:o=\"http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd\">" +
                      "<o:UsernameToken><o:Username>gis\\" + usuario + "</o:Username>" +
                      "<o:Password>" + psw + "</o:Password>" +
                      "</o:UsernameToken></o:Security></s:Header><s:Body><t:RequestSecurityToken xmlns:t=\"http://schemas.xmlsoap.org/ws/2005/02/trust\">" +
                      "<wsp:AppliesTo xmlns:wsp=\"http://schemas.xmlsoap.org/ws/2004/09/policy\"><a:EndpointReference><a:Address>http://fs.gis.com.mx/adfs/services/trust</a:Address></a:EndpointReference></wsp:AppliesTo><t:KeyType>http://schemas.xmlsoap.org/ws/2005/05/identity/NoProofKey</t:KeyType><t:RequestType>http://schemas.xmlsoap.org/ws/2005/02/trust/Issue</t:RequestType><t:TokenType>urn:oasis:names:tc:SAML:1.0:assertion</t:TokenType></t:RequestSecurityToken></s:Body></s:Envelope>";

            try
            {

                var dataPost = Encoding.ASCII.GetBytes(Content);
                Stream newStream = request.GetRequestStream();
                // Send the data.
                newStream.Write(dataPost, 0, dataPost.Length);
                newStream.Close();

                response = (HttpWebResponse)request.GetResponse();

                readerResponse = new StreamReader(response.GetResponseStream());

                StringReader strReader = new StringReader(readerResponse.ReadToEnd());


                String Respuesta = strReader.ReadToEnd();

                DataSet dsResp = new DataSet();

                StringReader theReader = new StringReader(Respuesta);
                dsResp.ReadXml(theReader, XmlReadMode.InferSchema);

                String Token = dsResp.Tables["SecurityContextToken"].Rows[0]["Cookie"].ToString();

                if (Token == String.Empty)
                {
                    boolProcess = false;
                    switch (lenguaje)
                    {
                        case "esp":
                            msgError = "Favor de validar usuario y contraseña.";
                            break;
                        case "eng":

                            msgError = "Please validate username and password.";
                            break;
                    }
                }

            }
            catch (System.Net.WebException ex)
            {
                boolProcess = false;
                switch (lenguaje)
                {
                    case "esp":
                        msgError = "Favor de validar usuario y contraseña.";
                        break;
                    case "eng":

                        msgError = "Please validate username and password.";
                        break;
                }
            }

            return boolProcess;
        }


        public String getStringElement(XElement xElm, String ElementoBase, String ElementoValor)
        {
            String valReturn = null;
            try
            {
                if ((from xml2 in xElm.Descendants(ElementoBase) select xml2).FirstOrDefault().Element(ElementoValor) != null)
                {
                    valReturn = (from xml2 in xElm.Descendants(ElementoBase) select xml2).FirstOrDefault().Element(ElementoValor).Value.ToString();
                }
            }
            catch (Exception)
            {
            }
            return valReturn;
        }

        public String getStringElementSection(XElement xElm, String ElementoValor)
        {
            String valReturn = String.Empty;
            try
            {
                if (xElm.Element(ElementoValor) != null)
                {
                    valReturn = xElm.Element(ElementoValor).Value.ToString();
                }
            }
            catch (Exception ex)
            {
            }
            return valReturn;
        }

        private string GeneraParamsUrls(String Valor)
        {
            //Funciones fn = new Funciones();

            String valEnc;

            valEnc = Encriptar(Valor);

            valEnc = valEnc.Replace("+", "-");

            return valEnc;
        }

        public Boolean formatFecha(DateTime fecha, out String fechaBien, out String hora, out String minuto, out String AmPm, out String msgError)
        {
            Boolean boolProces = true;
            fechaBien = String.Empty;
            hora = String.Empty;
            minuto = String.Empty;
            AmPm = String.Empty;
            msgError = String.Empty;
            try
            {
                hora = fecha.ToString("hh").Trim();
                minuto = fecha.ToString("mm").Trim();
                AmPm = fecha.ToString("tt").Trim();
                fechaBien = fecha.ToString("yyyy-MM-dd").Trim();
                while (AmPm.Contains(" ") || AmPm.Contains('.'))
                {
                    AmPm = AmPm.Replace(" ", "").Trim();
                    AmPm = AmPm.Replace('.', ' ').Trim();
                }
            }
            catch (Exception ex)
            {
                msgError = ex.ToString();
            }
            return boolProces;
        }

        public Boolean Fechaformat(string fecha, out String fechaBien, out String msgError)
        {
            Boolean boolProces = true;
            var FechaSplit = fecha.Split(' ');
            var letraMes = FechaSplit[1];
            var Fechadia = FechaSplit[2];
            var Fechaanio = FechaSplit[3];
            fechaBien = String.Empty;

            msgError = String.Empty;
            try
            {
                letraMes = letraMes.ToUpper();
                string numMes = string.Empty;
                switch (letraMes)
                {
                    case "JAN":
                        numMes = "01";
                        break;
                    case "FEB":
                        numMes = "02";
                        break;
                    case "MAR":
                        numMes = "03";
                        break;
                    case "APR":
                        numMes = "04";
                        break;
                    case "MAY":
                        numMes = "05";
                        break;
                    case "JUN":
                        numMes = "06";
                        break;
                    case "JUL":
                        numMes = "07";
                        break;
                    case "AUG":
                        numMes = "08";
                        break;
                    case "SEP":
                        numMes = "09";
                        break;
                    case "OCT":
                        numMes = "10";
                        break;
                    case "NOV":
                        numMes = "11";
                        break;
                    case "DEC":
                        numMes = "12";
                        break;
                }

                fechaBien = (Fechaanio + "-" + numMes + "-" + Fechadia).Trim();
            }
            catch (Exception ex)
            {
                msgError = ex.ToString();
            }
            return boolProces;
        }


        public Boolean formatFecha(DateTime fecha, int hora, int minuto, string amPm, out DateTime fechaBien, out String msgError)
        {
            Boolean boolProces = true;
            msgError = String.Empty;
            fechaBien = DateTime.Now;
            try
            {
                int hra = 0;
                int anio = fecha.Year;
                int dia = fecha.Day;
                int mes = fecha.Month;
                if (amPm == "pm")
                {
                    hra = hora == 12 ? 12 : hora + 12;
                }
                else
                {
                    hra = hora == 12 ? 0 : hora;
                }
                fechaBien = new DateTime(anio, mes, dia, hra, minuto, 0);
            }
            catch (Exception ex)
            {
                msgError = ex.ToString();
            }
            return boolProces;
        }

        //public String obtenerHTMLEstatus(TripDetalle trip, String msg, String ultimoEstatus, String accion)
        //{
        //    StringBuilder correo = new StringBuilder();
        //    correo.Append(msg);
        //    correo.Append("<table border=\"1\" align=\"center\"><font size=\"4\" face=\"Garamond\" color=\"#003366\"><b><tr align=\"center\">");
        //    correo.Append("<td>Trip</td><td>Planta</td><td>Tonelaje</td><td>M2</td><td>Último estatus</td>");
        //    correo.Append("</tr></b></font><tr align=\"center\"><td>");
        //    correo.Append(trip.TripEncabezadoId);
        //    correo.Append("</td><td>");
        //    correo.Append(trip.CatalogoPlantas.Nombre);
        //    correo.Append("</td><td>");
        //    correo.Append(trip.Tonelaje);
        //    correo.Append("</td><td>");
        //    correo.Append(trip.M2);
        //    correo.Append("</td><td>");
        //    correo.Append(ultimoEstatus);
        //    correo.Append("</td></tr></table>");

        //    return correo.ToString();
        //}


    }
}