namespace SistemaRegistroNotas
{
    partial class frmRegistrarNota
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlEncabezado = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.gbEstudiante = new System.Windows.Forms.GroupBox();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.lblApellido = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.gbNotas = new System.Windows.Forms.GroupBox();
            this.lblNotaFinal = new System.Windows.Forms.Label();
            this.txtAsistencia = new System.Windows.Forms.TextBox();
            this.txtParcial = new System.Windows.Forms.TextBox();
            this.txtLaboratorio = new System.Windows.Forms.TextBox();
            this.lblAsistencia = new System.Windows.Forms.Label();
            this.lblParcial = new System.Windows.Forms.Label();
            this.lblLaboratorio = new System.Windows.Forms.Label();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.dgvRegistro = new System.Windows.Forms.DataGridView();
            this.lblSubtitulo = new System.Windows.Forms.Label();
            this.pnlEncabezado.SuspendLayout();
            this.gbEstudiante.SuspendLayout();
            this.gbNotas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRegistro)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlEncabezado
            // 
            this.pnlEncabezado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.pnlEncabezado.Controls.Add(this.lblSubtitulo);
            this.pnlEncabezado.Controls.Add(this.lblTitulo);
            this.pnlEncabezado.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlEncabezado.Location = new System.Drawing.Point(0, 0);
            this.pnlEncabezado.Name = "pnlEncabezado";
            this.pnlEncabezado.Size = new System.Drawing.Size(846, 85);
            this.pnlEncabezado.TabIndex = 0;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(210, 13);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(398, 32);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "SISTEMA DE REGISTRO DE NOTAS";
            // 
            // gbEstudiante
            // 
            this.gbEstudiante.Controls.Add(this.txtCodigo);
            this.gbEstudiante.Controls.Add(this.txtApellido);
            this.gbEstudiante.Controls.Add(this.txtNombre);
            this.gbEstudiante.Controls.Add(this.lblCodigo);
            this.gbEstudiante.Controls.Add(this.lblApellido);
            this.gbEstudiante.Controls.Add(this.lblNombre);
            this.gbEstudiante.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbEstudiante.Location = new System.Drawing.Point(36, 106);
            this.gbEstudiante.Name = "gbEstudiante";
            this.gbEstudiante.Size = new System.Drawing.Size(310, 233);
            this.gbEstudiante.TabIndex = 1;
            this.gbEstudiante.TabStop = false;
            this.gbEstudiante.Text = "Datos del estudiante";
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(100, 151);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(178, 25);
            this.txtCodigo.TabIndex = 5;
            // 
            // txtApellido
            // 
            this.txtApellido.Location = new System.Drawing.Point(100, 95);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(178, 25);
            this.txtApellido.TabIndex = 4;
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(100, 41);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(178, 25);
            this.txtNombre.TabIndex = 3;
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Location = new System.Drawing.Point(26, 154);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(54, 17);
            this.lblCodigo.TabIndex = 2;
            this.lblCodigo.Text = "Código:";
            // 
            // lblApellido
            // 
            this.lblApellido.AutoSize = true;
            this.lblApellido.Location = new System.Drawing.Point(20, 95);
            this.lblApellido.Name = "lblApellido";
            this.lblApellido.Size = new System.Drawing.Size(60, 17);
            this.lblApellido.TabIndex = 1;
            this.lblApellido.Text = "Apellido:";
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(20, 41);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(61, 17);
            this.lblNombre.TabIndex = 0;
            this.lblNombre.Text = "Nombre:";
            // 
            // gbNotas
            // 
            this.gbNotas.Controls.Add(this.lblNotaFinal);
            this.gbNotas.Controls.Add(this.txtAsistencia);
            this.gbNotas.Controls.Add(this.txtParcial);
            this.gbNotas.Controls.Add(this.txtLaboratorio);
            this.gbNotas.Controls.Add(this.lblAsistencia);
            this.gbNotas.Controls.Add(this.lblParcial);
            this.gbNotas.Controls.Add(this.lblLaboratorio);
            this.gbNotas.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbNotas.Location = new System.Drawing.Point(417, 106);
            this.gbNotas.Name = "gbNotas";
            this.gbNotas.Size = new System.Drawing.Size(391, 233);
            this.gbNotas.TabIndex = 6;
            this.gbNotas.TabStop = false;
            this.gbNotas.Text = "Notas del estudiante";
            // 
            // lblNotaFinal
            // 
            this.lblNotaFinal.AutoSize = true;
            this.lblNotaFinal.Location = new System.Drawing.Point(36, 186);
            this.lblNotaFinal.Name = "lblNotaFinal";
            this.lblNotaFinal.Size = new System.Drawing.Size(98, 17);
            this.lblNotaFinal.TabIndex = 6;
            this.lblNotaFinal.Text = "Nota final: 0.00";
            // 
            // txtAsistencia
            // 
            this.txtAsistencia.Location = new System.Drawing.Point(155, 130);
            this.txtAsistencia.Name = "txtAsistencia";
            this.txtAsistencia.Size = new System.Drawing.Size(178, 25);
            this.txtAsistencia.TabIndex = 5;
            // 
            // txtParcial
            // 
            this.txtParcial.Location = new System.Drawing.Point(155, 79);
            this.txtParcial.Name = "txtParcial";
            this.txtParcial.Size = new System.Drawing.Size(178, 25);
            this.txtParcial.TabIndex = 4;
            // 
            // txtLaboratorio
            // 
            this.txtLaboratorio.Location = new System.Drawing.Point(155, 30);
            this.txtLaboratorio.Name = "txtLaboratorio";
            this.txtLaboratorio.Size = new System.Drawing.Size(178, 25);
            this.txtLaboratorio.TabIndex = 3;
            // 
            // lblAsistencia
            // 
            this.lblAsistencia.AutoSize = true;
            this.lblAsistencia.Location = new System.Drawing.Point(28, 130);
            this.lblAsistencia.Name = "lblAsistencia";
            this.lblAsistencia.Size = new System.Drawing.Size(106, 17);
            this.lblAsistencia.TabIndex = 2;
            this.lblAsistencia.Text = "Asistencia (10%):";
            // 
            // lblParcial
            // 
            this.lblParcial.AutoSize = true;
            this.lblParcial.Location = new System.Drawing.Point(49, 82);
            this.lblParcial.Name = "lblParcial";
            this.lblParcial.Size = new System.Drawing.Size(87, 17);
            this.lblParcial.TabIndex = 1;
            this.lblParcial.Text = "Parcial (40%):";
            // 
            // lblLaboratorio
            // 
            this.lblLaboratorio.AutoSize = true;
            this.lblLaboratorio.Location = new System.Drawing.Point(20, 33);
            this.lblLaboratorio.Name = "lblLaboratorio";
            this.lblLaboratorio.Size = new System.Drawing.Size(118, 17);
            this.lblLaboratorio.TabIndex = 0;
            this.lblLaboratorio.Text = "Laboratorio (50%):";
            // 
            // btnAgregar
            // 
            this.btnAgregar.BackColor = System.Drawing.Color.SeaGreen;
            this.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregar.Font = new System.Drawing.Font("Segoe UI Black", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregar.ForeColor = System.Drawing.Color.White;
            this.btnAgregar.Location = new System.Drawing.Point(236, 357);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(78, 30);
            this.btnAgregar.TabIndex = 7;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = false;
            // 
            // btnEditar
            // 
            this.btnEditar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnEditar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditar.Font = new System.Drawing.Font("Segoe UI Black", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditar.ForeColor = System.Drawing.Color.White;
            this.btnEditar.Location = new System.Drawing.Point(347, 357);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(78, 30);
            this.btnEditar.TabIndex = 8;
            this.btnEditar.Text = "Editar";
            this.btnEditar.UseVisualStyleBackColor = false;
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminar.Font = new System.Drawing.Font("Segoe UI Black", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar.ForeColor = System.Drawing.Color.White;
            this.btnEliminar.Location = new System.Drawing.Point(456, 357);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(78, 30);
            this.btnEliminar.TabIndex = 9;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = false;
            // 
            // dgvRegistro
            // 
            this.dgvRegistro.AllowUserToAddRows = false;
            this.dgvRegistro.AllowUserToDeleteRows = false;
            this.dgvRegistro.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRegistro.BackgroundColor = System.Drawing.Color.White;
            this.dgvRegistro.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRegistro.Location = new System.Drawing.Point(26, 404);
            this.dgvRegistro.MultiSelect = false;
            this.dgvRegistro.Name = "dgvRegistro";
            this.dgvRegistro.ReadOnly = true;
            this.dgvRegistro.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRegistro.Size = new System.Drawing.Size(782, 194);
            this.dgvRegistro.TabIndex = 10;
            this.dgvRegistro.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRegistro_CellDoubleClick);
            // 
            // lblSubtitulo
            // 
            this.lblSubtitulo.AutoSize = true;
            this.lblSubtitulo.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubtitulo.ForeColor = System.Drawing.Color.White;
            this.lblSubtitulo.Location = new System.Drawing.Point(283, 47);
            this.lblSubtitulo.Name = "lblSubtitulo";
            this.lblSubtitulo.Size = new System.Drawing.Size(261, 17);
            this.lblSubtitulo.TabIndex = 1;
            this.lblSubtitulo.Text = "Programación Orientada a Eventos (POE)";
            // 
            // frmRegistrarNota
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(846, 610);
            this.Controls.Add(this.dgvRegistro);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.gbNotas);
            this.Controls.Add(this.gbEstudiante);
            this.Controls.Add(this.pnlEncabezado);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRegistrarNota";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Crear Estudiante";
            this.pnlEncabezado.ResumeLayout(false);
            this.pnlEncabezado.PerformLayout();
            this.gbEstudiante.ResumeLayout(false);
            this.gbEstudiante.PerformLayout();
            this.gbNotas.ResumeLayout(false);
            this.gbNotas.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRegistro)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlEncabezado;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.GroupBox gbEstudiante;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.Label lblApellido;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.GroupBox gbNotas;
        private System.Windows.Forms.Label lblNotaFinal;
        private System.Windows.Forms.TextBox txtAsistencia;
        private System.Windows.Forms.TextBox txtParcial;
        private System.Windows.Forms.TextBox txtLaboratorio;
        private System.Windows.Forms.Label lblAsistencia;
        private System.Windows.Forms.Label lblParcial;
        private System.Windows.Forms.Label lblLaboratorio;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.DataGridView dgvRegistro;
        private System.Windows.Forms.Label lblSubtitulo;
    }
}

