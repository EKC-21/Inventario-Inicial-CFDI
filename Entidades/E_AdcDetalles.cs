using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class E_AdcDetalles
    {
        private Int32 partida;
        private Int64 idDetalleBS;
        private Int64 idPrecompromiso;
        private String claveBienServicio;
        private String descripcion;
        private String idClasificadorSubsidio;
        private Decimal cantidad;
        private Decimal precioUnitario;
        private Decimal importe;
        private Decimal iva;
        private Decimal isr;
        private String clavePresupuestal;
        private String idCatCOG;

        private Decimal existenciasURG;
        private Decimal cantidadAutorizada;
        private String unidadMedida;

        //PARA CONSULTA
        private String nombreProveedor;
        private String descripcionCog;

        public Int32 Partida
        {
            get { return partida; }
            set { partida = value; }
        }

        public Int64 IdDetalleBS
        {
            get { return idDetalleBS; }
            set { idDetalleBS = value; }
        }

        public Int64 IdPrecompromiso
        {
            get { return idPrecompromiso; }
            set { idPrecompromiso = value; }
        }

        public String ClaveBienServicio
        {
            get { return claveBienServicio; }
            set { claveBienServicio = value; }
        }

        public String Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

        public String IdClasificadorSubsidio
        {
            get { return idClasificadorSubsidio; }
            set { idClasificadorSubsidio = value; }
        }

        public Decimal Cantidad
        {
            get { return cantidad; }
            set { cantidad = value; }
        }

        public Decimal PrecioUnitario
        {
            get { return precioUnitario; }
            set { precioUnitario = value; }
        }

        public Decimal Importe
        {
            get { return importe; }
            set { importe = value; }
        }

        public Decimal Iva
        {
            get { return iva; }
            set { iva = value; }
        }

        public Decimal Isr
        {
            get { return isr; }
            set { isr = value; }
        }

        public String ClavePresupuestal
        {
            get { return clavePresupuestal; }
            set { clavePresupuestal = value; }
        }

        public String IdCatCOG
        {
            get { return idCatCOG; }
            set { idCatCOG = value; }
        }

        public Decimal ExistenciasURG
        {
            get { return existenciasURG; }
            set { existenciasURG = value; }
        }

        public Decimal CantidadAutorizada
        {
            get { return cantidadAutorizada; }
            set { cantidadAutorizada = value; }
        }

        public String UnidadMedida
        {
            get { return unidadMedida; }
            set { unidadMedida = value; }
        }

        public String NombreProveedor
        {
            get { return nombreProveedor; }
            set { nombreProveedor = value; }
        }

        public String DescripcionCog
        {
            get { return descripcionCog; }
            set { descripcionCog = value; }
        }
    }
}
