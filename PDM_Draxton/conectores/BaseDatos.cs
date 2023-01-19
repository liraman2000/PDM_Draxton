using PDM_Draxton.utilidades;
using System.Data;
using System.Data.SqlClient;

namespace PDM_Draxton.conectores
{
    public class BaseDatos
    {

        public String _error = String.Empty;
        private Funciones fn = new Funciones();
        public BaseDatos()
        {


        }

        public Boolean ExecuteProcedure(String conexion, String store, SqlParameter[] parameters, out DataTable dt, int timeOut)
        {
            Boolean boolProcess = true;
            _error = String.Empty;
            dt = new DataTable();
            SqlConnection con = new SqlConnection(conexion);
            try
            {
                using (SqlCommand cmd = new SqlCommand(store, con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = timeOut;
                    foreach (SqlParameter param in parameters)
                    {
                        if (param != null)
                        {
                            cmd.Parameters.Add(param);
                        }
                    }
                    con.Open();

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();

                    adapter.Fill(ds);

                    if (ds.Tables.Count > 0)
                    {
                        dt = ds.Tables[0];
                    }

                    try
                    {
                        con.Close();
                    }
                    catch (Exception)
                    {
                    }
                }
            }
            catch (Exception ex)
            {
                boolProcess = false;
                _error = ex.ToString();// string.Empty;// fn.limpiarString(ex.ToString());
                try
                {
                    con.Close();
                }
                catch (Exception)
                {
                }
            }

            return boolProcess;
        }

        public Boolean ExecuteProcedure(String conexion, String store, out DataTable dt, int timeOut)
        {
            Boolean boolProcess = true;
            _error = String.Empty;
            dt = new DataTable();
            SqlConnection con = new SqlConnection(conexion);
            try
            {
                using (SqlCommand cmd = new SqlCommand(store, con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = timeOut;
                    con.Open();

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);

                    if (ds.Tables.Count > 0)
                    {
                        dt = ds.Tables[0];
                    }

                    //cmd.ExecuteNonQuery();
                    try
                    {
                        con.Close();
                    }
                    catch (Exception)
                    {
                    }
                }
            }
            catch (Exception ex)
            {
                boolProcess = false;
                _error = String.Empty;// fn.limpiarString(ex.ToString());
                try
                {
                    con.Close();
                }
                catch (Exception)
                {

                }

            }

            return boolProcess;
        }

        public Boolean ExecuteProcedure(String conexion, String store, SqlParameter[] parameters, out DataSet ds, int timeOut)
        {
            Boolean boolProcess = true;
            _error = String.Empty;
            ds = new DataSet();
            SqlConnection con = new SqlConnection(conexion);
            try
            {
                using (SqlCommand cmd = new SqlCommand(store, con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = timeOut;

                    foreach (SqlParameter param in parameters)
                    {
                        if (param != null)
                        {
                            cmd.Parameters.Add(param);
                        }
                    }

                    con.Open();

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(ds);

                    try
                    {
                        con.Close();
                    }
                    catch (Exception)
                    {
                    }
                }
            }
            catch (Exception ex)
            {
                _error = ex.ToString();
                try
                {
                    con.Close();
                }
                catch (Exception)
                {
                }
                throw;
            }

            return boolProcess;
        }
    }
}