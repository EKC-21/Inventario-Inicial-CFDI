using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class E_Secretaria
    {
        Int64 bandera;
        string claveSecretaria;
        Int16 long_id_secretaria;
        string tipo_datos_secretaria;
        string sigla;
        string nombre;
        string mision;
        string vision;
        string diagnosticoSector;
        string clavePresupuestal;
        string enlace;
        string cargoEnlace;
        string director;
        string cargoDirector;
        Int64 id_gab;
        string cog;

        public Int64 Bandera
        {
            get { return bandera; }
            set { bandera = value; }
        }

        public Int16 Long_id_secretaria
        {
            get { return long_id_secretaria; }
            set { long_id_secretaria = value; }
        }

        public string Tipo_datos_secretaria
        {
            get { return tipo_datos_secretaria; }
            set { tipo_datos_secretaria = value; }
        }

        public string ClaveSecretaria
        {
            get { return claveSecretaria; }
            set { claveSecretaria = value; }
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

        public string ClavePresupuestal
        {
            get { return clavePresupuestal; }
            set { clavePresupuestal = value; }
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

        public Int64 Id_gab
        {
            get { return id_gab; }
            set { id_gab = value; }
        }

        public string Cog
        {
            get { return cog; }
            set { cog = value; }
        }
    }
}
