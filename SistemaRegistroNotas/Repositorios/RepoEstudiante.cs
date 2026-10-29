
using System.Collections.Generic;
using System.Linq;
using SistemaRegistroNotas.Clases;
using RepoDb;

namespace SistemaRegistroNotas.Repositorios
{
    // Contiene las operaciones para trabajar con estudiantes.
    public class RepoEstudiante
    {
        // Consultar todos los estudiantes.
        public List<Estudiante> ObtenerTodos()
        {
            using (var conexion = Conexion.ObtenerConexion())
            {
                var estudiantes =
                    conexion.QueryAll<Estudiante>("[dbo].[Estudiante]");

                return estudiantes.ToList();
            }
        }

        // Agregar un estudiante nuevo.
        public void Agregar(Estudiante estudiante)
        {
            using (var conexion = Conexion.ObtenerConexion())
            {
                conexion.Insert(
                    "[dbo].[Estudiante]",
                    estudiante);
            }
        }

        // Actualizar un estudiante existente.
        public void Actualizar(Estudiante estudiante)
        {
            using (var conexion = Conexion.ObtenerConexion())
            {
                conexion.Update(
                    "[dbo].[Estudiante]",
                    estudiante);
            }
        }

        // Eliminar un estudiante por su identificador.
        public void Eliminar(int idEstudiante)
        {
            using (var conexion = Conexion.ObtenerConexion())
            {
                conexion.Delete<Estudiante>(
                    idEstudiante);
            }
        }
    }
}
