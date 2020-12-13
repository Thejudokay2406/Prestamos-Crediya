using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Entidad;
using System.Data;
using System.Data.SqlClient;

namespace Datos
{
    public class Conexion_Consignacion
    {
        public DataTable Lista()
        {
            SqlDataReader Resultado;
            DataTable Tabla = new DataTable();
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion_SQLServer.getInstancia().Conexion();
                SqlCommand Comando = new SqlCommand("Consulta.Consignacion", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;
                SqlCon.Open();
                Resultado = Comando.ExecuteReader();
                Tabla.Load(Resultado);
                return Tabla;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open)
                {
                    SqlCon.Close();
                }
            }
        }

        public DataTable Lista_Consignacion(int Auto, int idsolicitud)
        {
            SqlDataReader Resultado;
            DataTable Tabla = new DataTable();
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion_SQLServer.getInstancia().Conexion();
                SqlCommand Comando = new SqlCommand("Consulta.Consignacion", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;

                Comando.Parameters.Add("@Filtro_Consignacion", SqlDbType.Int).Value = Auto;
                Comando.Parameters.Add("@Idsolicitud", SqlDbType.Int).Value = idsolicitud;

                SqlCon.Open();
                Resultado = Comando.ExecuteReader();
                Tabla.Load(Resultado);
                return Tabla;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open)
                {
                    SqlCon.Close();
                }
            }
        }

        public string Guardar_DatosBasicos(Entidad_Consignaciones Obj)
        {
            string Rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion_SQLServer.getInstancia().Conexion();
                SqlCommand Comando = new SqlCommand("Prestamos.AJ_Consignacion", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;

                //Datos Auxiliares
                Comando.Parameters.Add("@Auto", SqlDbType.Int).Value = Obj.Auto;

                //Datos Basicos
                Comando.Parameters.Add("@Idsolicitud", SqlDbType.Int).Value = Obj.OrdenDeSolicitud;
                Comando.Parameters.Add("@Deudor", SqlDbType.VarChar).Value = Obj.Nombre;
                Comando.Parameters.Add("@Identificacion", SqlDbType.BigInt).Value = Obj.Identificacion;
                Comando.Parameters.Add("@Valor", SqlDbType.BigInt).Value = Obj.Valor_Prestamo;
                Comando.Parameters.Add("@Abono", SqlDbType.BigInt).Value = Obj.Valor_Abono;
                Comando.Parameters.Add("@Fecha", SqlDbType.DateTime).Value = Obj.Fecha;
                Comando.Parameters.Add("@Observacion", SqlDbType.VarChar).Value = Obj.Observacion;
                
                SqlCon.Open();
                Rpta = Comando.ExecuteNonQuery() != 1 ? "OK" : "Error al Realizar el Registro";
            }
            catch (Exception ex)
            {
                Rpta = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open)
                {
                    SqlCon.Close();
                }
            }
            return Rpta;
        }


        public string Guardar_Consignacion(Entidad_Consignaciones Obj)
        {
            string Rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion_SQLServer.getInstancia().Conexion();
                SqlCommand Comando = new SqlCommand("Prestamos.AJ_Consignacion", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;

                //Datos Auxiliares
                Comando.Parameters.Add("@Auto_Consignacion", SqlDbType.Int).Value = Obj.Auto;

                //Datos Basicos
                Comando.Parameters.Add("@Idsolicitud", SqlDbType.Int).Value = Obj.OrdenDeSolicitud;
                Comando.Parameters.Add("@Deudor", SqlDbType.VarChar).Value = Obj.Nombre;
                Comando.Parameters.Add("@Identificacion", SqlDbType.BigInt).Value = Obj.Identificacion;
                Comando.Parameters.Add("@Valor", SqlDbType.BigInt).Value = Obj.Valor_Prestamo;
                Comando.Parameters.Add("@Abono", SqlDbType.BigInt).Value = Obj.Valor_Abono;
                Comando.Parameters.Add("@Fecha", SqlDbType.DateTime).Value = Obj.Fecha;
                Comando.Parameters.Add("@Observacion", SqlDbType.VarChar).Value = Obj.Observacion;

                SqlCon.Open();
                Rpta = Comando.ExecuteNonQuery() != 1 ? "OK" : "Error al Realizar el Registro";
            }
            catch (Exception ex)
            {
                Rpta = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open)
                {
                    SqlCon.Close();
                }
            }
            return Rpta;
        }

        //Metodo Editar
        public string Editar_DatosBasicos(Entidad_Consignaciones Obj)
        {
            string Rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion_SQLServer.getInstancia().Conexion();
                SqlCommand Comando = new SqlCommand("Codeudor.LI_Codeudor", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;

                //Datos Auxiliares
                Comando.Parameters.Add("@Auto", SqlDbType.Int).Value = Obj.Auto;
                Comando.Parameters.Add("@Idconsignacion", SqlDbType.Int).Value = Obj.Idconsignacion;

                //Datos Basicos
                //Datos Basicos
                Comando.Parameters.Add("@Idsolicitud", SqlDbType.Int).Value = Obj.OrdenDeSolicitud;
                Comando.Parameters.Add("@Deudor", SqlDbType.VarChar).Value = Obj.Nombre;
                Comando.Parameters.Add("@Identificacion", SqlDbType.BigInt).Value = Obj.Identificacion;
                Comando.Parameters.Add("@Valor", SqlDbType.BigInt).Value = Obj.Valor_Prestamo;
                Comando.Parameters.Add("@Abono", SqlDbType.BigInt).Value = Obj.Valor_Abono;
                Comando.Parameters.Add("@Fecha", SqlDbType.DateTime).Value = Obj.Fecha;
                Comando.Parameters.Add("@Observacion", SqlDbType.VarChar).Value = Obj.Observacion;

                SqlCon.Open();
                Rpta = Comando.ExecuteNonQuery() != 1 ? "OK" : "Error al Realizar el Registro";
            }
            catch (Exception ex)
            {
                Rpta = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open)
                {
                    SqlCon.Close();
                }
            }
            return Rpta;
        }

        public DataTable Buscar(string Filtro, int Auto)
        {
            SqlDataReader Resultado;
            DataTable Tabla = new DataTable();
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion_SQLServer.getInstancia().Conexion();
                SqlCommand Comando = new SqlCommand("Consulta.Consignacion", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;

                Comando.Parameters.Add("@Auto", SqlDbType.Int).Value = Auto;
                Comando.Parameters.Add("@Filtro", SqlDbType.VarChar).Value = Filtro;

                SqlCon.Open();
                Resultado = Comando.ExecuteReader();
                Tabla.Load(Resultado);
                return Tabla;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open)
                {
                    SqlCon.Close();
                }
            }
        }

        //Metodo Eliminar

        public string Eliminar(int IDEliminar_Sql, int auto)
        {
            string Rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion_SQLServer.getInstancia().Conexion();
                SqlCommand Comando = new SqlCommand("Consulta.Consignacion", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;

                //Panel Datos Basicos
                Comando.Parameters.Add("@Eliminar", SqlDbType.Int).Value = auto;
                Comando.Parameters.Add("@Idcodeudor", SqlDbType.Int).Value = IDEliminar_Sql;

                SqlCon.Open();
                Rpta = Comando.ExecuteNonQuery() == 1 ? "OK" : "Error al Eliminar el Registro";
            }
            catch (Exception ex)
            {
                Rpta = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open)
                {
                    SqlCon.Close();
                }
            }
            return Rpta;
        }

        public string Eliminar_Abono(int Idconsignacion, int auto)
        {
            string Rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion_SQLServer.getInstancia().Conexion();
                SqlCommand Comando = new SqlCommand("Consulta.Consignacion", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;

                //Panel Datos Basicos
                Comando.Parameters.Add("@Eliminar", SqlDbType.Int).Value = auto;
                Comando.Parameters.Add("@Idconsignacion", SqlDbType.Int).Value = Idconsignacion;

                SqlCon.Open();
                Rpta = Comando.ExecuteNonQuery() == 1 ? "OK" : "Error al Eliminar el Registro";
            }
            catch (Exception ex)
            {
                Rpta = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open)
                {
                    SqlCon.Close();
                }
            }
            return Rpta;
        }
    }
}
