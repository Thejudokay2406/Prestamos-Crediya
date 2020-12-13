using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Datos;
using Entidad;
using System.Data;

namespace Negocio
{
    public class fUsuario
    {
        //public static string Guardar_DatosBasicos
        //    (

        //    //Datos Basicos
        //    string nombre, string identificacion, DateTime fecha, string usuario,
        //    string contraseña,string descripcion,

        //    //Niveles
        //    string prestamos, string consulta, string reportes, string sistema,

        //    //Permisos
        //    string guardar, string eliminar, string editar, string consultar,

        //    int auto, int estado

        //    )
        //{
        //    Conexion_Usuarios Obj = new Conexion_Usuarios();
        //    //Datos Basicos

        //    Obj.Empleado = nombre;
        //    Obj.Identificacion = identificacion;
        //    Obj.Fecha = fecha;
        //    Obj.Usuario = usuario;
        //    Obj.Contraseña = contraseña;

        //    Obj.Prestamos = prestamos;
        //    Obj.Consulta = consulta;
        //    Obj.Reportes = reportes;
        //    Obj.Sistema = sistema;

        //    Obj.Consultar = consultar;
        //    Obj.Editar = editar;
        //    Obj.Eliminar = eliminar;
        //    Obj.Guardar = guardar;

        //    Obj.Auto = auto;
        //    Obj.Estado = estado;

        //    return Obj.Guardar_DatosBasicos(Obj);
        //}

        ////public static DataTable Buscar_Usuario(string filtro)
        ////{
        ////    Conexion_Usuarios Obj = new Conexion_Usuarios();
        ////    Obj.Filtro = filtro;
        ////    return Obj.Buscar_Usuario(Obj);
        ////}

        public static DataTable Login_SQL(string usuario, string contraseña)
        {
            Conexion_Usuarios Datos = new Conexion_Usuarios();
            return Datos.Login_SQL(usuario, contraseña);
        }
    }
}
