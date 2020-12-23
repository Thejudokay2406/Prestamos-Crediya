using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class Entidad_Gastos
    {
        //Llave primaria
        private int _Idgasto;

        //Datos Basicos
        private string _Beneficiario;
        private string _Descripcion;
        private string _Valor;
        private DateTime _Fecha;
        private string _Observacion;

        //Datos Auxiliares
        private int _Auto;
        private int _Eliminar;
        private string _Filtro;

        public int Idgasto { get => _Idgasto; set => _Idgasto = value; }
        public string Beneficiario { get => _Beneficiario; set => _Beneficiario = value; }
        public string Descripcion { get => _Descripcion; set => _Descripcion = value; }
        public string Valor { get => _Valor; set => _Valor = value; }
        public DateTime Fecha { get => _Fecha; set => _Fecha = value; }
        public string Observacion { get => _Observacion; set => _Observacion = value; }
        public int Auto { get => _Auto; set => _Auto = value; }
        public int Eliminar { get => _Eliminar; set => _Eliminar = value; }
        public string Filtro { get => _Filtro; set => _Filtro = value; }
    }
}
