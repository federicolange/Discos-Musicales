namespace WinformAppDiscos
{
    partial class frmAltaDisco
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblFecha = new System.Windows.Forms.Label();
            this.lblCantidadCanciones = new System.Windows.Forms.Label();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.txtTitulo = new System.Windows.Forms.TextBox();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.txtCantidadCanciones = new System.Windows.Forms.TextBox();
            this.lblEstilo = new System.Windows.Forms.Label();
            this.lblTipoEdicion = new System.Windows.Forms.Label();
            this.pbxAltaImagen = new System.Windows.Forms.PictureBox();
            this.cboEstilo = new System.Windows.Forms.ComboBox();
            this.cboTipoEdicion = new System.Windows.Forms.ComboBox();
            this.lblUrlImagen = new System.Windows.Forms.Label();
            this.txtUrlImagen = new System.Windows.Forms.TextBox();
            this.btnAgregarImagen = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbxAltaImagen)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Location = new System.Drawing.Point(12, 34);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(43, 16);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Titulo:";
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Location = new System.Drawing.Point(12, 68);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(142, 16);
            this.lblFecha.TabIndex = 1;
            this.lblFecha.Text = "Fecha de lanzamiento:";
            // 
            // lblCantidadCanciones
            // 
            this.lblCantidadCanciones.AutoSize = true;
            this.lblCantidadCanciones.Location = new System.Drawing.Point(12, 106);
            this.lblCantidadCanciones.Name = "lblCantidadCanciones";
            this.lblCantidadCanciones.Size = new System.Drawing.Size(148, 16);
            this.lblCantidadCanciones.TabIndex = 2;
            this.lblCantidadCanciones.Text = "Cantidad de canciones:";
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(194, 269);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(101, 28);
            this.btnAceptar.TabIndex = 4;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(372, 269);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(101, 28);
            this.btnCancelar.TabIndex = 5;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.button2_Click);
            // 
            // txtTitulo
            // 
            this.txtTitulo.Location = new System.Drawing.Point(174, 31);
            this.txtTitulo.Name = "txtTitulo";
            this.txtTitulo.Size = new System.Drawing.Size(226, 22);
            this.txtTitulo.TabIndex = 6;
            // 
            // dtpFecha
            // 
            this.dtpFecha.Location = new System.Drawing.Point(174, 63);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(226, 22);
            this.dtpFecha.TabIndex = 7;
            // 
            // txtCantidadCanciones
            // 
            this.txtCantidadCanciones.Location = new System.Drawing.Point(174, 103);
            this.txtCantidadCanciones.Name = "txtCantidadCanciones";
            this.txtCantidadCanciones.Size = new System.Drawing.Size(57, 22);
            this.txtCantidadCanciones.TabIndex = 8;
            // 
            // lblEstilo
            // 
            this.lblEstilo.AutoSize = true;
            this.lblEstilo.Location = new System.Drawing.Point(12, 180);
            this.lblEstilo.Name = "lblEstilo";
            this.lblEstilo.Size = new System.Drawing.Size(55, 16);
            this.lblEstilo.TabIndex = 9;
            this.lblEstilo.Text = "Genero:";
            // 
            // lblTipoEdicion
            // 
            this.lblTipoEdicion.AutoSize = true;
            this.lblTipoEdicion.Location = new System.Drawing.Point(12, 219);
            this.lblTipoEdicion.Name = "lblTipoEdicion";
            this.lblTipoEdicion.Size = new System.Drawing.Size(60, 16);
            this.lblTipoEdicion.TabIndex = 10;
            this.lblTipoEdicion.Text = "Formato:";
            // 
            // pbxAltaImagen
            // 
            this.pbxAltaImagen.Location = new System.Drawing.Point(452, 31);
            this.pbxAltaImagen.Name = "pbxAltaImagen";
            this.pbxAltaImagen.Size = new System.Drawing.Size(217, 209);
            this.pbxAltaImagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxAltaImagen.TabIndex = 13;
            this.pbxAltaImagen.TabStop = false;
            // 
            // cboEstilo
            // 
            this.cboEstilo.FormattingEnabled = true;
            this.cboEstilo.Location = new System.Drawing.Point(174, 177);
            this.cboEstilo.Name = "cboEstilo";
            this.cboEstilo.Size = new System.Drawing.Size(121, 24);
            this.cboEstilo.TabIndex = 14;
            // 
            // cboTipoEdicion
            // 
            this.cboTipoEdicion.FormattingEnabled = true;
            this.cboTipoEdicion.Location = new System.Drawing.Point(174, 216);
            this.cboTipoEdicion.Name = "cboTipoEdicion";
            this.cboTipoEdicion.Size = new System.Drawing.Size(121, 24);
            this.cboTipoEdicion.TabIndex = 15;
            // 
            // lblUrlImagen
            // 
            this.lblUrlImagen.AutoSize = true;
            this.lblUrlImagen.Location = new System.Drawing.Point(12, 140);
            this.lblUrlImagen.Name = "lblUrlImagen";
            this.lblUrlImagen.Size = new System.Drawing.Size(75, 16);
            this.lblUrlImagen.TabIndex = 16;
            this.lblUrlImagen.Text = "Url Imagen:";
            // 
            // txtUrlImagen
            // 
            this.txtUrlImagen.Location = new System.Drawing.Point(174, 137);
            this.txtUrlImagen.Name = "txtUrlImagen";
            this.txtUrlImagen.Size = new System.Drawing.Size(226, 22);
            this.txtUrlImagen.TabIndex = 17;
            this.txtUrlImagen.Leave += new System.EventHandler(this.txtUrlImagen_Leave);
            // 
            // btnAgregarImagen
            // 
            this.btnAgregarImagen.Location = new System.Drawing.Point(406, 133);
            this.btnAgregarImagen.Name = "btnAgregarImagen";
            this.btnAgregarImagen.Size = new System.Drawing.Size(27, 31);
            this.btnAgregarImagen.TabIndex = 18;
            this.btnAgregarImagen.Text = "+";
            this.btnAgregarImagen.UseVisualStyleBackColor = true;
            this.btnAgregarImagen.Click += new System.EventHandler(this.btnAgregarImagen_Click);
            // 
            // frmAltaDisco
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(707, 322);
            this.Controls.Add(this.btnAgregarImagen);
            this.Controls.Add(this.txtUrlImagen);
            this.Controls.Add(this.lblUrlImagen);
            this.Controls.Add(this.cboTipoEdicion);
            this.Controls.Add(this.cboEstilo);
            this.Controls.Add(this.pbxAltaImagen);
            this.Controls.Add(this.lblTipoEdicion);
            this.Controls.Add(this.lblEstilo);
            this.Controls.Add(this.txtCantidadCanciones);
            this.Controls.Add(this.dtpFecha);
            this.Controls.Add(this.txtTitulo);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.lblCantidadCanciones);
            this.Controls.Add(this.lblFecha);
            this.Controls.Add(this.lblTitulo);
            this.MaximizeBox = false;
            this.Name = "frmAltaDisco";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Agregar Disco";
            this.Load += new System.EventHandler(this.frmAltaDisco_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbxAltaImagen)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.Label lblCantidadCanciones;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.TextBox txtTitulo;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.TextBox txtCantidadCanciones;
        private System.Windows.Forms.Label lblEstilo;
        private System.Windows.Forms.Label lblTipoEdicion;
        private System.Windows.Forms.PictureBox pbxAltaImagen;
        private System.Windows.Forms.ComboBox cboEstilo;
        private System.Windows.Forms.ComboBox cboTipoEdicion;
        private System.Windows.Forms.Label lblUrlImagen;
        private System.Windows.Forms.TextBox txtUrlImagen;
        private System.Windows.Forms.Button btnAgregarImagen;
    }
}