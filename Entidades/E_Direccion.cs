using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class E_Direccion
    {
        private String claveDireccion;
        Int16 long_id_direccion;
        string tipo_datos_direccion;
        private String sigla;
        private String nombre;
        private String claveSubsecretaria;
        private String mision;
        private String vision;
        private String diagnosticoSector;
        private String enlace;
        private String cargoEnlace;
        private String director;
        private String cargoDirector;
        private String clavePresupuestal;
        private String claveSecretaria;
        private String clavescian;

        private String ctaCOG;

        private Int64 idCotizacion;

        private String administrador;
        private int permisoGeneral;

        public String ClaveDireccion
        {
            get { return claveDireccion; }
            set { claveDireccion = value; }
        }

        public Int16 Long_id_direccion
        {
            get { return long_id_direccion; }
            set { long_id_direccion = value; }
        }

        public string Tipo_datos_direccion
        {
            get { return tipo_datos_direccion; }
            set { tipo_datos_direccion = value; }
        }

        public String Sigla
        {
            get { return sigla; }
            set { sigla = value; }
        }

        public String Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public String ClaveSubsecretaria
        {
            get { return claveSubsecretaria; }
            set { claveSubsecretaria = value; }
        }

        public String Mision
        {
            get { return mision; }
            set { mision = value; }
        }

        public String Vision
        {
            get { return vision; }
            set { vision = value; }
        }

        public String DiagnosticoSector
        {
            get { return diagnosticoSector; }
            set { diagnosticoSector = value; }
        }

        public String Enlace
        {
            get { return enlace; }
            set { enlace = value; }
        }

        public String CargoEnlace
        {
            get { return cargoEnlace; }
            set { cargoEnlace = value; }
        }

        public String Director
        {
            get { return director; }
            set { director = value; }
        }

        public String CargoDirector
        {
            get { return cargoDirector; }
            set { cargoDirector = value; }
        }

        public String ClavePresupuestal
        {
            get { return clavePresupuestal; }
            set { clavePresupuestal = value; }
        }

        public String ClaveSecretaria
        {
            get { return claveSecretaria; }
            set { claveSecretaria = value; }
        }

        public String Clavescian
        {
            get { return clavescian; }
            set { clavescian = value; }
        }

        public String CtaCOG
        {
            get { return ctaCOG; }
            set { ctaCOG = value; }
        }

        public Int64 IdCotizacion
        {
            get { return idCotizacion; }
            set { idCotizacion = value; }
        }

        public String Administrador
        {
            get { return administrador; }
            set { administrador = value; }
        }

        public int PermisoGeneral
        {
            get { return permisoGeneral; }
            set { permisoGeneral = value; }
        }
    }
}
