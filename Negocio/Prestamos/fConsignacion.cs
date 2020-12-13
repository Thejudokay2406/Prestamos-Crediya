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
    public class fConsignacion
    {
        public static DataTable Lista()
        {
            Conexion_Consignacion Datos = new Conexion_Consignacion();
            return Datos.Lista();
        }

        public static DataTable Lista_Consignacion(int auto, int idsolicitud)
        {
            Conexion_Consignacion Datos = new Conexion_Consignacion();
            return Datos.Lista_Consignacion(auto, idsolicitud);
        }
        //Metodo Guardar
        public static string Guardar_DatosBasicos
            (
                //Datos Auxiliares y Llaves Primaria
                int auto,

                //Datos Basicos
                Int64 OrdenDeSolicitud, string Nombre, Int64 Identificacion, Int64 ValorPrestamo, Int64 ValorAbono, DateTime Fecha, string Observacion
            )
        {
            Conexion_Consignacion Datos = new Conexion_Consignacion();
            Entidad_Consignaciones Obj = new Entidad_Consignaciones();

            //Datos Auxiliares
            Obj.Auto = auto;

            //Datos Basicos
            Obj.OrdenDeSolicitud = OrdenDeSolicitud;
            Obj.Nombre = Nombre;
            Obj.Identificacion = Identificacion;
            Obj.Valor_Prestamo = ValorPrestamo;
            Obj.Valor_Abono = ValorAbono;
            Obj.Fecha = Fecha;
            Obj.Observacion = Observacion;

            return Datos.Guardar_DatosBasicos(Obj);
        }

        public static string Guardar_Consignacion
            (
                //Datos Auxiliares y Llaves Primaria
                int auto,

                //Datos Basicos
                Int64 OrdenDeSolicitud, string Nombre, Int64 Identificacion, Int64 ValorPrestamo, Int64 ValorAbono, DateTime Fecha, string Observacion
            )
        {
            Conexion_Consignacion Datos = new Conexion_Consignacion();
            Entidad_Consignaciones Obj = new Entidad_Consignaciones();

            //Datos Auxiliares
            Obj.Auto = auto;

            //Datos Basicos
            Obj.OrdenDeSolicitud = OrdenDeSolicitud;
            Obj.Nombre = Nombre;
            Obj.Identificacion = Identificacion;
            Obj.Valor_Prestamo = ValorPrestamo;
            Obj.Valor_Abono = ValorAbono;
            Obj.Fecha = Fecha;
            Obj.Observacion = Observacion;

            return Datos.Guardar_Consignacion(Obj);
        }

        //Metodo Editar
        public static string Editar_DatosBasicos
            (

                //Datos Auxiliares y Llaves Primaria
                int auto, int idconsignacion,

                //Datos Basicos
                Int64 OrdenDeSolicitud, string Nombre, Int64 Identificacion, Int64 ValorPrestamo, Int64 ValorAbono, DateTime Fecha, string Observacion

            )
        {
            Conexion_Consignacion Datos = new Conexion_Consignacion();
            Entidad_Consignaciones Obj = new Entidad_Consignaciones();

            //Datos Auxiliares y Llaves Primarias
            Obj.Auto = auto;
            Obj.Idconsignacion = idconsignacion;

            //Datos Basicos
            Obj.OrdenDeSolicitud = OrdenDeSolicitud;
            Obj.Nombre = Nombre;
            Obj.Identificacion = Identificacion;
            Obj.Valor_Prestamo = ValorPrestamo;
            Obj.Valor_Abono = ValorAbono;
            Obj.Fecha = Fecha;
            Obj.Observacion = Observacion;

            return Datos.Editar_DatosBasicos(Obj);
        }

        public static DataTable Buscar(string Filtro, int auto)
        {
            Conexion_Consignacion Datos = new Conexion_Consignacion();
            return Datos.Buscar(Filtro, auto);
        }

        public static string Eliminar(int IDEliminar_SQL, int auto)
        {
            Conexion_Consignacion Datos = new Conexion_Consignacion();
            return Datos.Eliminar(IDEliminar_SQL, auto);
        }

        public static string Eliminar_Abono(int Idconsignacion, int auto)
        {
            Conexion_Consignacion Datos = new Conexion_Consignacion();
            return Datos.Eliminar_Abono(Idconsignacion, auto);
        }
    }
}
