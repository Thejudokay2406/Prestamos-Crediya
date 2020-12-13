using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class Entidad_Usuario
    {
        //Datos Basicos
        private int _Idtrabajador;
        private string _Empleado;
        private string _Identificacion;
        private DateTime _Fecha;
        private string _Usuario;
        private string _Contraseña;
        private string _Descripcion;
        private int _Estado;

        //Niveles
        private int _Idnivel;
        private string _Prestamos;
        private string _Consulta;
        private string _Reportes;
        private string _Sistema;

        //Permisos
        private int _Idpermisos;
        private string _Consultar;
        private string _Guardar;
        private string _Eliminar;
        private string _Editar;

        //Filtros y Metodos
        private int _Auto;
        private string _Filtro;

        public int Idtrabajador { get => _Idtrabajador; set => _Idtrabajador = value; }
        public string Empleado { get => _Empleado; set => _Empleado = value; }
        public string Identificacion { get => _Identificacion; set => _Identificacion = value; }
        public DateTime Fecha { get => _Fecha; set => _Fecha = value; }
        public string Usuario { get => _Usuario; set => _Usuario = value; }
        public string Contraseña { get => _Contraseña; set => _Contraseña = value; }
        public string Descripcion { get => _Descripcion; set => _Descripcion = value; }
        public int Estado { get => _Estado; set => _Estado = value; }
        public int Idnivel { get => _Idnivel; set => _Idnivel = value; }
        public string Prestamos { get => _Prestamos; set => _Prestamos = value; }
        public string Consulta { get => _Consulta; set => _Consulta = value; }
        public string Reportes { get => _Reportes; set => _Reportes = value; }
        public string Sistema { get => _Sistema; set => _Sistema = value; }
        public int Idpermisos { get => _Idpermisos; set => _Idpermisos = value; }
        public string Consultar { get => _Consultar; set => _Consultar = value; }
        public string Guardar { get => _Guardar; set => _Guardar = value; }
        public string Eliminar { get => _Eliminar; set => _Eliminar = value; }
        public string Editar { get => _Editar; set => _Editar = value; }
        public int Auto { get => _Auto; set => _Auto = value; }
        public string Filtro { get => _Filtro; set => _Filtro = value; }
    }
}
