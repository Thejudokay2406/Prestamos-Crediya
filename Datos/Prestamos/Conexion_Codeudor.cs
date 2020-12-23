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
    public class Conexion_Codeudor
    {
        public DataTable Buscar(string Filtro, int Auto)
        {
            SqlDataReader Resultado;
            DataTable Tabla = new DataTable();
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion_SQLServer.getInstancia().Conexion();
                SqlCommand Comando = new SqlCommand("Consulta.Codeudor", SqlCon);
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
        public string Guardar_DatosBasicos(Entidad_Codeudor Obj)
        {
            string Rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion_SQLServer.getInstancia().Conexion();
                SqlCommand Comando = new SqlCommand("Prestamos.AJ_Codeudor", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;

                //Datos Auxiliares
                Comando.Parameters.Add("@Auto", SqlDbType.Int).Value = Obj.Auto;

                //Datos Basicos
                Comando.Parameters.Add("@Solicitante", SqlDbType.VarChar).Value = Obj.Codeudor;
                Comando.Parameters.Add("@Identificacion", SqlDbType.VarChar).Value = Obj.Identificacion;
                Comando.Parameters.Add("@Direccion", SqlDbType.VarChar).Value = Obj.Direccion;
                Comando.Parameters.Add("@Fijo", SqlDbType.VarChar).Value = Obj.Fijo;
                Comando.Parameters.Add("@Movil", SqlDbType.VarChar).Value = Obj.Movil;
                Comando.Parameters.Add("@Empresa", SqlDbType.VarChar).Value = Obj.Empresa;
                Comando.Parameters.Add("@Cargo", SqlDbType.VarChar).Value = Obj.Cargo;
                Comando.Parameters.Add("@Direccion_E", SqlDbType.VarChar).Value = Obj.Direccion_E;
                Comando.Parameters.Add("@Fijo_E", SqlDbType.VarChar).Value = Obj.Fijo_E;
                Comando.Parameters.Add("@Salario", SqlDbType.VarChar).Value = Obj.Salario;
                Comando.Parameters.Add("@Otros", SqlDbType.VarChar).Value = Obj.Otros;
                Comando.Parameters.Add("@Referencia", SqlDbType.VarChar).Value = Obj.Referencia;
                Comando.Parameters.Add("@Parentesco", SqlDbType.VarChar).Value = Obj.Parentesco;
                Comando.Parameters.Add("@Direccion_R", SqlDbType.VarChar).Value = Obj.Direccion_R;
                Comando.Parameters.Add("@Fijo_R", SqlDbType.VarChar).Value = Obj.Fijo_R;
                Comando.Parameters.Add("@Movil_R", SqlDbType.VarChar).Value = Obj.Movil_R;

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
        public string Editar_DatosBasicos(Entidad_Codeudor Obj)
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
                Comando.Parameters.Add("@Idcodeudor", SqlDbType.Int).Value = Obj.Idcodeudor;

                //Datos Basicos
                Comando.Parameters.Add("@Solicitante", SqlDbType.VarChar).Value = Obj.Codeudor;
                Comando.Parameters.Add("@Identificacion", SqlDbType.VarChar).Value = Obj.Identificacion;
                Comando.Parameters.Add("@Direccion", SqlDbType.VarChar).Value = Obj.Direccion;
                Comando.Parameters.Add("@Fijo", SqlDbType.VarChar).Value = Obj.Fijo;
                Comando.Parameters.Add("@Movil", SqlDbType.VarChar).Value = Obj.Movil;
                Comando.Parameters.Add("@Empresa", SqlDbType.VarChar).Value = Obj.Empresa;
                Comando.Parameters.Add("@Cargo", SqlDbType.VarChar).Value = Obj.Cargo;
                Comando.Parameters.Add("@Direccion_E", SqlDbType.VarChar).Value = Obj.Direccion_E;
                Comando.Parameters.Add("@Fijo_E", SqlDbType.VarChar).Value = Obj.Fijo_E;
                Comando.Parameters.Add("@Salario", SqlDbType.VarChar).Value = Obj.Salario;
                Comando.Parameters.Add("@Otros", SqlDbType.VarChar).Value = Obj.Otros;
                Comando.Parameters.Add("@Referencia", SqlDbType.VarChar).Value = Obj.Referencia;
                Comando.Parameters.Add("@Parentesco", SqlDbType.VarChar).Value = Obj.Parentesco;
                Comando.Parameters.Add("@Direccion_R", SqlDbType.VarChar).Value = Obj.Direccion_R;
                Comando.Parameters.Add("@Fijo_R", SqlDbType.VarChar).Value = Obj.Fijo_R;
                Comando.Parameters.Add("@Movil_R", SqlDbType.VarChar).Value = Obj.Movil_R;

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

        //Metodo Eliminar
        public string Eliminar(int IDEliminar_Sql, int auto)
        {
            string Rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion_SQLServer.getInstancia().Conexion();
                SqlCommand Comando = new SqlCommand("Consulta.Codeudor", SqlCon);
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

        public string Eliminar_Codeudor(int IDEliminar_Sql, int auto)
        {
            string Rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion_SQLServer.getInstancia().Conexion();
                SqlCommand Comando = new SqlCommand("Consulta.Codeudor", SqlCon);
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
    }
}
