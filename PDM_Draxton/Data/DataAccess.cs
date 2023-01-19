using PDM_Draxton.conectores;
using PDM_Draxton.Models;
using PDM_Draxton.utilidades;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using Microsoft.Extensions.Configuration;
using System.Text;
using dll_Gis;



namespace PDM_Draxton.Data
{
    public class DataAccess
    {
        dll_Gis.BaseDatos bd = new dll_Gis.BaseDatos();
        string conexionBD = String.Empty;

        private static dll_Gis.Funciones fn = new dll_Gis.Funciones();
        private static SqlConnection m_objSqlConnection; 
        
        static IConfigurationBuilder configBuilder = new ConfigurationBuilder()
            
            .AddJsonFile("appsettings.json");
        IConfiguration configuration = configBuilder.Build();

        public DataAccess()
        {           
            try
            {

                conexionBD = fn.Desencriptar(configuration.GetConnectionString("conexion").ToString());
                conexionBD += "o=True";
                m_objSqlConnection = new SqlConnection(conexionBD);

       
            }
            catch (Exception)
            {
                throw;
            }
        }

       //usuarios
        public Boolean cons_UsuarioAcceso(string? usuario, out Usuario user, out String msgError)
        {
            bool boolProcess = false;
            msgError = string.Empty;
            DataTable dt = new DataTable();
            user = new Usuario(); SqlParameter[]

            @params = new SqlParameter[1];
            @params[0] = new SqlParameter("@usuario", usuario);
            try
            {
                if (!bd.ExecuteProcedure(conexionBD, "cons_UsuarioAcceso", @params, out dt, 120))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    for (int r = 0; r < dt.Rows.Count; r++)
                    {
                        user.Id = Convert.ToInt32(dt.Rows[r]["Id"]);
                        user.Nombre = dt.Rows[r]["Nombre"].ToString(); user.Correo = dt.Rows[r]["Correo"].ToString();
                        user.UserName = dt.Rows[r]["UserName"].ToString(); user.IdNegocio = Convert.ToInt32(dt.Rows[r]["IdNegocio"]);
                        user.Negocio = dt.Rows[r]["Negocio"].ToString(); user.IdRol = Convert.ToInt32(dt.Rows[r]["IdRol"]);
                        user.Rol = dt.Rows[r]["Rol"].ToString();
                    }
                    if (dt.Rows.Count > 0)
                        boolProcess = true;
                }
            }
            catch (Exception ex) { boolProcess = false; msgError = ex.ToString(); }
            return boolProcess;
        }

        public Boolean cons_Usuario(out List<Usuario> lista, out String msgError)
        {
            bool boolProcess = true;
            msgError = string.Empty;
            DataTable dt = new DataTable();
            //DataSet ds = new DataSet();
            lista = new List<Usuario>();

            //SqlParameter[] @params = new SqlParameter[2];

            try
            {

                if (!bd.ExecuteProcedure(conexionBD, "cons_Usuarios", out dt, 120))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    //dt = ds.Tables[0];
                    for (int r = 0; r < dt.Rows.Count; r++)
                    {
                        Usuario user = new Usuario();
                        user.Id = Convert.ToInt32(dt.Rows[r]["Id"]);
                        user.Nombre = dt.Rows[r]["Nombre"].ToString(); user.Correo = dt.Rows[r]["Correo"].ToString();
                        user.UserName = dt.Rows[r]["UserName"].ToString(); user.IdNegocio = Convert.ToInt32(dt.Rows[r]["IdNegocio"]);
                        user.Negocio = dt.Rows[r]["Negocio"].ToString(); user.IdRol = Convert.ToInt32(dt.Rows[r]["IdRol"]);
                        user.Rol = dt.Rows[r]["Rol"].ToString();

                        lista.Add(user);
                    }
                    boolProcess = true;
                }
            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }

        public Boolean cons_Usuario(int idUsuario, out Usuario user, out String msgError)
        {
            bool boolProcess = true;
            msgError = string.Empty;
            DataTable dt = new DataTable();
            user = new Usuario(); SqlParameter[]
            @params = new SqlParameter[1];
            @params[0] = new SqlParameter("@IdUsuario", idUsuario);
            try
            {
                if (!bd.ExecuteProcedure(conexionBD, "cons_Usuarios", @params, out dt, 120))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    for (int r = 0; r < dt.Rows.Count; r++)
                    {
                        user.Id = Convert.ToInt32(dt.Rows[r]["Id"]);
                        user.Nombre = dt.Rows[r]["Nombre"].ToString(); user.Correo = dt.Rows[r]["Correo"].ToString();
                        user.UserName = dt.Rows[r]["UserName"].ToString(); user.IdNegocio = Convert.ToInt32(dt.Rows[r]["IdNegocio"]);
                        user.Negocio = dt.Rows[r]["Negocio"].ToString(); user.IdRol = Convert.ToInt32(dt.Rows[r]["IdRol"]);
                        user.Rol = dt.Rows[r]["Rol"].ToString();
                    }
                    if (dt.Rows.Count > 0)
                        boolProcess = true;
                }
            }
            catch (Exception ex) { boolProcess = false; msgError = ex.ToString(); }
            return boolProcess;
        }

        public Boolean del_Usuario(int idUsuario, out String msgError)
        {
            bool boolProcess = true;
            msgError = string.Empty;
            DataTable dt = new DataTable();
            SqlParameter[]
            @params = new SqlParameter[1];
            @params[0] = new SqlParameter("@IdUsuario", idUsuario);
            try
            {
                if (!bd.ExecuteProcedure(conexionBD, "del_Usuario", @params, out dt, 120))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {

                }
            }
            catch (Exception ex) { boolProcess = false; msgError = ex.ToString(); }
            return boolProcess;
        }

        public Boolean ins_Usuario(Usuario user, out String msgError)
        {
            bool boolProcess = true;
            DataTable dt = new DataTable();
            msgError = string.Empty;
            int i = 0;
            SqlParameter[] @params = new SqlParameter[4];
            //@params[i] = new SqlParameter("@idUsuario", user.IdUsuario);
            //i++;
            @params[i] = new SqlParameter("@Nombre", user.Nombre);
            i++;
            @params[i] = new SqlParameter("@Correo", user.Correo);
            i++;
            @params[i] = new SqlParameter("@IdRol", user.IdRol);
            i++;
            @params[i] = new SqlParameter("@IdNegocio", user.IdNegocio);

            try
            {
                if (!bd.ExecuteProcedure(conexionBD, "ins_Usuario", @params, out dt, 120))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                if (Convert.ToInt32(dt.Rows[0]["ErrorNumber"]) == 1)
                    msgError = dt.Rows[0]["ErrorMessage"].ToString();
            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }

        public Boolean cons_Negocio(out List<Negocio> lista, out String msgError)
        {
            bool boolProcess = true;
            msgError = string.Empty;
            DataTable dt = new DataTable();
            lista = new List<Negocio>();

            try
            {
                if (!bd.ExecuteProcedure(conexionBD, "cons_Negocio", out dt, 120))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    for (int r = 0; r < dt.Rows.Count; r++)
                    {
                        Negocio neg = new Negocio();
                        neg.Id = dt.Rows[r]["Id"].ToString();
                        neg.Descripcion = dt.Rows[r]["Descripcion"].ToString();
                        neg.RFC = dt.Rows[r]["RFC"].ToString();
                        neg.Activo = dt.Rows[r]["Activo"].ToString();

                        lista.Add(neg);
                    }
                    boolProcess = true;
                }
            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }

        public Boolean cons_Perfil(out List<Perfil> lista, out String msgError)
        {
            bool boolProcess = true;
            msgError = string.Empty;
            DataTable dt = new DataTable();
            lista = new List<Perfil>();

            try
            {
                if (!bd.ExecuteProcedure(conexionBD, "cons_Perfil", out dt, 120))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    for (int r = 0; r < dt.Rows.Count; r++)
                    {
                        Perfil rol = new Perfil();
                        rol.Id = Convert.ToInt32(dt.Rows[r]["Id"]);
                        rol.Descripcion = dt.Rows[r]["Descripcion"].ToString();
                        rol.Activo = dt.Rows[r]["Activo"].ToString();



                        lista.Add(rol);
                    }
                    boolProcess = true;
                }
            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }


        //Comercio
        public Boolean GeneraPeriodos(int IdUsuario, out String msgError)
        {
            bool boolProcess = true;
            msgError = string.Empty;
            DataTable dt = new DataTable();

            SqlParameter[] @params = new SqlParameter[1];
            @params[0] = new SqlParameter("@IdUsuario", IdUsuario);

            try
            {
                if (!bd.ExecuteProcedure(conexionBD, "ins_UpdPeriodos", @params, out dt, 120))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
              
            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }

        public Boolean GeneraPeriodoNegocio(int IdUsuario,out String msgError)
        {
            bool boolProcess = true;
            msgError = string.Empty;
            DataTable dt = new DataTable();

            SqlParameter[] @params = new SqlParameter[1];
            @params[0] = new SqlParameter("@IdUsuario", IdUsuario);

            try
            {
                if (!bd.ExecuteProcedure(conexionBD, "ins_UpdPeriodoNegocio",@params, out dt, 120))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }

        public Boolean GeneraIncidencias(int IdUsuario, out String msgError)
        {
            bool boolProcess = true;
            msgError = string.Empty;
            DataTable dt = new DataTable();

            SqlParameter[] @params = new SqlParameter[1];
            @params[0] = new SqlParameter("@IdUsuario", IdUsuario);

            try
            {
                if (!bd.ExecuteProcedure(conexionBD, "ins_Incidencias", @params, out dt, 120))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }

            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }

        public Boolean cons_Pedimento(int IdUsuario,int Errores ,out List<cDataStage> lista,out String msgError)
        {
            bool boolProcess = true;
            msgError = string.Empty;
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            lista = new List<cDataStage>();

            SqlParameter[] @params = new SqlParameter[2];
            @params[0] = new SqlParameter("@IdUsuario", IdUsuario);
            @params[1] = new SqlParameter("@Errores", Errores);

            try
            {

                if (!bd.ExecuteProcedure(conexionBD, "cons_Pedimentos",@params, out ds, 120))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    dt=ds.Tables[0];
                    for (int r = 0; r < dt.Rows.Count; r++)
                    {
                        cDataStage pedimento = new cDataStage();
                        pedimento.Id = Convert.ToInt32(dt.Rows[r]["id"]);
                        pedimento.Pedimento = dt.Rows[r]["Pedimento"].ToString();
                        pedimento.NumeroFactura = dt.Rows[r]["NumeroFactura"].ToString();
                        pedimento.ProveedorMercancia = dt.Rows[r]["ProveedorMercancia"].ToString();   
                        pedimento.Estatus = dt.Rows[r]["Estatus"].ToString();                        

                        lista.Add(pedimento);
                    }
                    boolProcess = true;
                }
            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }

        public Boolean del_Documento(int idDocumento, out String msgError)
        {
            bool boolProcess = true;
            msgError = string.Empty;
            DataTable dt = new DataTable();
            SqlParameter[]
            @params = new SqlParameter[1];
            @params[0] = new SqlParameter("@IdDocumento", idDocumento);
            try
            {
                if (!bd.ExecuteProcedure(conexionBD, "del_Documento", @params, out dt, 120))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {

                }
            }
            catch (Exception ex) { boolProcess = false; msgError = ex.ToString(); }
            return boolProcess;
        }

        public Boolean cons_DetallePedimento(int IdUsuario, out Pedimento detalle, out String msgError)
        {
            bool boolProcess = true;
            msgError = string.Empty;
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
         
            detalle = new Pedimento();

            SqlParameter[] @params = new SqlParameter[1];
            @params[0] = new SqlParameter("@IdUsuario", IdUsuario);

            try
            {

                if (!bd.ExecuteProcedure(conexionBD, "cons_DetallePedimentos", @params, out ds, 120))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                  
                    dt = ds.Tables[0];
                    detalle.TotalDocumentos = dt.Rows[0]["TotalDocumentos"].ToString();
                    detalle.Incidencias = dt.Rows[0]["Incidencias"].ToString();
                    detalle.Periodo = dt.Rows[0]["Periodos"].ToString();
                    detalle.Errores = dt.Rows[0]["Errores"].ToString();
                    detalle.Archivo = dt.Rows[0]["Archivo"].ToString();
                    detalle.IdNegocio = Convert.ToInt32(dt.Rows[0]["IdNegocio"]);
                    detalle.NombreUsuario = dt.Rows[0]["Usuario"].ToString();
                    detalle.Correo =  dt.Rows[0]["Correo"].ToString();

                    boolProcess = true;
                }
            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }

        public Boolean consultaTasaCero(string ?IdNegocio,DateTime periodo,out List<cTasaCero> lista, out String msgError)
        {
            bool boolProcess = true;
            msgError = string.Empty;
            DataTable dt = new DataTable();
            lista = new List<cTasaCero>();

            SqlParameter[] @params = new SqlParameter[2];
            msgError = string.Empty;
            @params[0] = new SqlParameter("@IdNegocio", IdNegocio);
            @params[1] = new SqlParameter("@Fecha", periodo.ToString("yyyy-MM-dd"));

            try
            {                

                if (!bd.ExecuteProcedure(conexionBD, "cons_TasaCero",@params, out dt, 120))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    for (int r = 0; r < dt.Rows.Count; r++)
                    {
                        cTasaCero tasaCero = new cTasaCero();

                        tasaCero.Id = Convert.ToInt32(dt.Rows[r]["Id"]);
                        tasaCero.UUID = dt.Rows[r]["UUID"].ToString();                        
                        tasaCero.Folio = dt.Rows[r]["Folio"].ToString();
                        tasaCero.rfcReceptor = dt.Rows[r]["RFCReceptor"].ToString();
                        tasaCero.totalFactura = string.Format((IFormatProvider)CultureInfo.InvariantCulture, "$" + "{0:#,#.00}", Convert.ToDouble(dt.Rows[r]["Total"]))
                                + " " + dt.Rows[r]["Moneda"].ToString();
                        //tasaCero.totalFactura = string.Format("{0:C}", Convert.ToDouble(dt.Rows[r]["Total"])) + " " +
                        //        dt.Rows[r]["moneda"].ToString();
                        tasaCero.EstatusCFDI = dt.Rows[r]["EstatusCFDI"].ToString();
                        
                        lista.Add(tasaCero);
                    }
                    boolProcess = true;
                }
            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }

        public int cons_NegocioTodos()
        {
            int IdNegocio = 0;
            DataTable dt = new DataTable();
            
            try
            {
                if (bd.ExecuteProcedure(conexionBD, "cons_NegocioTodos", out dt, 120))               
                    IdNegocio = Convert.ToInt32(dt.Rows[0]["Id"]);                
            }
            catch (Exception ex)
            {                
            }
            return IdNegocio;
        }

        public string cons_PeriodoNombre(string idPeriodoNegocio)
        {
            string periodo = String.Empty;
            DataTable dt = new DataTable();
            SqlParameter[] @params = new SqlParameter[1];
            @params[0] = new SqlParameter("@IdPeriodoNegocio", idPeriodoNegocio);
            try
            {
                if (bd.ExecuteProcedure(conexionBD, "cons_PeriodoNombre",@params,out dt, 120))
                    periodo = dt.Rows[0]["periodo"].ToString();
            }
            catch (Exception ex)
            {
            }
            return periodo;
        }

        public int cons_EstatusClave(string Clave)
        {
            SqlParameter[] @params = new SqlParameter[1];
            @params[0] = new SqlParameter("@Clave", Clave);
            int IdEstatus = 0;    
            DataTable dt = new DataTable();

            try
            {
                if (bd.ExecuteProcedure(conexionBD, "cons_EstatusClave",@params, out dt, 120))
                    IdEstatus = Convert.ToInt32(dt.Rows[0]["Id"]);
            }
            catch (Exception ex)
            {
                
            }
            return IdEstatus;
        }

        public string cons_Destinatarios(int IdUsuario,int IdNegocio, string Clave)
        {            
            string destinatarios = String.Empty;
            DataTable dt = new DataTable();

            SqlParameter[] @params = new SqlParameter[3];
            @params[0] = new SqlParameter("@IdUsuario", IdUsuario);
            @params[1] = new SqlParameter("@Clave", Clave);
            @params[2] = new SqlParameter("@IdNegocio", IdNegocio);

            try
            {
                if (bd.ExecuteProcedure(conexionBD, "cons_Destinatarios",@params, out dt, 120))
                    destinatarios = dt.Rows[0]["destinatarios"].ToString();
            }
            catch (Exception ex)
            { }

            return destinatarios;
        }

        public Boolean ins_DataStage(int IdUsuario,string IdNegocio, string fileName, DataTable datastage, out String msgError)
        {
            bool boolProcess = true;
            msgError = string.Empty;
            DataTable dt = new DataTable();

            SqlParameter[] @params = new SqlParameter[4];
            @params[0] = new SqlParameter("@IdUsuario", IdUsuario);
            @params[1] = new SqlParameter("@tableDataStage", datastage);
            @params[2] = new SqlParameter("@fileName", fileName);
            @params[3] = new SqlParameter("@IdNegocio", IdNegocio);
            try
            {
                if (!bd.ExecuteProcedure(conexionBD, "ins_T_DataStage", @params, out dt, 120))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    if (Convert.ToInt32(dt.Rows[0]["ErrorNumber"]) == 1)
                    {
                        boolProcess = false;
                        msgError= dt.Rows[0]["ErrorMessage"].ToString();
                    }
                    else
                        boolProcess = true;
                }
            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }

        public Boolean cons_incidencias(int observa, string ?IdNegocio, string ?IdPeriodoNegocio,int IdUsuario, string ?periodo,out List<Incidencia> lista, out String msgError)
        {
            bool boolProcess = true;
            msgError = string.Empty;
            DataTable dt = new DataTable();
            lista = new List<Incidencia>();
            SqlParameter[] @params = new SqlParameter[5];
            @params[0] = new SqlParameter("@IdNegocio", IdNegocio);
            @params[1] = new SqlParameter("@IdPeriodoNegocio", IdPeriodoNegocio);
            @params[2] = new SqlParameter("@IdUsuario", IdUsuario);
            @params[3] = new SqlParameter("@periodo", periodo);
            @params[4] = new SqlParameter("@observa", observa);

            try
            {
                if (!bd.ExecuteProcedure(conexionBD, "cons_incidencias", @params,  out dt, 120))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    for (int r = 0; r < dt.Rows.Count; r++)
                    {
                        Incidencia ins = new Incidencia();
                        ins.Id = Convert.ToInt32(dt.Rows[r]["Id"]);
                        ins.NumeroFactura = dt.Rows[r]["NumeroFactura"].ToString();
                        ins.FechaFacturacion = dt.Rows[r]["FechaFacturacion"].ToString();
                        ins.Pedimento = dt.Rows[r]["Pedimento"].ToString();
                        ins.Estatus = dt.Rows[r]["Estatus"].ToString();
                        ins.Proveedor = dt.Rows[r]["Proveedor"].ToString();
                        ins.Total = string.Format((IFormatProvider)CultureInfo.InvariantCulture,"$" + "{0:#,#.00}", Convert.ToDouble(dt.Rows[r]["Total"]))
                            + " " +  dt.Rows[r]["Moneda"].ToString();
                        ins.EstatusPeriodoNegocio = dt.Rows[r]["EstatusPeriodoNegocio"].ToString();
                        //ins.Total = string.Format("{0:C}", Convert.ToDouble(dt.Rows[r]["Total"])) + " " +
                        //        dt.Rows[r]["Moneda"].ToString();


                        lista.Add(ins);
                    }
                    boolProcess = true;
                }
            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }
        
        public Boolean cons_observaciones_by_id(int IdIncidencia, out List<Observaciones> lista, out String msgError)
        {
            bool boolProcess = true;
            msgError = string.Empty;
            DataTable dt = new DataTable();
            lista = new List<Observaciones>();

            SqlParameter[] @params = new SqlParameter[1];
            @params[0] = new SqlParameter("@IdIncidencia", IdIncidencia);

            try
            {

                if (!bd.ExecuteProcedure(conexionBD, "cons_Observaciones", @params, out dt, 120))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    for (int r = 0; r < dt.Rows.Count; r++)
                    {
                        Observaciones obs = new Observaciones();
                        obs.Id = Convert.ToInt32(dt.Rows[r]["Id"]);
                        obs.IdIncidencia = Convert.ToInt32(dt.Rows[r]["IdIncidencia"]);
                        obs.Descripcion = dt.Rows[r]["Descripcion"].ToString();
                        obs.FechaCreacion = dt.Rows[r]["FechaCreacion"].ToString();
                        obs.IdUsuario = Convert.ToInt32(dt.Rows[r]["IdUsuario"]);

                        lista.Add(obs);
                    }
                    boolProcess = true;
                }
            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }

        public Boolean cons_dashboard(int IdEstatus, string IdNegocio,int iYear, out List<cDashboard> lista, out String msgError)
        {
            bool boolProcess = true;
            msgError = string.Empty;
            DataTable dt = new DataTable();
            lista = new List<cDashboard>();

            SqlParameter[] @params = new SqlParameter[3];
            @params[0] = new SqlParameter("@IdEstatus", IdEstatus);
            @params[1] = new SqlParameter("@IdNegocio", IdNegocio);
            @params[2] = new SqlParameter("@iYear", iYear);

            try
            {
                if (!bd.ExecuteProcedure(conexionBD, "cons_dashboard", @params, out dt, 120))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    for (int r = 0; r < dt.Rows.Count; r++)
                    {
                        cDashboard dh = new cDashboard();
                        dh.DocumentosTotales = Convert.ToInt32(dt.Rows[r]["DocumentosTotales"]);
                        dh.Incidencias = Convert.ToInt32(dt.Rows[r]["Incidencias"]);
                        dh.FechaCreacion = dt.Rows[r]["FechaCreacion"].ToString();
                        dh.FechaUltimaActualizacion = dt.Rows[r]["FechaUltimaActualizacion"].ToString();
                        dh.Negocio = dt.Rows[r]["Negocio"].ToString();
                        dh.Clave = dt.Rows[r]["Clave"].ToString();
                        dh.Estatus = dt.Rows[r]["Estatus"].ToString();
                        dh.Periodo = dt.Rows[r]["Periodo"].ToString();
                        dh.IdPeriodo = Convert.ToInt32(dt.Rows[r]["IdPeriodo"]);
                        dh.IdPeriodoNegocio = Convert.ToInt32(dt.Rows[r]["IdPeriodoNegocio"]);
                        dh.IdNegocio = Convert.ToInt32(dt.Rows[r]["IdNegocio"]);
                        dh.Activas = Convert.ToInt32(dt.Rows[r]["Activas"]);

                        lista.Add(dh);
                    }
                    boolProcess = true;
                }
            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }

        public Boolean cons_Estatus(out List<cEstatus> lista, out String msgError)
        {
            bool boolProcess = true;
            msgError = string.Empty;
            DataTable dt = new DataTable();
            lista = new List<cEstatus>();

            SqlParameter[] @params = new SqlParameter[1];
       
            try
            {

                if (!bd.ExecuteProcedure(conexionBD, "cons_Estatus", out dt, 120))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    for (int r = 0; r < dt.Rows.Count; r++)
                    {
                        cEstatus st = new cEstatus();
                        st.Id = Convert.ToInt32(dt.Rows[r]["Id"]);
                        st.Descripcion = dt.Rows[r]["Descripcion"].ToString();
                        st.Activo = Convert.ToInt32(dt.Rows[r]["Activo"]);

                        lista.Add(st);
                    }
                    boolProcess = true;
                }
            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }

        public Boolean cons_Documentos(string IdNegocio, string periodo, out List<Documento> lista, out String msgError)
        {
            bool boolProcess = true;
            msgError = string.Empty;
            DataTable dt = new DataTable();
            lista = new List<Documento>();

            SqlParameter[] @params = new SqlParameter[2];
            @params[0] = new SqlParameter("@periodo", periodo);
            @params[1] = new SqlParameter("@IdNegocio", IdNegocio);

            try
            {

                if (!bd.ExecuteProcedure(conexionBD, "cons_Documentos", @params,out dt, 120))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    for (int r = 0; r < dt.Rows.Count; r++)
                    {
                        Documento doc = new Documento();
                        doc.Id = Convert.ToInt32(dt.Rows[r]["Id"]);
                        doc.Archivo = dt.Rows[r]["Archivo"].ToString();
                        
                        doc.IdNegocio = Convert.ToInt32(dt.Rows[r]["IdNegocio"]);
                        doc.Negocio = dt.Rows[r]["Negocio"].ToString();

                        doc.IdUsuario = Convert.ToInt32(dt.Rows[r]["IdUsuario"]);
                        doc.Nombre = dt.Rows[r]["Nombre"].ToString();
                        doc.Correo = dt.Rows[r]["Correo"].ToString();
                        doc.FechaAlta = Convert.ToDateTime(dt.Rows[r]["FechaAlta"]).ToString("yyyy-MM-dd");


                        lista.Add(doc);
                    }
                    boolProcess = true;
                }
            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }
  
        public Boolean cons_Years(string IdNegocio, int IdEstatus, out List<Years> lista, out String msgError)
        {
            bool boolProcess = true;
            msgError = string.Empty;
            DataTable dt = new DataTable();
            lista = new List<Years>();

            SqlParameter[] @params = new SqlParameter[2];
            @params[0] = new SqlParameter("@IdEstatus", IdEstatus);
            @params[1] = new SqlParameter("@IdNegocio", IdNegocio);

            try
            {
                if (!bd.ExecuteProcedure(conexionBD, "cons_Years", @params,out dt, 120))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    for (int r = 0; r < dt.Rows.Count; r++)
                    {
                        Years Anio = new Years();
                        Anio.Year = Convert.ToInt32(dt.Rows[r]["year"]);
                        lista.Add(Anio);
                    }
                    boolProcess = true;
                }
            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }
  
        public Boolean cons_XML(int idTasaCero, string UUID, out XML xml, out String msgError)
        {
            bool boolProcess = true;
            msgError = string.Empty;
            DataTable dt = new DataTable();
            xml = new XML();
            SqlParameter[] @params = new SqlParameter[2];
            @params[0] = new SqlParameter("@idTasaCero", idTasaCero);
            @params[1] = new SqlParameter("@UUID", UUID);
            try
            {
                if (!bd.ExecuteProcedure(conexionBD, "cons_XML", @params, out dt, 120))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    xml = new XML();
                    xml.Id = Convert.ToInt32(dt.Rows[0]["Id"]);
                    xml.UUID = dt.Rows[0]["UUID"].ToString();
                    xml.Pedimento = dt.Rows[0]["Pedimento"].ToString();
                    xml.Xml_doc = dt.Rows[0]["XML"].ToString();

                }
                boolProcess = true;
            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }
            
        public Boolean InsertarObservacion(int idIncidencia, string Observacion, int idUsuario, out DataTable dt, out String msgError)
        {
            bool boolProcess = true;
            dt = new DataTable();
            msgError = string.Empty;
            int i = 0;
            SqlParameter[] @params = new SqlParameter[3];
            @params[i] = new SqlParameter("@idIncidencia", idIncidencia);
            i++;
            @params[i] = new SqlParameter("@Observacion", Observacion);
            i++;
            @params[i] = new SqlParameter("@idUsuario", idUsuario);

            try
            {

                if (!bd.ExecuteProcedure(conexionBD, "ins_Observacion", @params, out dt, 120))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }
        
        public Boolean upd_EstatusPeriodoNegocio(int? IdPeriodo, int IdNegocio, string Clave, out String msgError)
        {
            bool boolProcess = true;
            msgError = string.Empty;
            DataTable dt = new DataTable();

            SqlParameter[] @params = new SqlParameter[3];
            @params[0] = new SqlParameter("@IdPeriodo", IdPeriodo);
            @params[1] = new SqlParameter("@IdNegocio", IdNegocio);
            @params[2] = new SqlParameter("@Clave", Clave);

            try
            {
                if (!bd.ExecuteProcedure(conexionBD, "upd_EstatusPeriodoNegocio", @params, out dt, 120))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
                else
                {
                    boolProcess = true;
                }
            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }

        public Boolean ins_ObsPeriodo(int IdPeriodoNegocio, string s_observacion, out String msgError)
        {
            bool boolProcess = true;
            DataTable dt = new DataTable();
            msgError = string.Empty;
            int i = 0;
            SqlParameter[] @params = new SqlParameter[2];
            @params[i] = new SqlParameter("@IdPeriodoNegocio", IdPeriodoNegocio);
            i++;
            @params[i] = new SqlParameter("@s_observacion", s_observacion);

            try
            {
                if (!bd.ExecuteProcedure(conexionBD, "ins_ObsPeriodo", @params, out dt, 120))
                {
                    boolProcess = false;
                    msgError = bd._error.ToString();
                }
            }
            catch (Exception ex)
            {
                boolProcess = false;
                msgError = ex.ToString();
            }
            return boolProcess;
        }

        public bool cons_ObsPeriodo(int IdPeriodoNegocio, out DataTable dt,out String msgError)
        {
           bool booleanProcess = true;
            msgError = string.Empty;
            dt = new DataTable();
            string s_observacion = String.Empty;
           

            SqlParameter[] @params = new SqlParameter[1];
            @params[0] = new SqlParameter("@idPeriodoNegocio", IdPeriodoNegocio);

            try
            {
                if (!bd.ExecuteProcedure(conexionBD, "cons_ObsPeriodo", @params, out dt, 120))
                {
                    msgError = bd._error.ToString();
                    booleanProcess = true;
                }
                else
                    booleanProcess = true;
         
            }
            catch (Exception ex)
            {

                msgError = ex.ToString();
            }
            return booleanProcess;
        }
    }
}