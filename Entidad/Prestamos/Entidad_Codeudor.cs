using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class Entidad_Codeudor
    {
        //Llave primaria
        private int _Idcodeudor;

        //Datos Basicos
        private int _CodigoID;
        private string _Codeudor;
        private string _Identificacion;
        private string _Direccion;
        private string _Fijo;
        private string _Movil;
        private string _Empresa;
        private string _Cargo;
        private string _Direccion_E;
        private string _Fijo_E;
        private string _Movil_E;
        private string _Salario;
        private string _Otros;
        private string _Referencia;
        private string _Parentesco;
        private string _Direccion_R;
        private string _Fijo_R;
        private string _Movil_R;

        //Datos Auxiliares
        private int _Auto;
        private int _Eliminar;
        private string _Filtro;

        public int Idcodeudor { get => _Idcodeudor; set => _Idcodeudor = value; }
        public int CodigoID { get => _CodigoID; set => _CodigoID = value; }
        public string Codeudor { get => _Codeudor; set => _Codeudor = value; }
        public string Identificacion { get => _Identificacion; set => _Identificacion = value; }
        public string Direccion { get => _Direccion; set => _Direccion = value; }
        public string Fijo { get => _Fijo; set => _Fijo = value; }
        public string Movil { get => _Movil; set => _Movil = value; }
        public string Empresa { get => _Empresa; set => _Empresa = value; }
        public string Cargo { get => _Cargo; set => _Cargo = value; }
        public string Direccion_E { get => _Direccion_E; set => _Direccion_E = value; }
        public string Fijo_E { get => _Fijo_E; set => _Fijo_E = value; }
        public string Movil_E { get => _Movil_E; set => _Movil_E = value; }
        public string Salario { get => _Salario; set => _Salario = value; }
        public string Otros { get => _Otros; set => _Otros = value; }
        public string Referencia { get => _Referencia; set => _Referencia = value; }
        public string Parentesco { get => _Parentesco; set => _Parentesco = value; }
        public string Direccion_R { get => _Direccion_R; set => _Direccion_R = value; }
        public string Fijo_R { get => _Fijo_R; set => _Fijo_R = value; }
        public string Movil_R { get => _Movil_R; set => _Movil_R = value; }
        public int Auto { get => _Auto; set => _Auto = value; }
        public int Eliminar { get => _Eliminar; set => _Eliminar = value; }
        public string Filtro { get => _Filtro; set => _Filtro = value; }
    }
}
