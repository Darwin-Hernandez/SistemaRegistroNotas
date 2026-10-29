using System;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using SistemaRegistroNotas.Clases;

namespace SistemaRegistroNotas.Formularios
{
    public partial class frmRegistrarNotaCmd : Form
    {
        public Estudiante EstudianteEditado { get; private set; }

        public frmRegistrarNotaCmd(Estudiante estudiante)
        {
            InitializeComponent();

            EstudianteEditado = estudiante;

            CargarDatos();

            // Restricciones para nombres y apellidos.
            txtNombre.KeyPress += SoloLetras_KeyPress;
            txtApellido.KeyPress += SoloLetras_KeyPress;

            txtNombre.TextChanged += NombreApellido_TextChanged;
            txtApellido.TextChanged += NombreApellido_TextChanged;

            // Restricciones para el código.
            txtCodigo.KeyPress += Codigo_KeyPress;
            txtCodigo.TextChanged += Codigo_TextChanged;

            // Restricciones para las notas.
            txtLaboratorio.KeyPress += Nota_KeyPress;
            txtParcial.KeyPress += Nota_KeyPress;
            txtAsistencia.KeyPress += Nota_KeyPress;

            btnGuardar.Click += btnGuardar_Click;

            btnCancelar.DialogResult = DialogResult.Cancel;
            this.CancelButton = btnCancelar;
        }

        private void CargarDatos()
        {
            txtNombre.Text = EstudianteEditado.Nombre;
            txtApellido.Text = EstudianteEditado.Apellido;
            txtCodigo.Text = EstudianteEditado.Codigo;

            txtLaboratorio.Text =
                EstudianteEditado.Laboratorio.ToString(
                    CultureInfo.InvariantCulture);

            txtParcial.Text =
                EstudianteEditado.Parcial.ToString(
                    CultureInfo.InvariantCulture);

            txtAsistencia.Text =
                EstudianteEditado.Asistencia.ToString(
                    CultureInfo.InvariantCulture);
        }

        // Permite únicamente letras y espacios.
        private void SoloLetras_KeyPress(
            object sender,
            KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar) ||
                char.IsLetter(e.KeyChar) ||
                char.IsWhiteSpace(e.KeyChar))
            {
                return;
            }

            e.Handled = true;

            MessageBox.Show(
                "Este campo solo permite letras y espacios.",
                "Dato no válido",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
        }

        // Elimina números y símbolos pegados en nombre o apellido.
        private void NombreApellido_TextChanged(
            object sender,
            EventArgs e)
        {
            TextBox caja = (TextBox)sender;
            string textoOriginal = caja.Text;
            string textoValido = "";

            foreach (char caracter in textoOriginal)
            {
                if (char.IsLetter(caracter) ||
                    char.IsWhiteSpace(caracter))
                {
                    textoValido += caracter;
                }
            }

            if (textoOriginal != textoValido)
            {
                int posicion = caja.SelectionStart;

                caja.Text = textoValido;

                caja.SelectionStart =
                    Math.Min(posicion, caja.Text.Length);
            }
        }

        // El código acepta letras y números, sin espacios ni símbolos.
        private void Codigo_KeyPress(
            object sender,
            KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar) ||
                char.IsLetterOrDigit(e.KeyChar))
            {
                return;
            }

            e.Handled = true;

            MessageBox.Show(
                "El código solo permite letras y números, sin espacios ni símbolos.",
                "Código no válido",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
        }

        // Elimina caracteres no permitidos si se pega un código.
        private void Codigo_TextChanged(object sender, EventArgs e)
        {
            TextBox caja = (TextBox)sender;
            string textoOriginal = caja.Text;
            string textoValido = "";

            foreach (char caracter in textoOriginal)
            {
                if (char.IsLetterOrDigit(caracter))
                {
                    textoValido += caracter;
                }
            }

            if (textoOriginal != textoValido)
            {
                int posicion = caja.SelectionStart;

                caja.Text = textoValido;

                caja.SelectionStart =
                    Math.Min(posicion, caja.Text.Length);
            }
        }

        // Permite números y un solo separador decimal.
        private void Nota_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox caja = (TextBox)sender;

            if (char.IsControl(e.KeyChar) ||
                char.IsDigit(e.KeyChar))
            {
                return;
            }

            if ((e.KeyChar == '.' || e.KeyChar == ',') &&
                !caja.Text.Contains(".") &&
                !caja.Text.Contains(","))
            {
                return;
            }

            e.Handled = true;

            MessageBox.Show(
                "Ingrese solamente números y un separador decimal.",
                "Dato no válido",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtApellido.Text) ||
                string.IsNullOrWhiteSpace(txtCodigo.Text) ||
                string.IsNullOrWhiteSpace(txtLaboratorio.Text) ||
                string.IsNullOrWhiteSpace(txtParcial.Text) ||
                string.IsNullOrWhiteSpace(txtAsistencia.Text))
            {
                MessageBox.Show(
                    "Complete todos los campos.",
                    "Campos obligatorios",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            // Validación adicional antes de guardar.
            if (!Regex.IsMatch(
                    txtNombre.Text.Trim(),
                    @"^[\p{L}\s]+$") ||
                !Regex.IsMatch(
                    txtApellido.Text.Trim(),
                    @"^[\p{L}\s]+$"))
            {
                MessageBox.Show(
                    "El nombre y el apellido solo deben contener letras y espacios.",
                    "Datos no válidos",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            if (!Regex.IsMatch(
                    txtCodigo.Text.Trim(),
                    @"^[\p{L}\p{N}]+$"))
            {
                MessageBox.Show(
                    "El código solo debe contener letras y números, sin espacios.",
                    "Código no válido",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            decimal laboratorio;
            decimal parcial;
            decimal asistencia;

            if (!LeerNota(txtLaboratorio.Text, out laboratorio) ||
                !LeerNota(txtParcial.Text, out parcial) ||
                !LeerNota(txtAsistencia.Text, out asistencia))
            {
                MessageBox.Show(
                    "Ingrese notas numéricas válidas.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            if (laboratorio < 0 || laboratorio > 10 ||
                parcial < 0 || parcial > 10 ||
                asistencia < 0 || asistencia > 10)
            {
                MessageBox.Show(
                    "Las notas deben estar entre 0.0 y 10.0.",
                    "Notas fuera de rango",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            EstudianteEditado.Nombre =
                txtNombre.Text.Trim().ToUpperInvariant();

            EstudianteEditado.Apellido =
                txtApellido.Text.Trim().ToUpperInvariant();

            EstudianteEditado.Codigo =
                txtCodigo.Text.Trim().ToUpperInvariant();

            EstudianteEditado.Laboratorio = laboratorio;
            EstudianteEditado.Parcial = parcial;
            EstudianteEditado.Asistencia = asistencia;

            EstudianteEditado.NotaFinal =
                laboratorio * 0.50m +
                parcial * 0.40m +
                asistencia * 0.10m;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        // Convierte el texto a decimal aceptando punto o coma.
        private bool LeerNota(string texto, out decimal nota)
        {
            texto = texto.Trim().Replace(',', '.');

            return decimal.TryParse(
                texto,
                NumberStyles.AllowDecimalPoint,
                CultureInfo.InvariantCulture,
                out nota);
        }
    }
}