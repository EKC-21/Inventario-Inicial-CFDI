using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class E_Precompromiso
    {
        public long IdPrecompromiso { get; set; }

        public string NumeroInterno { get; set; }

        public string Estatus { get; set; }

        public Int64 IdTipoGasto { get; set; }

        public string ClavePersonal { get; set; }

        public string Elabora { get; set; }

        public string Autoriza { get; set; }

        public string ClaveDireccion { get; set; }

        public string ClaveSecretaria { get; set; }

        public string ClaveSubsecretaria { get; set; }

        public Int64 IdProyecto { get; set; }

        public Int64 Iddestino { get; set; }

        public string TipoRequisicion { get; set; }

        public DateTime FechaSolicitud { get; set; }

        public DateTime FechaAutorizacion { get; set; }

        public string Justificacion { get; set; }

        public string Especificaciones { get; set; }

        public string Observaciones { get; set; }

        public string NombreProyecto { get; set; }

        public string TipoServicio { get; set; }

        public string SubSecretaria { get; set; }

        public string Direccion { get; set; }

        public string CveAdva { get; set; }

        public string CveAdvaDesc { get; set; }

        public string Secretaria { get; set; }

        public String idppiclasificadorsubsidios { get; set; }

        public String nombreFF { get; set; }

        public String claveObraAccion { get; set; }

        public List<E_AdcDetalles> ListaDetalle { get; set; }

        public String AR { get; set; }

        public String CveFF { get; set; }  // leo 16/07/2017
    }
}
