using System;
namespace HistorialMedico.Assests
{
    public class Help
    {
        public string informacionGlucosa(string glucosa)
        {
            string mensaje = "";

            int inGlucosa = Convert.ToInt32(glucosa);

            if (inGlucosa >= 215)
            { mensaje = "Altamente elevado"; }

            else if (inGlucosa >= 150 & inGlucosa <= 180)
            { mensaje = "Nivel Elevado"; }

            else if (inGlucosa >= 80 & inGlucosa <= 115)
            { mensaje = "Niveles Normales"; }

            else if (inGlucosa >= 0 & inGlucosa <= 70)
            { mensaje = "Hipoglucemia"; }

            return mensaje;
        }



    }
}
