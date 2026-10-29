using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SistemaRegistroNotas.Clases
{
    // Esta clase representa a un estudiante y sus notas.
    public class Estudiante
    {
        // Identificador que genera automáticamente SQL Server.
        public int IdEstudiante { get; set; }

        // Datos personales del estudiante.
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Codigo { get; set; }

        // Notas obtenidas en las actividades de la materia.
        public decimal Laboratorio { get; set; }
        public decimal Parcial { get; set; }
        public decimal Asistencia { get; set; }

        // Nota calculada según los porcentajes de la actividad.
        public decimal NotaFinal { get; set; }
    }
}

