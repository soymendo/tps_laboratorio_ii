
namespace Formulario
{
    partial class FormComparar
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
            this.cmbPlacasLado1 = new System.Windows.Forms.ComboBox();
            this.cmbComparar = new System.Windows.Forms.ComboBox();
            this.btnComparar = new System.Windows.Forms.Button();
            this.rtbInfo = new System.Windows.Forms.RichTextBox();
            this.cmbPlacasLado2 = new System.Windows.Forms.ComboBox();
            this.btnGuardarTxt = new System.Windows.Forms.Button();
            this.rtbInfoPlaca1 = new System.Windows.Forms.RichTextBox();
            this.rtbInfoPlaca2 = new System.Windows.Forms.RichTextBox();
            this.lblNombrelado1 = new System.Windows.Forms.Label();
            this.lblNombreLado2 = new System.Windows.Forms.Label();
            this.btnJson = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmbPlacasLado1
            // 
            this.cmbPlacasLado1.FormattingEnabled = true;
            this.cmbPlacasLado1.Location = new System.Drawing.Point(12, 28);
            this.cmbPlacasLado1.Name = "cmbPlacasLado1";
            this.cmbPlacasLado1.Size = new System.Drawing.Size(195, 23);
            this.cmbPlacasLado1.TabIndex = 0;
            // 
            // cmbComparar
            // 
            this.cmbComparar.FormattingEnabled = true;
            this.cmbComparar.Location = new System.Drawing.Point(274, 28);
            this.cmbComparar.Name = "cmbComparar";
            this.cmbComparar.Size = new System.Drawing.Size(195, 23);
            this.cmbComparar.TabIndex = 1;
            // 
            // btnComparar
            // 
            this.btnComparar.Location = new System.Drawing.Point(475, 28);
            this.btnComparar.Name = "btnComparar";
            this.btnComparar.Size = new System.Drawing.Size(86, 50);
            this.btnComparar.TabIndex = 3;
            this.btnComparar.Text = "Comparar";
            this.btnComparar.UseVisualStyleBackColor = true;
            this.btnComparar.Click += new System.EventHandler(this.btnComparar_Click);
            // 
            // rtbInfo
            // 
            this.rtbInfo.BackColor = System.Drawing.Color.AliceBlue;
            this.rtbInfo.Location = new System.Drawing.Point(12, 143);
            this.rtbInfo.Name = "rtbInfo";
            this.rtbInfo.Size = new System.Drawing.Size(302, 256);
            this.rtbInfo.TabIndex = 4;
            this.rtbInfo.Text = "";
            // 
            // cmbPlacasLado2
            // 
            this.cmbPlacasLado2.FormattingEnabled = true;
            this.cmbPlacasLado2.Location = new System.Drawing.Point(581, 28);
            this.cmbPlacasLado2.Name = "cmbPlacasLado2";
            this.cmbPlacasLado2.Size = new System.Drawing.Size(195, 23);
            this.cmbPlacasLado2.TabIndex = 5;
            // 
            // btnGuardarTxt
            // 
            this.btnGuardarTxt.Location = new System.Drawing.Point(12, 405);
            this.btnGuardarTxt.Name = "btnGuardarTxt";
            this.btnGuardarTxt.Size = new System.Drawing.Size(112, 33);
            this.btnGuardarTxt.TabIndex = 6;
            this.btnGuardarTxt.Text = "Guardar Info txt";
            this.btnGuardarTxt.UseVisualStyleBackColor = true;
            this.btnGuardarTxt.Click += new System.EventHandler(this.btnGuardarTxt_Click);
            // 
            // rtbInfoPlaca1
            // 
            this.rtbInfoPlaca1.BackColor = System.Drawing.Color.AliceBlue;
            this.rtbInfoPlaca1.Location = new System.Drawing.Point(349, 143);
            this.rtbInfoPlaca1.Name = "rtbInfoPlaca1";
            this.rtbInfoPlaca1.Size = new System.Drawing.Size(189, 256);
            this.rtbInfoPlaca1.TabIndex = 7;
            this.rtbInfoPlaca1.Text = "";
            // 
            // rtbInfoPlaca2
            // 
            this.rtbInfoPlaca2.BackColor = System.Drawing.Color.AliceBlue;
            this.rtbInfoPlaca2.Location = new System.Drawing.Point(566, 143);
            this.rtbInfoPlaca2.Name = "rtbInfoPlaca2";
            this.rtbInfoPlaca2.Size = new System.Drawing.Size(189, 256);
            this.rtbInfoPlaca2.TabIndex = 8;
            this.rtbInfoPlaca2.Text = "";
            // 
            // lblNombrelado1
            // 
            this.lblNombrelado1.AutoSize = true;
            this.lblNombrelado1.Location = new System.Drawing.Point(349, 110);
            this.lblNombrelado1.Name = "lblNombrelado1";
            this.lblNombrelado1.Size = new System.Drawing.Size(0, 15);
            this.lblNombrelado1.TabIndex = 9;
            // 
            // lblNombreLado2
            // 
            this.lblNombreLado2.AutoSize = true;
            this.lblNombreLado2.Location = new System.Drawing.Point(566, 110);
            this.lblNombreLado2.Name = "lblNombreLado2";
            this.lblNombreLado2.Size = new System.Drawing.Size(0, 15);
            this.lblNombreLado2.TabIndex = 10;
            // 
            // btnJson
            // 
            this.btnJson.Location = new System.Drawing.Point(202, 405);
            this.btnJson.Name = "btnJson";
            this.btnJson.Size = new System.Drawing.Size(112, 33);
            this.btnJson.TabIndex = 11;
            this.btnJson.Text = "Guardar Info Json";
            this.btnJson.UseVisualStyleBackColor = true;
            this.btnJson.Click += new System.EventHandler(this.btnJson_Click);
            // 
            // FormComparar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSalmon;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnJson);
            this.Controls.Add(this.lblNombreLado2);
            this.Controls.Add(this.lblNombrelado1);
            this.Controls.Add(this.rtbInfoPlaca2);
            this.Controls.Add(this.rtbInfoPlaca1);
            this.Controls.Add(this.btnGuardarTxt);
            this.Controls.Add(this.cmbPlacasLado2);
            this.Controls.Add(this.rtbInfo);
            this.Controls.Add(this.btnComparar);
            this.Controls.Add(this.cmbComparar);
            this.Controls.Add(this.cmbPlacasLado1);
            this.Name = "FormComparar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormComparar";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbPlacasLado1;
        private System.Windows.Forms.ComboBox cmbComparar;
        private System.Windows.Forms.Button btnComparar;
        private System.Windows.Forms.RichTextBox rtbInfo;
        private System.Windows.Forms.ComboBox cmbPlacasLado2;
        private System.Windows.Forms.Button btnGuardarTxt;
        private System.Windows.Forms.RichTextBox rtbInfoPlaca1;
        private System.Windows.Forms.RichTextBox rtbInfoPlaca2;
        private System.Windows.Forms.Label lblNombrelado1;
        private System.Windows.Forms.Label lblNombreLado2;
        private System.Windows.Forms.Button btnJson;
    }
}