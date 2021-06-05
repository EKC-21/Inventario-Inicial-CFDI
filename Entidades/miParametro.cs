using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class miParametro
    {
        public string Nombre;
        public string Valor;
        public SqlDbType Tipo;
        public int Size;
        private string p;
        private Int64 NumeroCompromiso;
        private SqlDbType sqlDbType;
        private Int64 p_2;

        //constructor sin parametros
        public miParametro()
        {
            Nombre = "";
            Tipo = new SqlDbType();
            Valor = "";
            Size = 0;
        }

        //constructor parametrizado
        public miParametro(string nombre, string valor, SqlDbType tipo, int size)
        {
            this.Nombre = nombre;
            this.Valor = valor;
            this.Tipo = tipo;
            this.Size = size;
        }

        public miParametro(string p, Int64 NumeroCompromiso, SqlDbType sqlDbType, Int64 p_2)
        {
            // TODO: Complete member initialization
            this.p = p;
            this.NumeroCompromiso = NumeroCompromiso;
            this.sqlDbType = sqlDbType;
            this.p_2 = p_2;
        }
    }
}
