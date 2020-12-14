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
    public class fCodeudor
    {
        //Metodo Guardar
        public static string Guardar_DatosBasicos
            (
                //Datos Auxiliares y Llaves Primaria
                int auto,

                //Datos Basicos
                string codeudor, string identificacion, string direccion, string fijo, string movil, string empresa, string cargo, string direccion_E, string fijo_E, string movil_e, string salario, string otros, string referencia, string parentesco, string direccion_r, string fijo_r, string movil_r
            )
        {
            Conexion_Codeudor Datos = new Conexion_Codeudor();
            Entidad_Codeudor Obj = new Entidad_Codeudor();

            //Datos Auxiliares
            Obj.Auto = auto;

            //Datos Basicos
            Obj.Codeudor = codeudor;
            Obj.Identificacion = identificacion;
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

            return Datos.Guardar_DatosBasicos(Obj);
        }

        //Metodo Editar
        public static string Editar_DatosBasicos
            (

                //Datos Auxiliares y Llaves Primaria
                int auto, int idcodeudor,

                //Datos Basicos
                string codeudor, string identificacion, string direccion, string fijo, string movil, string empresa, string cargo, string direccion_E, string fijo_E, string movil_e, string salario, string otros, string referencia, string parentesco, string direccion_r, string fijo_r, string movil_r

            )
        {
            Conexion_Codeudor Datos = new Conexion_Codeudor();
            Entidad_Codeudor Obj = new Entidad_Codeudor();

            //Datos Auxiliares y Llaves Primarias
            Obj.Auto = auto;
            Obj.Idcodeudor = idcodeudor;

            //Datos Basicos
            Obj.Codeudor = codeudor;
            Obj.Identificacion = identificacion;
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

            return Datos.Editar_DatosBasicos(Obj);
        }

        public static DataTable Buscar(string Filtro, int auto)
        {
            Conexion_Codeudor Datos = new Conexion_Codeudor();
            return Datos.Buscar(Filtro, auto);
        }

        public static string Eliminar(int IDEliminar_SQL, int auto)
        {
            Conexion_Codeudor Datos = new Conexion_Codeudor();
            return Datos.Eliminar(IDEliminar_SQL, auto);
        }
        public static string Eliminar_Codeudor(int IDEliminar_SQL, int auto)
        {
            Conexion_Codeudor Datos = new Conexion_Codeudor();
            return Datos.Eliminar_Codeudor(IDEliminar_SQL, auto);
        }
    }
}
