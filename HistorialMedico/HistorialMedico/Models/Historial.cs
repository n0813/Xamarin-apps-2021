using System;
using SQLite;

namespace HistorialMedico.Models
{
    public class Historial
    {
        [PrimaryKey,AutoIncrement]
        public int id { get; set; }

        public DateTime Fecha { get; set; }

        public int  Glucosa { get; set; }
        public string Presion { get; set; }

        [MaxLength(150)]
        public string Comentarios { get; set; }

        public string InfoGlucosa { get; set; }

        public string infoPresion { get; set; }

    }
}
