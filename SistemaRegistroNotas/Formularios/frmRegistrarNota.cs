using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using SistemaRegistroNotas.Clases;
using SistemaRegistroNotas.Repositorios;
using SistemaRegistroNotas.Formularios;

namespace SistemaRegistroNotas
{
    public partial class frmRegistrarNota : Form
    {
        private readonly RepoEstudiante repositorio = new RepoEstudiante();

        public frmRegistrarNota()
        {
            InitializeComponent();

            this.Load += frmRegistrarNota_Load;

            // Validaciones para las notas.
            txtLaboratorio.KeyPress += Nota_KeyPress;
            txtParcial.KeyPress += Nota_KeyPress;
            txtAsistencia.KeyPress += Nota_KeyPress;

            // Validaciones para los nombres.
            txtNombre.KeyPress += SoloLetras_KeyPress;
            txtApellido.KeyPress += SoloLetras_KeyPress;

            // Validación del código.
            txtCodigo.KeyPress += Codigo_KeyPress;

            // Evita caracteres no permitidos al pegar texto.
            txtNombre.TextChanged += NombreApellido_TextChanged;
            txtApellido.TextChanged += NombreApellido_TextChanged;
            txtCodigo.TextChanged += Codigo_TextChanged;

            txtLaboratorio.TextChanged += CalcularNotaFinal;
            txtParcial.TextChanged += CalcularNotaFinal;
            txtAsistencia.TextChanged += CalcularNotaFinal;

            btnAgregar.Click += btnAgregar_Click;
            btnEditar.Click += btnEditar_Click;
            btnEliminar.Click += btnEliminar_Click;
        }

        private void frmRegistrarNota_Load(object sender, EventArgs e)
        {
            LimpiarCampos();
            CargarEstudiantes();
        }

        private void CargarEstudiantes()
        {
            try
            {
                dgvRegistro.DataSource = repositorio.ObtenerTodos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No se pudieron cargar los estudiantes.\n\n" + ex.Message,
                    "Error de conexión",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // Permite letras y espacios en nombres y apellidos.
        private void SoloLetras_KeyPress(object sender, KeyPressEventArgs e)
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

        // Impide números y símbolos en nombres y apellidos,
        // incluso cuando se pegan desde el portapapeles.
        private void NombreApellido_TextChanged(object sender, EventArgs e)
        {
            TextBox caja = (TextBox)sender;
            string textoOriginal = caja.Text;
            string textoValido = "";

            foreach (char caracter in textoOriginal)
            {
                if (char.IsLetter(caracter) || char.IsWhiteSpace(caracter))
                {
                    textoValido += caracter;
                }
            }

            if (textoOriginal != textoValido)
            {
                int posicion = caja.SelectionStart;
                caja.Text = textoValido;
                caja.SelectionStart = Math.Min(posicion, caja.Text.Length);
            }
        }

        // El código permite letras y números, sin espacios ni símbolos.
        private void Codigo_KeyPress(object sender, KeyPressEventArgs e)
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

        // También limpia caracteres no permitidos si se pega un código.
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
                caja.SelectionStart = Math.Min(posicion, caja.Text.Length);
            }
        }

        // Permite números y un solo separador decimal.
        private void Nota_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox caja = (TextBox)sender;

            if (char.IsControl(e.KeyChar) || char.IsDigit(e.KeyChar))
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

        // Calcula la nota final mientras se escriben las notas.
        private void CalcularNotaFinal(object sender, EventArgs e)
        {
            decimal laboratorio;
            decimal parcial;
            decimal asistencia;

            if (IntentarLeerNota(txtLaboratorio.Text, out laboratorio) &&
                IntentarLeerNota(txtParcial.Text, out parcial) &&
                IntentarLeerNota(txtAsistencia.Text, out asistencia))
            {
                decimal notaFinal =
                    laboratorio * 0.50m +
                    parcial * 0.40m +
                    asistencia * 0.10m;

                lblNotaFinal.Text =
                    "Nota final: " + notaFinal.ToString("0.00");
            }
            else
            {
                lblNotaFinal.Text = "Nota final: 0.00";
            }
        }

        private bool IntentarLeerNota(string texto, out decimal nota)
        {
            texto = texto.Trim().Replace(',', '.');

            return decimal.TryParse(
                texto,
                NumberStyles.AllowDecimalPoint,
                CultureInfo.InvariantCulture,
                out nota);
        }

        // Comprueba todos los campos antes de guardar o actualizar.
        private bool ValidarDatos(
            out decimal laboratorio,
            out decimal parcial,
            out decimal asistencia)
        {
            laboratorio = 0;
            parcial = 0;
            asistencia = 0;

            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtApellido.Text) ||
                string.IsNullOrWhiteSpace(txtCodigo.Text) ||
                string.IsNullOrWhiteSpace(txtLaboratorio.Text) ||
                string.IsNullOrWhiteSpace(txtParcial.Text) ||
                string.IsNullOrWhiteSpace(txtAsistencia.Text))
            {
                MessageBox.Show(
                    "Complete todos los campos antes de continuar.",
                    "Campos obligatorios",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return false;
            }

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

                return false;
            }

            if (!Regex.IsMatch(txtCodigo.Text.Trim(), @"^[\p{L}\p{N}]+$"))
            {
                MessageBox.Show(
                    "El código solo debe contener letras y números, sin espacios.",
                    "Código no válido",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return false;
            }

            if (!IntentarLeerNota(txtLaboratorio.Text, out laboratorio) ||
                !IntentarLeerNota(txtParcial.Text, out parcial) ||
                !IntentarLeerNota(txtAsistencia.Text, out asistencia))
            {
                MessageBox.Show(
                    "Ingrese notas numéricas válidas.",
                    "Error en las notas",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return false;
            }

            if (laboratorio < 0 || laboratorio > 10 ||
                parcial < 0 || parcial > 10 ||
                asistencia < 0 || asistencia > 10)
            {
                MessageBox.Show(
                    "Cada nota debe estar entre 0.0 y 10.0.",
                    "Notas fuera de rango",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return false;
            }

            return true;
        }

        // Guarda un estudiante nuevo.
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            decimal laboratorio;
            decimal parcial;
            decimal asistencia;

            if (!ValidarDatos(
                out laboratorio,
                out parcial,
                out asistencia))
            {
                return;
            }

            decimal notaFinal =
                laboratorio * 0.50m +
                parcial * 0.40m +
                asistencia * 0.10m;

            Estudiante estudiante = new Estudiante
            {
                Nombre = txtNombre.Text.Trim().ToUpperInvariant(),
                Apellido = txtApellido.Text.Trim().ToUpperInvariant(),
                Codigo = txtCodigo.Text.Trim().ToUpperInvariant(),
                Laboratorio = laboratorio,
                Parcial = parcial,
                Asistencia = asistencia,
                NotaFinal = notaFinal
            };

            try
            {
                repositorio.Agregar(estudiante);

                MessageBox.Show(
                    "El estudiante se guardó correctamente.",
                    "Registro guardado",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                LimpiarCampos();
                CargarEstudiantes();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No se pudo guardar el estudiante.\n\n" + ex.Message,
                    "Error al guardar",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // Abre el formulario para editar al estudiante seleccionado.
        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvRegistro.CurrentRow == null ||
                dgvRegistro.CurrentRow.IsNewRow)
            {
                MessageBox.Show(
                    "Seleccione un estudiante de la tabla.",
                    "Sin selección",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            Estudiante estudiante =
                dgvRegistro.CurrentRow.DataBoundItem as Estudiante;

            if (estudiante == null)
            {
                MessageBox.Show(
                    "No se pudieron obtener los datos del estudiante seleccionado.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }

            Estudiante copia = new Estudiante
            {
                IdEstudiante = estudiante.IdEstudiante,
                Nombre = estudiante.Nombre,
                Apellido = estudiante.Apellido,
                Codigo = estudiante.Codigo,
                Laboratorio = estudiante.Laboratorio,
                Parcial = estudiante.Parcial,
                Asistencia = estudiante.Asistencia,
                NotaFinal = estudiante.NotaFinal
            };

            using (frmRegistrarNotaCmd formulario =
                   new frmRegistrarNotaCmd(copia))
            {
                if (formulario.ShowDialog(this) == DialogResult.OK)
                {
                    try
                    {
                        repositorio.Actualizar(
                            formulario.EstudianteEditado);

                        MessageBox.Show(
                            "Los cambios se guardaron correctamente.",
                            "Estudiante actualizado",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);

                        CargarEstudiantes();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(
                            "No se pudieron guardar los cambios.\n\n" + ex.Message,
                            "Error al actualizar",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                }
            }
        }

        // Elimina el estudiante seleccionado después de confirmar.
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvRegistro.CurrentRow == null ||
                dgvRegistro.CurrentRow.IsNewRow)
            {
                MessageBox.Show(
                    "Seleccione un estudiante de la tabla.",
                    "Sin selección",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            Estudiante estudiante =
                dgvRegistro.CurrentRow.DataBoundItem as Estudiante;

            if (estudiante == null)
            {
                MessageBox.Show(
                    "No se pudieron obtener los datos del estudiante.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }

            DialogResult respuesta = MessageBox.Show(
                "¿Está seguro de que desea eliminar al estudiante " +
                estudiante.Nombre + " " + estudiante.Apellido + "?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (respuesta != DialogResult.Yes)
                return;

            try
            {
                repositorio.Eliminar(estudiante.IdEstudiante);

                MessageBox.Show(
                    "El estudiante se eliminó correctamente.",
                    "Registro eliminado",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                LimpiarCampos();
                CargarEstudiantes();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No se pudo eliminar el estudiante.\n\n" + ex.Message,
                    "Error al eliminar",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // Limpia los campos para registrar otro estudiante.
        private void LimpiarCampos()
        {
            txtNombre.Clear();
            txtApellido.Clear();
            txtCodigo.Clear();
            txtLaboratorio.Clear();
            txtParcial.Clear();
            txtAsistencia.Clear();

            lblNotaFinal.Text = "Nota final: 0.00";

            txtNombre.Focus();
        }

        private void dgvRegistro_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            dgvRegistro.CurrentCell =
                dgvRegistro.Rows[e.RowIndex].Cells[e.ColumnIndex];

            btnEditar_Click(sender, EventArgs.Empty);
        }
    }
}