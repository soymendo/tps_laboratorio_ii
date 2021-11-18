
namespace Formulario
{
    partial class FormAnalisis
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
            this.lsbListaDePlacas = new System.Windows.Forms.ListBox();
            this.rtbMarca = new System.Windows.Forms.RichTextBox();
            this.lblMarca = new System.Windows.Forms.Label();
            this.cmbMarca = new System.Windows.Forms.ComboBox();
            this.btnMarca = new System.Windows.Forms.Button();
            this.lblNombreLista = new System.Windows.Forms.Label();
            this.btnMemoria = new System.Windows.Forms.Button();
            this.cmbMemoria = new System.Windows.Forms.ComboBox();
            this.lblMemoria = new System.Windows.Forms.Label();
            this.rtbMemoria = new System.Windows.Forms.RichTextBox();
            this.btnRam = new System.Windows.Forms.Button();
            this.cmbRam = new System.Windows.Forms.ComboBox();
            this.lblRam = new System.Windows.Forms.Label();
            this.rtbRam = new System.Windows.Forms.RichTextBox();
            this.btnConsumo = new System.Windows.Forms.Button();
            this.cmbConsumo = new System.Windows.Forms.ComboBox();
            this.lblConsumo = new System.Windows.Forms.Label();
            this.rtbConsumo = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // lsbListaDePlacas
            // 
            this.lsbListaDePlacas.FormattingEnabled = true;
            this.lsbListaDePlacas.ItemHeight = 15;
            this.lsbListaDePlacas.Location = new System.Drawing.Point(12, 19);
            this.lsbListaDePlacas.Name = "lsbListaDePlacas";
            this.lsbListaDePlacas.Size = new System.Drawing.Size(203, 304);
            this.lsbListaDePlacas.TabIndex = 0;
            // 
            // rtbMarca
            // 
            this.rtbMarca.Location = new System.Drawing.Point(263, 59);
            this.rtbMarca.Name = "rtbMarca";
            this.rtbMarca.Size = new System.Drawing.Size(406, 35);
            this.rtbMarca.TabIndex = 1;
            this.rtbMarca.Text = "";
            // 
            // lblMarca
            // 
            this.lblMarca.AutoSize = true;
            this.lblMarca.Location = new System.Drawing.Point(263, 38);
            this.lblMarca.Name = "lblMarca";
            this.lblMarca.Size = new System.Drawing.Size(120, 15);
            this.lblMarca.TabIndex = 2;
            this.lblMarca.Text = "Analizar segun marca";
            // 
            // cmbMarca
            // 
            this.cmbMarca.FormattingEnabled = true;
            this.cmbMarca.Location = new System.Drawing.Point(444, 30);
            this.cmbMarca.Name = "cmbMarca";
            this.cmbMarca.Size = new System.Drawing.Size(121, 23);
            this.cmbMarca.TabIndex = 3;
            this.cmbMarca.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.comboBox1_KeyPress);
            // 
            // btnMarca
            // 
            this.btnMarca.Location = new System.Drawing.Point(594, 30);
            this.btnMarca.Name = "btnMarca";
            this.btnMarca.Size = new System.Drawing.Size(75, 23);
            this.btnMarca.TabIndex = 4;
            this.btnMarca.Text = "Analizar";
            this.btnMarca.UseVisualStyleBackColor = true;
            this.btnMarca.Click += new System.EventHandler(this.btnMarca_Click);
            // 
            // lblNombreLista
            // 
            this.lblNombreLista.AutoSize = true;
            this.lblNombreLista.Location = new System.Drawing.Point(12, 1);
            this.lblNombreLista.Name = "lblNombreLista";
            this.lblNombreLista.Size = new System.Drawing.Size(136, 15);
            this.lblNombreLista.TabIndex = 5;
            this.lblNombreLista.Text = "Lista de placas cargadas:";
            // 
            // btnMemoria
            // 
            this.btnMemoria.Location = new System.Drawing.Point(594, 110);
            this.btnMemoria.Name = "btnMemoria";
            this.btnMemoria.Size = new System.Drawing.Size(75, 23);
            this.btnMemoria.TabIndex = 9;
            this.btnMemoria.Text = "Analizar";
            this.btnMemoria.UseVisualStyleBackColor = true;
            this.btnMemoria.Click += new System.EventHandler(this.button1_Click);
            // 
            // cmbMemoria
            // 
            this.cmbMemoria.FormattingEnabled = true;
            this.cmbMemoria.Location = new System.Drawing.Point(444, 110);
            this.cmbMemoria.Name = "cmbMemoria";
            this.cmbMemoria.Size = new System.Drawing.Size(121, 23);
            this.cmbMemoria.TabIndex = 8;
            this.cmbMemoria.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.comboBox2_KeyPress);
            // 
            // lblMemoria
            // 
            this.lblMemoria.AutoSize = true;
            this.lblMemoria.Location = new System.Drawing.Point(263, 118);
            this.lblMemoria.Name = "lblMemoria";
            this.lblMemoria.Size = new System.Drawing.Size(175, 15);
            this.lblMemoria.TabIndex = 7;
            this.lblMemoria.Text = "Analizar segun tipo de memoria";
            // 
            // rtbMemoria
            // 
            this.rtbMemoria.Location = new System.Drawing.Point(263, 140);
            this.rtbMemoria.Name = "rtbMemoria";
            this.rtbMemoria.Size = new System.Drawing.Size(406, 35);
            this.rtbMemoria.TabIndex = 6;
            this.rtbMemoria.Text = "";
            // 
            // btnRam
            // 
            this.btnRam.Location = new System.Drawing.Point(594, 188);
            this.btnRam.Name = "btnRam";
            this.btnRam.Size = new System.Drawing.Size(75, 23);
            this.btnRam.TabIndex = 13;
            this.btnRam.Text = "Analizar";
            this.btnRam.UseVisualStyleBackColor = true;
            this.btnRam.Click += new System.EventHandler(this.button2_Click);
            // 
            // cmbRam
            // 
            this.cmbRam.FormattingEnabled = true;
            this.cmbRam.Items.AddRange(new object[] {
            "entre 1 y 4 gb inclusive",
            "entre 4 y 8 gb inclusive",
            "entre 8 y 16 gb inclusive",
            "16gb o mas"});
            this.cmbRam.Location = new System.Drawing.Point(453, 188);
            this.cmbRam.Name = "cmbRam";
            this.cmbRam.Size = new System.Drawing.Size(135, 23);
            this.cmbRam.TabIndex = 12;
            this.cmbRam.Text = "Elija opcion";
            this.cmbRam.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.comboBox3_KeyPress);
            // 
            // lblRam
            // 
            this.lblRam.AutoSize = true;
            this.lblRam.Location = new System.Drawing.Point(263, 196);
            this.lblRam.Name = "lblRam";
            this.lblRam.Size = new System.Drawing.Size(184, 15);
            this.lblRam.TabIndex = 11;
            this.lblRam.Text = "Analizar segun capacidad de Ram";
            // 
            // rtbRam
            // 
            this.rtbRam.Location = new System.Drawing.Point(263, 218);
            this.rtbRam.Name = "rtbRam";
            this.rtbRam.Size = new System.Drawing.Size(406, 35);
            this.rtbRam.TabIndex = 10;
            this.rtbRam.Text = "";
            // 
            // btnConsumo
            // 
            this.btnConsumo.Location = new System.Drawing.Point(594, 261);
            this.btnConsumo.Name = "btnConsumo";
            this.btnConsumo.Size = new System.Drawing.Size(75, 23);
            this.btnConsumo.TabIndex = 17;
            this.btnConsumo.Text = "Analizar";
            this.btnConsumo.UseVisualStyleBackColor = true;
            this.btnConsumo.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // cmbConsumo
            // 
            this.cmbConsumo.FormattingEnabled = true;
            this.cmbConsumo.Items.AddRange(new object[] {
            "entre 1 y 25 W inclusive",
            "entre 25 y 50 W inclusive",
            "entre 50 y 75 W inclusive",
            "entre 75 y 100 W inclusive",
            "100 W o mas"});
            this.cmbConsumo.Location = new System.Drawing.Point(453, 261);
            this.cmbConsumo.Name = "cmbConsumo";
            this.cmbConsumo.Size = new System.Drawing.Size(135, 23);
            this.cmbConsumo.TabIndex = 16;
            this.cmbConsumo.Text = "Elija opcion";
            this.cmbConsumo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbConsumo_KeyPress);
            // 
            // lblConsumo
            // 
            this.lblConsumo.AutoSize = true;
            this.lblConsumo.Location = new System.Drawing.Point(263, 269);
            this.lblConsumo.Name = "lblConsumo";
            this.lblConsumo.Size = new System.Drawing.Size(139, 15);
            this.lblConsumo.TabIndex = 15;
            this.lblConsumo.Text = "Analizar segun Consumo";
            // 
            // rtbConsumo
            // 
            this.rtbConsumo.Location = new System.Drawing.Point(263, 287);
            this.rtbConsumo.Name = "rtbConsumo";
            this.rtbConsumo.Size = new System.Drawing.Size(406, 35);
            this.rtbConsumo.TabIndex = 14;
            this.rtbConsumo.Text = "";
            // 
            // FormAnalisis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(698, 336);
            this.Controls.Add(this.btnConsumo);
            this.Controls.Add(this.cmbConsumo);
            this.Controls.Add(this.lblConsumo);
            this.Controls.Add(this.rtbConsumo);
            this.Controls.Add(this.btnRam);
            this.Controls.Add(this.cmbRam);
            this.Controls.Add(this.lblRam);
            this.Controls.Add(this.rtbRam);
            this.Controls.Add(this.btnMemoria);
            this.Controls.Add(this.cmbMemoria);
            this.Controls.Add(this.lblMemoria);
            this.Controls.Add(this.rtbMemoria);
            this.Controls.Add(this.lblNombreLista);
            this.Controls.Add(this.btnMarca);
            this.Controls.Add(this.cmbMarca);
            this.Controls.Add(this.lblMarca);
            this.Controls.Add(this.rtbMarca);
            this.Controls.Add(this.lsbListaDePlacas);
            this.Name = "FormAnalisis";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Analisis";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lsbListaDePlacas;
        private System.Windows.Forms.RichTextBox rtbMarca;
        private System.Windows.Forms.Label lblMarca;
        private System.Windows.Forms.ComboBox cmbMarca;
        private System.Windows.Forms.Button btnMarca;
        private System.Windows.Forms.Label lblNombreLista;
        private System.Windows.Forms.Button btnMemoria;
        private System.Windows.Forms.ComboBox cmbMemoria;
        private System.Windows.Forms.Label lblMemoria;
        private System.Windows.Forms.RichTextBox rtbMemoria;
        private System.Windows.Forms.Button btnRam;
        private System.Windows.Forms.ComboBox cmbRam;
        private System.Windows.Forms.Label lblRam;
        private System.Windows.Forms.RichTextBox rtbRam;
        private System.Windows.Forms.Button btnConsumo;
        private System.Windows.Forms.ComboBox cmbConsumo;
        private System.Windows.Forms.Label lblConsumo;
        private System.Windows.Forms.RichTextBox rtbConsumo;
    }
}