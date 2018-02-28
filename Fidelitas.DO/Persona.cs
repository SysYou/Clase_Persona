using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fidelitas.DO
{
    public class Persona
    {

        #region Atributos

        private int iCedula;
        private string vNombre;
        private bool bMuerto;
        private DateTime dtNacimiento;
        private int iEdad;
        private string vEmail;

        #endregion

        #region Propiedades
        public int ICedula
        {
            get { return iCedula; }
            set { iCedula = value; }
        }
       
        public string VNombre
        {
            get { return vNombre; }
            set { vNombre = value; }
        }

        public bool BMuerto
        {
            get { return bMuerto; }
            set { bMuerto = value; }
        }

        public DateTime DTNacimiento
        {
            get { return dtNacimiento; }
            set { dtNacimiento = value; }
        }

        public int IEdad
        {
            get { return iEdad; }
            set { iEdad = value; }
        }

        public string VEmail
        {
            get { return vEmail; }
            set { vEmail = value; }
        }
        #endregion
    }
}
