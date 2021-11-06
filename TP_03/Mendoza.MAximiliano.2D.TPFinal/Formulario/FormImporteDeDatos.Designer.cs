
namespace Formulario
{
    partial class FormImporteDeDatos
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
            this.btnCargar = new System.Windows.Forms.Button();
            this.btnAgregarLista = new System.Windows.Forms.Button();
            this.rtbInfoDatosCargados = new System.Windows.Forms.RichTextBox();
            this.lstListaDePlacas = new System.Windows.Forms.ListBox();
            this.lblLista = new System.Windows.Forms.Label();
            this.lblDatos = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnCargar
            // 
            this.btnCargar.Location = new System.Drawing.Point(77, 344);
            this.btnCargar.Name = "btnCargar";
            this.btnCargar.Size = new System.Drawing.Size(115, 50);
            this.btnCargar.TabIndex = 0;
            this.btnCargar.Text = "Cargar";
            this.btnCargar.UseVisualStyleBackColor = true;
            this.btnCargar.Click += new System.EventHandler(this.btnCargar_Click);
            // 
            // btnAgregarLista
            // 
            this.btnAgregarLista.Location = new System.Drawing.Point(493, 316);
            this.btnAgregarLista.Name = "btnAgregarLista";
            this.btnAgregarLista.Size = new System.Drawing.Size(201, 78);
            this.btnAgregarLista.TabIndex = 1;
            this.btnAgregarLista.Text = "Agregar a la lista";
            this.btnAgregarLista.UseVisualStyleBackColor = true;
            this.btnAgregarLista.Click += new System.EventHandler(this.btnAgregarLista_Click);
            // 
            // rtbInfoDatosCargados
            // 
            this.rtbInfoDatosCargados.BackColor = System.Drawing.Color.Azure;
            this.rtbInfoDatosCargados.Location = new System.Drawing.Point(77, 60);
            this.rtbInfoDatosCargados.Name = "rtbInfoDatosCargados";
            this.rtbInfoDatosCargados.Size = new System.Drawing.Size(330, 256);
            this.rtbInfoDatosCargados.TabIndex = 2;
            this.rtbInfoDatosCargados.Text = "";
            // 
            // lstListaDePlacas
            // 
            this.lstListaDePlacas.BackColor = System.Drawing.Color.Azure;
            this.lstListaDePlacas.FormattingEnabled = true;
            this.lstListaDePlacas.ItemHeight = 15;
            this.lstListaDePlacas.Location = new System.Drawing.Point(493, 60);
            this.lstListaDePlacas.Name = "lstListaDePlacas";
            this.lstListaDePlacas.Size = new System.Drawing.Size(201, 229);
            this.lstListaDePlacas.TabIndex = 3;
            // 
            // lblLista
            // 
            this.lblLista.AutoSize = true;
            this.lblLista.BackColor = System.Drawing.SystemColors.ControlLight;
            this.lblLista.Location = new System.Drawing.Point(493, 31);
            this.lblLista.Name = "lblLista";
            this.lblLista.Size = new System.Drawing.Size(139, 15);
            this.lblLista.TabIndex = 4;
            this.lblLista.Text = "Lista de placas cargadas :";
            // 
            // lblDatos
            // 
            this.lblDatos.AutoSize = true;
            this.lblDatos.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblDatos.Location = new System.Drawing.Point(77, 31);
            this.lblDatos.Name = "lblDatos";
            this.lblDatos.Size = new System.Drawing.Size(105, 15);
            this.lblDatos.TabIndex = 5;
            this.lblDatos.Text = "Datos de la placa : ";
            // 
            // FormImporteDeDatos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CadetBlue;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblDatos);
            this.Controls.Add(this.lblLista);
            this.Controls.Add(this.lstListaDePlacas);
            this.Controls.Add(this.rtbInfoDatosCargados);
            this.Controls.Add(this.btnAgregarLista);
            this.Controls.Add(this.btnCargar);
            this.Name = "FormImporteDeDatos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormImporteDeDatos";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCargar;
        private System.Windows.Forms.Button btnAgregarLista;
        private System.Windows.Forms.RichTextBox rtbInfoDatosCargados;
        private System.Windows.Forms.ListBox lstListaDePlacas;
        private System.Windows.Forms.Label lblLista;
        private System.Windows.Forms.Label lblDatos;
    }
}