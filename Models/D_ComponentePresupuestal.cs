using AccesoDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace Models
{
    public class D_ComponentePresupuestal
    {
        AD_ComponentePresupuestal metodos = new AD_ComponentePresupuestal();

        public DataTable ConsultaAcceso()
        {
            return metodos.ConsultarAcceso();
        }
        public DataTable ConsultaEnteAdvo()
        {
            return metodos.ConsultarEnteAdvo();
        }
        public DataTable ConsultaCveAdva()
        {
            return metodos.ConsultarCveAdva();
        }
        public DataTable Consultaftetfin()
        {
            return metodos.ConsultaFteFinanciamiento();
        }
        public DataTable ConsultaSecretaria(E_Secretaria obj)
        {
            return metodos.BuscarSecretaria(obj);
        }
        public DataTable ConsultaSubsecretaria(E_Subsecretaria obj)
        {
            return metodos.BuscarSubSecretaria(obj);
        }
        public DataTable BuscaDireccion(E_Direccion obj)
        {
            return metodos.BuscarDireccion(obj);
        }
        public DataTable BuscaProyectos(string Secretaria, string SubSecretaria, string Direccion, string cveAdmin, Int32 anio)
        {
            return metodos.BuscarProyecto(Secretaria, SubSecretaria, Direccion, cveAdmin, anio);
        }
        public Int64 AltasPreCompromiso(E_Precompromiso e_Precompromiso)
        {
            return metodos.AltaPreCompromiso(e_Precompromiso);
        }
    }
}
