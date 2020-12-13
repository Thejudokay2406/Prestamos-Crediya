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
    public class fSolicitud
    {
        //Buscar Solicitud
        public static DataTable Buscar(int auto, string Filtro)
        {
            Conexion_Solicitud Datos = new Conexion_Solicitud();
            return Datos.Buscar(auto, Filtro);
        }

        public static DataTable Lista()
        {
            Conexion_Solicitud Datos = new Conexion_Solicitud();
            return Datos.Lista();
        }

        public static DataTable CodigoID_Solicitud(string filtro)
        {
            Conexion_Solicitud Datos = new Conexion_Solicitud();
            return Datos.CodigoID_Solicitud(filtro);
        }

        public static string Guardar_DatosBasicos
            (
                //Datos Auxiliares
                int auto,

                //Datos Basicos
                int orden, string solicitante, string identificacion, string valor, DateTime solicitud, DateTime prestamo, string modalidad, string direccion, string fijo, string movil, string empresa, string cargo, string direccion_E, string fijo_E, string movil_e, string salario, string otros, string referencia, string parentesco, string direccion_r, string fijo_r, string movil_r, string observacion,

                //Panel documentos
                Byte[] pagare, Byte[] codeudor, Byte[] deudor, Byte[] otrosdoc,

                //Panel Impuestos
                DataTable detalle_codeudor
            )
        {
            Conexion_Solicitud Datos = new Conexion_Solicitud();
            Entidad_Solicitud Obj = new Entidad_Solicitud();

            //Datos Auxiliares
            Obj.Auto = auto;

            //Datos Basicos
            Obj.Orden = orden;
            Obj.Solicitante = solicitante;
            Obj.Identificacion = identificacion;
            Obj.Valor = valor;
            Obj.Solicitud = solicitud;
            Obj.Prestamos = prestamo;
            Obj.Modalidad = modalidad;
            Obj.Direccion = direccion;
            Obj.Fijo = fijo;
            Obj.Movil = movil;
            Obj.Empresa = empresa;
            Obj.Cargo = cargo;
            Obj.Direccion_E = direccion_E;
            Obj.Fijo_E = fijo_E;
            Obj.Movil_E = movil_e;
            Obj.Salario = salario;
            Obj.Otros = otros;
            Obj.Referencia = referencia;
            Obj.Parentesco = parentesco;
            Obj.Direccion_R = direccion_r;
            Obj.Fijo_R = fijo_r;
            Obj.Movil_R = movil_r;
            Obj.Observacion = observacion;

            Obj.Pagare = pagare;
            Obj.Codeudor = codeudor;
            Obj.Deudor = deudor;
            Obj.OtrosDocumentos = otrosdoc;

            //Panel Impuestos
            Obj.Detalle_Codeudor = detalle_codeudor;

            return Datos.Guardar_DatosBasicos(Obj);
        }

        public static string Guardar_Codeudor
            (
                //Datos Auxiliares
                int auto,

                //Datos Basicos
                int orden, string solicitante, string identificacion, string valor, DateTime solicitud, DateTime prestamo, string modalidad, string direccion, string fijo, string movil, string empresa, string cargo, string direccion_E, string fijo_E, string movil_e, string salario, string otros, string referencia, string parentesco, string direccion_r, string fijo_r, string movil_r, string observacion
            )
        {
            Conexion_Solicitud Datos = new Conexion_Solicitud();
            Entidad_Solicitud Obj = new Entidad_Solicitud();

            //Datos Auxiliares
            Obj.Auto = auto;

            //Datos Basicos
            Obj.Orden = orden;
            Obj.Solicitante = solicitante;
            Obj.Identificacion = identificacion;
            Obj.Valor = valor;
            Obj.Solicitud = solicitud;
            Obj.Prestamos = prestamo;
            Obj.Modalidad = modalidad;
            Obj.Direccion = direccion;
            Obj.Fijo = fijo;
            Obj.Movil = movil;
            Obj.Empresa = empresa;
            Obj.Cargo = cargo;
            Obj.Direccion_E = direccion_E;
            Obj.Fijo_E = fijo_E;
            Obj.Movil_E = movil;
            Obj.Salario = salario;
            Obj.Otros = otros;
            Obj.Referencia = referencia;
            Obj.Parentesco = parentesco;
            Obj.Direccion_R = direccion_r;
            Obj.Fijo_R = fijo_r;
            Obj.Movil_R = movil_r;
            Obj.Observacion = observacion;

            return Datos.Guardar_DatosBasicos(Obj);
        }

        ////Metodo eliminar
        //public static string Eliminar(int IDEliminar_SQL, int auto)
        //{
        //    Conexion_Solicitud Datos = new Conexion_Solicitud();
        //    return Datos.Eliminar(IDEliminar_SQL, auto);
        //}

        ////Metodo Liquidar Solicitud
        //public static string Liquidar(int iddatosbasicos ,string estado)
        //{
        //    Conexion_Solicitud Obj = new Conexion_Solicitud();
        //    Obj.idso = iddatosbasicos;
        //    Obj.Estado = estado;
        //    return Obj.Liquidar(Obj);
        //}

        //public static DataTable Consulta_SolicitudSQL(string filtro)
        //{
        //    Conexion_Solicitud Datos = new Conexion_Solicitud();
        //    Datos.Filtro = filtro;
        //    return Datos.Consulta_SolicitudSQL(Filtro);
        //}
    }
}
