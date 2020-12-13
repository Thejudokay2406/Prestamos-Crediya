using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class Entidad_Consignaciones
    {
        //Llave primaria
        private int _Idconsignacion;

        //Datos Basicos
        private Int64 _OrdenDeSolicitud;
        private string _Nombre;
        private Int64 _Identificacion;
        private Int64 _Valor_Prestamo;
        private Int64 _Valor_Abono;
        private DateTime _Fecha;
        private string _Observacion;

        //Datos Auxiliares
        private int _Auto;
        private int _Eliminar;
        private string _Filtro;

        public int Idconsignacion { get => _Idconsignacion; set => _Idconsignacion = value; }
        public Int64 OrdenDeSolicitud { get => _OrdenDeSolicitud; set => _OrdenDeSolicitud = value; }
        public string Nombre { get => _Nombre; set => _Nombre = value; }
        public Int64 Identificacion { get => _Identificacion; set => _Identificacion = value; }
        public Int64 Valor_Prestamo { get => _Valor_Prestamo; set => _Valor_Prestamo = value; }
        public Int64 Valor_Abono { get => _Valor_Abono; set => _Valor_Abono = value; }
        public DateTime Fecha { get => _Fecha; set => _Fecha = value; }
        public string Observacion { get => _Observacion; set => _Observacion = value; }
        public int Auto { get => _Auto; set => _Auto = value; }
        public int Eliminar { get => _Eliminar; set => _Eliminar = value; }
        public string Filtro { get => _Filtro; set => _Filtro = value; }
    }
}
