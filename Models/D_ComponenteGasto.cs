using AccesoDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace Models
{
    public class D_ComponenteGasto
    {
        AD_ComponenteGasto comp = new AD_ComponenteGasto();
        
        public string GuardarXML(Conceptos conceptos)
        {
            return comp.GuardarXML(conceptos);            
        }
        public string GuardarConceptosCfdi(Conceptos conceptos)
        {
            return comp.GuardarCfdiConcepto(conceptos);
        }
        public string GuardarTrasladosCfdi(E_Comprobante e_Comprobante)
        {
            return comp.GuardarCfdiTraslados(e_Comprobante);
        }
        public int ValidaProveedor(E_Comprobante e_Comprobante)
        {
            return comp.ComprobarProveedor(e_Comprobante);
        }
        public int ValidarFactura(E_Comprobante e_Comprobante)
        {
            return comp.ComprobarFactura(e_Comprobante);
        }
        public string Guarda(DataTable data)
        {
            return comp.Guardar(data);
        }
        public DataTable GetAllConceptos()
        {
            return comp.LeerConcentradoConceptos();
        }
        public string ObtenerClave()
        {
            return comp.ConsultarClave();
        }
        public string GuardarProveedor(E_Comprobante e_Comprobante)
        {
            return comp.AgregarProveedor(e_Comprobante);
        }
        public string ObtenerAux()
        {
            return comp.ConsultarAux();
        }
        public int GuardaFactura(E_Comprobante e_Comprobante)
        {
            return comp.GuardarFactura(e_Comprobante);
        }
        public DataTable ConsultaCtaContable()
        {
            return comp.ConsultaCtaContable5();
        }
        public string CtaContablesP(string Tipo, string Nombre, string BusCuenta)
        {
            return comp.CuentasContablesP(Tipo, Nombre, BusCuenta);
        }
    }
}
