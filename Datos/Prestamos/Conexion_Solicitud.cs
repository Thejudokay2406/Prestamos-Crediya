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
    public class Conexion_Solicitud
    {
        //Metodo Insertar

        public string Guardar_DatosBasicos(Entidad_Solicitud Obj)
        {
            string Rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion_SQLServer.getInstancia().Conexion();
                SqlCommand Comando = new SqlCommand("Prestamos.AJ_DatosBasicos", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;

                //Datos Auxiliares
                Comando.Parameters.Add("@Auto", SqlDbType.Int).Value = Obj.Auto;

                Comando.Parameters.Add("@Codeudor_AutoSQL", SqlDbType.Int).Value = Obj.Codeudor_AutoSQL;
                
                //Variables Para Ejecutar Si o No Las Transacciones
                Comando.Parameters.Add("@Tran_Codeudor", SqlDbType.Int).Value = Obj.Tran_Codeudor;
                
                //Datos Basicos
                Comando.Parameters.Add("@Orden", SqlDbType.VarChar).Value = Obj.Orden;
                Comando.Parameters.Add("@Solicitante", SqlDbType.VarChar).Value = Obj.Solicitante;
                Comando.Parameters.Add("@Identificacion", SqlDbType.VarChar).Value = Obj.Identificacion;
                Comando.Parameters.Add("@Valor", SqlDbType.VarChar).Value = Obj.Valor;
                Comando.Parameters.Add("@Solicitud", SqlDbType.Date).Value = Obj.Solicitud;
                Comando.Parameters.Add("@Prestamos", SqlDbType.Date).Value = Obj.Prestamos;
                Comando.Parameters.Add("@Modalidad", SqlDbType.VarChar).Value = Obj.Modalidad;
                Comando.Parameters.Add("@Direccion", SqlDbType.VarChar).Value = Obj.Direccion;
                Comando.Parameters.Add("@Fijo", SqlDbType.VarChar).Value = Obj.Fijo;
                Comando.Parameters.Add("@Movil", SqlDbType.VarChar).Value = Obj.Movil;
                Comando.Parameters.Add("@Empresa", SqlDbType.VarChar).Value = Obj.Empresa;
                Comando.Parameters.Add("@Cargo", SqlDbType.VarChar).Value = Obj.Cargo;
                Comando.Parameters.Add("@Direccion_E", SqlDbType.VarChar).Value = Obj.Direccion_E;
                Comando.Parameters.Add("@Fijo_E", SqlDbType.VarChar).Value = Obj.Fijo_E;
                Comando.Parameters.Add("@Movil_E", SqlDbType.VarChar).Value = Obj.Movil_E;
                Comando.Parameters.Add("@Salario", SqlDbType.VarChar).Value = Obj.Salario;
                Comando.Parameters.Add("@Otros", SqlDbType.VarChar).Value = Obj.Otros;
                Comando.Parameters.Add("@Referencia", SqlDbType.VarChar).Value = Obj.Referencia;
                Comando.Parameters.Add("@Parentesco", SqlDbType.VarChar).Value = Obj.Parentesco;
                Comando.Parameters.Add("@Direccion_R", SqlDbType.VarChar).Value = Obj.Direccion_R;
                Comando.Parameters.Add("@Fijo_R", SqlDbType.VarChar).Value = Obj.Fijo_R;
                Comando.Parameters.Add("@Movil_R", SqlDbType.VarChar).Value = Obj.Movil_R;
                Comando.Parameters.Add("@Observacion", SqlDbType.VarChar).Value = Obj.Observacion;

                //Panel Codeudor -- Campos Obligatorios
                Comando.Parameters.Add("@Det_Codeudor", SqlDbType.Structured).Value = Obj.Detalle_Codeudor;

                //Panel Imagenes -- Campos NO Obligatorios
                Comando.Parameters.Add("@FotoSolicitud", SqlDbType.Image).Value = Obj.Foto_Solicitud;
                Comando.Parameters.Add("@Pagare", SqlDbType.Image).Value = Obj.Pagare;
                Comando.Parameters.Add("@Codeudor", SqlDbType.Image).Value = Obj.Codeudor;
                Comando.Parameters.Add("@Deudor", SqlDbType.Image).Value = Obj.Deudor;
                Comando.Parameters.Add("@OtrosDoc", SqlDbType.Image).Value = Obj.OtrosDocumentos;
                Comando.Parameters.Add("@OtrosDoc02", SqlDbType.Image).Value = Obj.OtrosDocumentos02;

                //ejecutamos el envio de datos
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

        public string Editar_DatosBasicos(Entidad_Solicitud Obj)
        {
            string Rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion_SQLServer.getInstancia().Conexion();
                SqlCommand Comando = new SqlCommand("Solicitud.LI_DatosBasicos", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;

                //Datos Auxiliares
                Comando.Parameters.Add("@Auto", SqlDbType.Int).Value = Obj.Auto;
                Comando.Parameters.Add("@Idsolicitud", SqlDbType.Int).Value = Obj.Idsolicitud;

                //Datos Basicos
                Comando.Parameters.Add("@Solicitante", SqlDbType.VarChar).Value = Obj.Solicitante;
                Comando.Parameters.Add("@Identificacion", SqlDbType.VarChar).Value = Obj.Identificacion;
                Comando.Parameters.Add("@Valor", SqlDbType.VarChar).Value = Obj.Valor;
                Comando.Parameters.Add("@Solicitud", SqlDbType.Date).Value = Obj.Solicitud;
                Comando.Parameters.Add("@Prestamos", SqlDbType.VarChar).Value = Obj.Prestamos;
                Comando.Parameters.Add("@Modalidad", SqlDbType.VarChar).Value = Obj.Modalidad;
                Comando.Parameters.Add("@Direccion", SqlDbType.VarChar).Value = Obj.Direccion;
                Comando.Parameters.Add("@Fijo", SqlDbType.VarChar).Value = Obj.Fijo;
                Comando.Parameters.Add("@Movil", SqlDbType.VarChar).Value = Obj.Movil;
                Comando.Parameters.Add("@Empresa", SqlDbType.VarChar).Value = Obj.Empresa;
                Comando.Parameters.Add("@Cargo", SqlDbType.VarChar).Value = Obj.Cargo;
                Comando.Parameters.Add("@Direccion_E", SqlDbType.VarChar).Value = Obj.Direccion_E;
                Comando.Parameters.Add("@Fijo_E", SqlDbType.VarChar).Value = Obj.Fijo_E;
                Comando.Parameters.Add("@Movil_E", SqlDbType.VarChar).Value = Obj.Movil_E;
                Comando.Parameters.Add("@Salario", SqlDbType.VarChar).Value = Obj.Salario;
                Comando.Parameters.Add("@Otros", SqlDbType.VarChar).Value = Obj.Otros;
                Comando.Parameters.Add("@Referencia", SqlDbType.VarChar).Value = Obj.Referencia;
                Comando.Parameters.Add("@Parentesco", SqlDbType.VarChar).Value = Obj.Parentesco;
                Comando.Parameters.Add("@Direccion_R", SqlDbType.VarChar).Value = Obj.Direccion_R;
                Comando.Parameters.Add("@Fijo_R", SqlDbType.VarChar).Value = Obj.Fijo_R;
                Comando.Parameters.Add("@Movil_R", SqlDbType.VarChar).Value = Obj.Movil_R;
                Comando.Parameters.Add("@Observacion", SqlDbType.VarChar).Value = Obj.Observacion;

                //ejecutamos el envio de datos
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

        public DataTable Lista()
        {
            SqlDataReader Resultado;
            DataTable Tabla = new DataTable();
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion_SQLServer.getInstancia().Conexion();
                SqlCommand Comando = new SqlCommand("Consulta.CB_Codeudor", SqlCon);
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

        public DataTable Buscar(int Auto, string Filtro)
        {
            SqlDataReader Resultado;
            DataTable Tabla = new DataTable();
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion_SQLServer.getInstancia().Conexion();
                SqlCommand Comando = new SqlCommand("Consulta.Credito", SqlCon);
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

        public DataTable Consulta_SolicitudSQL(string Filtro)
        {
            SqlDataReader Resultado;
            DataTable Tabla = new DataTable();
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion_SQLServer.getInstancia().Conexion();
                SqlCommand Comando = new SqlCommand("Consulta.Solicitud_SQL", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;

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

        public DataTable CodigoID_Solicitud(string Valor)
        {
            SqlDataReader Resultado;
            DataTable Tabla = new DataTable();
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion_SQLServer.getInstancia().Conexion();
                SqlCommand Comando = new SqlCommand("Sistema.CodigoID_Solicitud", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;

                //
                Comando.Parameters.Add("@Filtro", SqlDbType.VarChar).Value = Valor;

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
                SqlCommand Comando = new SqlCommand("Consulta.Solicitud", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;

                //Panel Datos Basicos
                Comando.Parameters.Add("@Eliminar", SqlDbType.Int).Value = auto;
                Comando.Parameters.Add("@Idsolicitud", SqlDbType.Int).Value = IDEliminar_Sql;

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
