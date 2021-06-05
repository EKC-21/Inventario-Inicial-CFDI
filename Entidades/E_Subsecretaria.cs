using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class E_Subsecretaria
    {
        Int64 bandera;
        string claveSubsecretaria;
        Int16 long_id_subsecretaria;
        string tipo_datos_subsecretaria;
        string sigla;
        string nombre;
        string claveSecretaria;
        string mision;
        string vision;
        string diagnosticoSector;
        string enlace;
        string cargoEnlace;
        string director;
        string cargoDirector;
        string clavePresupuestal;

        public Int64 Bandera
        {
            get { return bandera; }
            set { bandera = value; }
        }

        public Int16 Long_id_subsecretaria
        {
            get { return long_id_subsecretaria; }
            set { long_id_subsecretaria = value; }
        }

        public string Tipo_datos_subsecretaria
        {
            get { return tipo_datos_subsecretaria; }
            set { tipo_datos_subsecretaria = value; }
        }

        public string ClaveSubsecretaria
        {
            get { return claveSubsecretaria; }
            set { claveSubsecretaria = value; }
        }

        public string Sigla
        {
            get { return sigla; }
            set { sigla = value; }
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public string ClaveSecretaria
        {
            get { return claveSecretaria; }
            set { claveSecretaria = value; }
        }

        public string Mision
        {
            get { return mision; }
            set { mision = value; }
        }

        public string Vision
        {
            get { return vision; }
            set { vision = value; }
        }

        public string DiagnosticoSector
        {
            get { return diagnosticoSector; }
            set { diagnosticoSector = value; }
        }

        public string Enlace
        {
            get { return enlace; }
            set { enlace = value; }
        }

        public string CargoEnlace
        {
            get { return cargoEnlace; }
            set { cargoEnlace = value; }
        }

        public string Director
        {
            get { return director; }
            set { director = value; }
        }

        public string CargoDirector
        {
            get { return cargoDirector; }
            set { cargoDirector = value; }
        }

        public string ClavePresupuestal
        {
            get { return clavePresupuestal; }
            set { clavePresupuestal = value; }
        }
    }
}
