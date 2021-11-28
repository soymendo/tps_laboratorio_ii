using Entidades.Archivos;
using Entidades.Clases_especializadas;
using Entidades.Clases_generales;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Formulario
{
    public partial class FormComparar : Form
    {
        Sistema sistem = new Sistema(1000);
        string ruta = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
       

        public FormComparar(Sistema sis)
        {
            InitializeComponent();
            Bitmap img = new Bitmap(Application.StartupPath + @"\img\FONDOHD4.jpg");
            this.BackgroundImage = img;
            this.sistem = sis;
           
            cmbPlacasLado1.DataSource = this.sistem.ListaDePlacasACargarLado1;
            cmbPlacasLado2.DataSource = this.sistem.ListaDePlacasACargarLado2;
            cmbComparar.DataSource = this.sistem.Comparaciones;
            rtbInfo.ReadOnly = true;
            rtbInfoPlaca1.ReadOnly = true;
            rtbInfoPlaca2.ReadOnly = true;
            
        }


        /// <summary>
        /// Boton para comparar los datos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnComparar_Click(object sender, EventArgs e)
        {
            if(cmbPlacasLado1.SelectedItem is null || cmbPlacasLado2.SelectedItem is null)
            {
                MessageBox.Show("Primero elija las placas a comparar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                int indice = sistem.Comparaciones.IndexOf((Comparar)cmbComparar.SelectedItem);

                rtbInfo.Text = sistem.Comparaciones[indice].Mostrar((PlacaVideo)cmbPlacasLado1.SelectedItem, (PlacaVideo)cmbPlacasLado2.SelectedItem);

                PlacaVideo p1 = (PlacaVideo)cmbPlacasLado1.SelectedItem;
                PlacaVideo p2 = (PlacaVideo)cmbPlacasLado2.SelectedItem;

                lblLado1.Text = p1.Nombre;
                lblLado2.Text = p2.Nombre;
               
                if (p1.Informar(sistem.Comparaciones[indice].ToString()) == "")
                {
                    rtbInfoPlaca1.Text = "Sin datos";
                }
                else
                {
                    rtbInfoPlaca1.Text = p1.Informar(sistem.Comparaciones[indice].ToString());
                }

                if (p2.Informar(sistem.Comparaciones[indice].ToString()) == "")
                {
                    rtbInfoPlaca2.Text = "Sin datos";
                }
                else
                {
                    rtbInfoPlaca2.Text = p2.Informar(sistem.Comparaciones[indice].ToString());
                }
            }
           
        }


        /// <summary>
        /// Boton que guarda un informa sobre los datos comparados en formato txt
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGuardarTxt_Click(object sender, EventArgs e)
        {

            if(rtbInfoPlaca1.Text=="")
            {
                MessageBox.Show("No hay datos para guardar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }else
            {
                Texto txt = new Texto();
                int indice = sistem.Comparaciones.IndexOf((Comparar)cmbComparar.SelectedItem);
                string nombreDeDato = sistem.Comparaciones[indice].ToString();
                txt.Datos = ($"{sistem.Comparaciones[indice].Mostrar((PlacaVideo)cmbPlacasLado1.SelectedItem, (PlacaVideo)cmbPlacasLado2.SelectedItem)}");

                try
                {
                    txt.Guardar(ruta + $".\\{nombreDeDato}.txt");
                    MessageBox.Show("Datos guardados!!");
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }


           
            
        }


        /// <summary>
        /// Boton que guarda un informe d elos datos en formato json
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnJson_Click(object sender, EventArgs e)
        {

            if (rtbInfoPlaca1.Text == "")
            {
                MessageBox.Show("No hay datos para guardar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string contenido;
                int indice = sistem.Comparaciones.IndexOf((Comparar)cmbComparar.SelectedItem);
                string nombreDeDato = sistem.Comparaciones[indice].ToString();
                contenido = ($"{sistem.Comparaciones[indice].Mostrar((PlacaVideo)cmbPlacasLado1.SelectedItem, (PlacaVideo)cmbPlacasLado2.SelectedItem)}");

                try
                {
                    sistem.Guardar(ruta + $".\\{nombreDeDato}.json",contenido);
                    MessageBox.Show("Datos guardados!!");
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
        }

        /// <summary>
        /// invalida el combobox para que no se pueda escribir en el .
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbPlacasLado1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        /// <summary>
        /// invalida el combobox para que no se pueda escribir en el .
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbComparar_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        /// <summary>
        /// invalida el combobox para que no se pueda escribir en el .
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbPlacasLado2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
    }
}
