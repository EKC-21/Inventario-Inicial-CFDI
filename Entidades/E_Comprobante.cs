using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class E_Comprobante
    {
        string folio;
        DateTime fecha;
        int lugarExpedicion;
        long noCertificado;
        string serie;
        string tipoDeComprobante;
        string metodoPago;
        string condicionesDePago;
        string moneda;
        int tipoCambio;
        double subTotal;
        double total;
        string version;
        string formapago;
        string archivoOriginal;

        //EMISOR
        string EmisorRFC;
        string EmisorNombre;
        string RegimenFiscal;
        long idProveedor;

        //RECEPTOR
        string ReceptorRFC;
        string ReceptorNombre;
        string UsoCFDI;
        string uuidrelacionado;

        //CONCEPTOS
       

        //IMPUESTOS
        double Base;
        string Impuesto;
        string TipoFactor;
        double TasaOCuota;
        double ImporteImpuesto;

        //COMPLEMENTO -- TimbreFiscalDigital
        int VersionComplemento;
        string UUID;
        DateTime FechaTimbrado;
        string RfcProvCertif;
        long SelloCFD;
        long NoCertificadoSAT;
        long SelloSAT;

        string Clave;
        string Aux;

        public string Folio { get => folio; set => folio = value; }
        public DateTime Fecha { get => fecha; set => fecha = value; }
        public int LugarExpedicion { get => lugarExpedicion; set => lugarExpedicion = value; }
        public long NoCertificado { get => noCertificado; set => noCertificado = value; }
        public string Serie { get => serie; set => serie = value; }
        public string TipoDeComprobante { get => tipoDeComprobante; set => tipoDeComprobante = value; }
        public string MetodoPago { get => metodoPago; set => metodoPago = value; }
        public string CondicionesDePago { get => condicionesDePago; set => condicionesDePago = value; }
        public string Moneda { get => moneda; set => moneda = value; }
        public int TipoCambio { get => tipoCambio; set => tipoCambio = value; }
        public double SubTotal { get => subTotal; set => subTotal = value; }
        public double Total { get => total; set => total = value; }
        public string Version { get => version; set => version = value; }
        public string EmisorRFC1 { get => EmisorRFC; set => EmisorRFC = value; }
        public string EmisorNombre1 { get => EmisorNombre; set => EmisorNombre = value; }
        public string RegimenFiscal1 { get => RegimenFiscal; set => RegimenFiscal = value; }
        public string ReceptorRFC1 { get => ReceptorRFC; set => ReceptorRFC = value; }
        public string ReceptorNombre1 { get => ReceptorNombre; set => ReceptorNombre = value; }
        public string UsoCFDI1 { get => UsoCFDI; set => UsoCFDI = value; }
        public double Base1 { get => Base; set => Base = value; }
        public string Impuesto1 { get => Impuesto; set => Impuesto = value; }
        public string TipoFactor1 { get => TipoFactor; set => TipoFactor = value; }
        public double TasaOCuota1 { get => TasaOCuota; set => TasaOCuota = value; }
        public double ImporteImpuesto1 { get => ImporteImpuesto; set => ImporteImpuesto = value; }
        public int VersionComplemento1 { get => VersionComplemento; set => VersionComplemento = value; }
        public string UUID1 { get => UUID; set => UUID = value; }
        public DateTime FechaTimbrado1 { get => FechaTimbrado; set => FechaTimbrado = value; }
        public string RfcProvCertif1 { get => RfcProvCertif; set => RfcProvCertif = value; }
        public long SelloCFD1 { get => SelloCFD; set => SelloCFD = value; }
        public long NoCertificadoSAT1 { get => NoCertificadoSAT; set => NoCertificadoSAT = value; }
        public long SelloSAT1 { get => SelloSAT; set => SelloSAT = value; }
        public string Aux1 { get => Aux; set => Aux = value; }
        public string Clave1 { get => Clave; set => Clave = value; }
        public string Formapago { get => formapago; set => formapago = value; }
        public string Uuidrelacionado { get => uuidrelacionado; set => uuidrelacionado = value; }
        public string ArchivoOriginal { get => archivoOriginal; set => archivoOriginal = value; }
        public long IdProveedor { get => idProveedor; set => idProveedor = value; }
    } 
    public class Conceptos
    {
        string Descripcion;
        int ClaveProdServ;
        double Cantidad;
        string ClaveUnidad;
        string Unidad;
        double ValorUnitario;
        double Importe;
        long NoIdentificacion;
        double descuento;

        public string Descripcion1 { get => Descripcion; set => Descripcion = value; }
        public int ClaveProdServ1 { get => ClaveProdServ; set => ClaveProdServ = value; }
        public double Cantidad1 { get => Cantidad; set => Cantidad = value; }
        public string ClaveUnidad1 { get => ClaveUnidad; set => ClaveUnidad = value; }
        public string Unidad1 { get => Unidad; set => Unidad = value; }
        public double ValorUnitario1 { get => ValorUnitario; set => ValorUnitario = value; }
        public double Importe1 { get => Importe; set => Importe = value; }
        public long NoIdentificacion1 { get => NoIdentificacion; set => NoIdentificacion = value; }
        public double Descuento { get => descuento; set => descuento = value; }
    }
}
