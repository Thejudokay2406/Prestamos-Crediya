using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;

namespace Entidad
{
    public class Entidad_Solicitud
    {
        //Llave primaria
        private int _Idsolicitud;

        //Datos Basicos
        private int _Orden;
        private string _Solicitante;
        private string _Identificacion;
        private string _Valor;
        private DateTime _Solicitud;
        private DateTime _Prestamos;
        private string _Modalidad;
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
        private string _Observacion;

        //Imagenes 
        private byte[] _Pagare;
        private byte[] _Codeudor;
        private byte[] _Deudor;
        private byte[] _OtrosDocumentos;

        //
        private DataTable _Detalle_Codeudor;

        //Datos para Ejecutar las Transacciones en SQL
        private int _Codeudor_AutoSQL;
        
        //
        private int _Tran_Codeudor;
        
        //Datos Auxiliares
        private int _Auto;
        private int _Eliminar;
        private string _Filtro;

        public int Idsolicitud { get => _Idsolicitud; set => _Idsolicitud = value; }
        public int Orden { get => _Orden; set => _Orden = value; }
        public string Solicitante { get => _Solicitante; set => _Solicitante = value; }
        public string Identificacion { get => _Identificacion; set => _Identificacion = value; }
        public string Valor { get => _Valor; set => _Valor = value; }
        public DateTime Solicitud { get => _Solicitud; set => _Solicitud = value; }
        public DateTime Prestamos { get => _Prestamos; set => _Prestamos = value; }
        public string Modalidad { get => _Modalidad; set => _Modalidad = value; }
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
        public string Observacion { get => _Observacion; set => _Observacion = value; }
        public byte[] Pagare { get => _Pagare; set => _Pagare = value; }
        public byte[] Codeudor { get => _Codeudor; set => _Codeudor = value; }
        public byte[] Deudor { get => _Deudor; set => _Deudor = value; }
        public byte[] OtrosDocumentos { get => _OtrosDocumentos; set => _OtrosDocumentos = value; }
        public int Auto { get => _Auto; set => _Auto = value; }
        public int Eliminar { get => _Eliminar; set => _Eliminar = value; }
        public string Filtro { get => _Filtro; set => _Filtro = value; }
        public DataTable Detalle_Codeudor { get => _Detalle_Codeudor; set => _Detalle_Codeudor = value; }
        public int Codeudor_AutoSQL { get => _Codeudor_AutoSQL; set => _Codeudor_AutoSQL = value; }
        public int Tran_Codeudor { get => _Tran_Codeudor; set => _Tran_Codeudor = value; }
    }
}
