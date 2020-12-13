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
    public class Conexion_Usuarios
    {
        public Conexion_Usuarios()
        {

        }

        //public Conexion_Usuarios
        //    (

        //    int idtrabajador, string empleado, string identificacion, DateTime fecha, string usuario,
        //    string contraseña, string consultar, string editar, string eliminar, string guardar,

        //    string prestamos, string consulta, string reportes, string sistema,

        //    int auto, string filtro, int estado

        //    )
        //{
        //    this.Idtrabajador = idtrabajador;
        //    this.Empleado = empleado;
        //    this.Identificacion = identificacion;
        //    this.Fecha = fecha;
        //    this.Usuario = usuario;
        //    this.Contraseña = contraseña;
        //    this.Estado = estado;

        //    this.Prestamos = prestamos;
        //    this.Consulta = consulta;
        //    this.Reportes = reportes;
        //    this.Sistema = sistema;

        //    this.Consultar = consultar;
        //    this.Editar = editar;
        //    this.Eliminar = eliminar;
        //    this.Guardar = guardar;

        //    this.Auto = auto;
        //    this.Filtro = filtro;
        //}

        //Metodo Insertar

        public string Guardar_DatosBasicos(Entidad_Usuario Obj)
        {
            string Rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion_SQLServer.getInstancia().Conexion();
                SqlCommand Comando = new SqlCommand("Sistema.AJ_Usuarios", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;

                //Datos Auxiliares
                Comando.Parameters.Add("@Auto", SqlDbType.Int).Value = Obj.Auto;

                //Datos Basicos
                Comando.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = Obj.Empleado;
                Comando.Parameters.Add("@Identificacion", SqlDbType.VarChar).Value = Obj.Identificacion;
                Comando.Parameters.Add("@Fecha", SqlDbType.DateTime).Value = Obj.Fecha;
                Comando.Parameters.Add("@Usuario", SqlDbType.VarChar).Value = Obj.Usuario;
                Comando.Parameters.Add("@Contraseña", SqlDbType.VarChar).Value = Obj.Contraseña;
                Comando.Parameters.Add("@Descripcion", SqlDbType.VarChar).Value = Obj.Identificacion;

                //Permisos de Operacion

                Comando.Parameters.Add("@Consultar", SqlDbType.VarChar).Value = Obj.Identificacion;
                Comando.Parameters.Add("@Editar", SqlDbType.VarChar).Value = Obj.Identificacion;
                Comando.Parameters.Add("@Eliminar", SqlDbType.VarChar).Value = Obj.Identificacion;
                Comando.Parameters.Add("@Guardar", SqlDbType.VarChar).Value = Obj.Identificacion;

                //Niveles de Operacion
                Comando.Parameters.Add("@Prestamos", SqlDbType.VarChar).Value = Obj.Identificacion;
                Comando.Parameters.Add("@Consulta", SqlDbType.VarChar).Value = Obj.Identificacion;
                Comando.Parameters.Add("@Reportes", SqlDbType.VarChar).Value = Obj.Identificacion;
                Comando.Parameters.Add("@Sistema", SqlDbType.VarChar).Value = Obj.Identificacion;

                SqlCon.Open();
                Rpta = Comando.ExecuteNonQuery() == 1 ? "OK" : "Error al Realizar el Registro";
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

        public DataTable Login_SQL(string usuario, string contraseña)
        {
            SqlDataReader Resultado;
            DataTable Tabla = new DataTable();
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion_SQLServer.getInstancia().Conexion();
                SqlCommand Comando = new SqlCommand("Sistema.Login", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;

                Comando.Parameters.Add("@Usuario", SqlDbType.VarChar).Value = usuario;
                Comando.Parameters.Add("@Contraseña", SqlDbType.VarChar).Value = contraseña;

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
    }
}
