
using System;
using System.Windows.Forms;
using RepoDb;


namespace SistemaRegistroNotas
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal de la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Inicializa RepoDB para trabajar con SQL Server.
            GlobalConfiguration
                .Setup()
                .UseSqlServer();

            // Configuración visual de Windows Forms.
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Abre el formulario principal.
            Application.Run(new frmRegistrarNota());
        }
    }
}
