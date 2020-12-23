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
    public class fGastos
    {
        //Buscar Solicitud
        public static DataTable Buscar(string Filtro, int auto)
        {
            Conexion_Gastos Datos = new Conexion_Gastos();
            return Datos.Buscar(Filtro, auto);
        }

        public static string Guardar_DatosBasicos
            (
                //Datos Auxiliares
                int auto,

                //Datos Basicos
                string beneficiario, string descripcion, string valor, DateTime fecha, string observacion
            )
        {
            Conexion_Gastos Datos = new Conexion_Gastos();
            Entidad_Gastos Obj = new Entidad_Gastos();

            //Datos Basicos
            Obj.Beneficiario = beneficiario;
            Obj.Descripcion = descripcion;
            Obj.Valor = valor;
            Obj.Fecha = fecha;
            Obj.Observacion = observacion;
                      
            //Datos Auxiliares
            Obj.Auto = auto;

            return Datos.Guardar_DatosBasicos(Obj);
        }

        public static string Editar_DatosBasicos
            (
                //Datos Auxiliares
                int auto, int idgasto,

                //Datos Basicos
                string beneficiario, string descripcion, string valor, DateTime fecha, string observacion
            )
        {
            Conexion_Gastos Datos = new Conexion_Gastos();
            Entidad_Gastos Obj = new Entidad_Gastos();

            //Datos Auxiliares
            Obj.Auto = auto;
            Obj.Idgasto = idgasto;

            //Datos Basicos
            Obj.Beneficiario = beneficiario;
            Obj.Descripcion = descripcion;
            Obj.Valor = valor;
            Obj.Fecha = fecha;
            Obj.Observacion = observacion;         

            return Datos.Editar_DatosBasicos(Obj);
        }


        public static string Eliminar(int IDEliminar_SQL, int auto)
        {
            Conexion_Gastos Datos = new Conexion_Gastos();
            return Datos.Eliminar(IDEliminar_SQL, auto);
        }

    }
}
