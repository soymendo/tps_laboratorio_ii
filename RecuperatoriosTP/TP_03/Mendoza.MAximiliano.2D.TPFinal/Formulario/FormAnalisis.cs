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
    public partial class FormAnalisis : Form
    {
        Sistema sistem = new Sistema(1000);

        public FormAnalisis(Sistema sis)
        {
            InitializeComponent();
            Bitmap img = new Bitmap(Application.StartupPath + @"\img\FONDOHD5.jpg");
            this.BackgroundImage = img;
            this.sistem = sis;
            lsbListaDePlacas.DataSource = this.sistem.ListaDePlacasACargarLado1;
            cmbMarca.DataSource = Enum.GetValues(typeof(Marca.EMarca));
            cmbMemoria.DataSource= Enum.GetValues(typeof(PlacaVideo.ETipoMemoria));
            cmbPlacasSegunRam.DataSource = Enum.GetValues(typeof(Marca.EMarca));
            cmbSeguntTipo.DataSource= Enum.GetValues(typeof(PlacaVideo.ETipoMemoria));
            rtbMarca.ReadOnly = true;
            rtbMemoria.ReadOnly = true;
            rtbRam.ReadOnly = true;
            rtbConsumo.ReadOnly = true;
            rtbPlacasSegunRam.ReadOnly = true;
            rtbSegunTipo.ReadOnly = true;
        }

       /// <summary>
       /// boton que analiza datos segun la marca
       /// </summary>
       /// <param name="sender"></param>
       /// <param name="e"></param>

        private void btnMarca_Click(object sender, EventArgs e)
        {
            List<PlacaVideo> listaAnalisis = new List<PlacaVideo>();
            listaAnalisis = this.sistem.ListaDePlacasACargarLado1.FindAll((l) => l.Marca.MarcaProducto == (Marca.EMarca)cmbMarca.SelectedItem);
            rtbMarca.Text= this.sistem.AnalizarMarca((Marca.EMarca)cmbMarca.SelectedItem);

            lsbListaDePlacas.DataSource = null;
            lsbListaDePlacas.DataSource = listaAnalisis;
            lblNombreLista.Text = $"Placas segun marca {cmbMarca.SelectedItem.ToString()}";
        }


        /// <summary>
        /// boton que analiza datos segun el tipo de memoria
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            List<PlacaVideo> listaAnalisis = new List<PlacaVideo>();
            listaAnalisis = this.sistem.ListaDePlacasACargarLado1.FindAll((l) => l.TipoDeMemoria == (PlacaVideo.ETipoMemoria)cmbMemoria.SelectedItem);
            rtbMemoria.Text = this.sistem.AnalizarTipoMemoria((PlacaVideo.ETipoMemoria)cmbMemoria.SelectedItem);

            lsbListaDePlacas.DataSource = null;
            lsbListaDePlacas.DataSource = listaAnalisis;
            lblNombreLista.Text = $"Placas segun tipo de memoria {cmbMemoria.SelectedItem.ToString()}";
        }

        /// <summary>
        /// boton que analiza datos segun la capacidad de ram
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            List<PlacaVideo> listaAnalisis = new List<PlacaVideo>();
            string ram = "";

            if(cmbRam.SelectedItem is null)
            {
                MessageBox.Show("Debe selecciona una opcion", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {

                if (cmbRam.SelectedIndex == 0)
                {
                    listaAnalisis = this.sistem.ListaDePlacasACargarLado1.FindAll((l) => l.CapacidadDeRam >= 1 && l.CapacidadDeRam <= 4);
                    ram = "entre 1 y 4 gb inclusive";
                }
                if (cmbRam.SelectedIndex == 1)
                {
                    listaAnalisis = this.sistem.ListaDePlacasACargarLado1.FindAll((l) => l.CapacidadDeRam >= 4 && l.CapacidadDeRam <= 8);
                    ram = "entre 4 y 8 gb inclusive";
                }
                if (cmbRam.SelectedIndex == 2)
                {
                    listaAnalisis = this.sistem.ListaDePlacasACargarLado1.FindAll((l) => l.CapacidadDeRam >= 8 && l.CapacidadDeRam <= 16);
                    ram = "entre 8 y 16 gb inclusive";
                }
                if (cmbRam.SelectedIndex == 3)
                {
                    listaAnalisis = this.sistem.ListaDePlacasACargarLado1.FindAll((l) => l.CapacidadDeRam >= 16);
                    ram = "16gb o mas";
                }

                rtbRam.Text = this.sistem.AnalizarSegunRam(cmbRam.SelectedItem.ToString());

                lsbListaDePlacas.DataSource = null;
                lsbListaDePlacas.DataSource = listaAnalisis;
                lblNombreLista.Text = $"Placas segun ram  {ram}";
            }


        }

        /// <summary>
        /// boton que analiza datos segun el consumo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void button1_Click_1(object sender, EventArgs e)
        {
            List<PlacaVideo> listaAnalisis = new List<PlacaVideo>();
            string consumo = "";

            if (cmbConsumo.SelectedItem is null)
            {
                MessageBox.Show("Debe selecciona una opcion", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {

                if (cmbConsumo.SelectedIndex == 0)
                {
                    listaAnalisis = this.sistem.ListaDePlacasACargarLado1.FindAll((l) => l.Consumo >= 1 && l.Consumo <= 25);
                    consumo = "entre 1 y 25 W inclusive";
                }
                if (cmbConsumo.SelectedIndex == 1)
                {
                    listaAnalisis = this.sistem.ListaDePlacasACargarLado1.FindAll((l) => l.Consumo >= 25 && l.Consumo <= 50);
                    consumo = "entre 25 y 50 W inclusive";
                }
                if (cmbConsumo.SelectedIndex == 2)
                {
                    listaAnalisis = this.sistem.ListaDePlacasACargarLado1.FindAll((l) => l.Consumo >= 50 && l.Consumo <= 75);
                    consumo = "entre 50 y 75 W inclusive";
                }
                if (cmbConsumo.SelectedIndex == 3)
                {
                    listaAnalisis = this.sistem.ListaDePlacasACargarLado1.FindAll((l) => l.Consumo >= 75 && l.Consumo <= 100);
                    consumo = "entre 75 y 100 W inclusive";
                }
                if (cmbConsumo.SelectedIndex == 4)
                {
                    listaAnalisis = this.sistem.ListaDePlacasACargarLado1.FindAll((l) => l.Consumo >= 100);
                    consumo = "100 W o mas";
                }

                rtbConsumo.Text = this.sistem.AnalizarConsumo(cmbConsumo.SelectedItem.ToString());

                lsbListaDePlacas.DataSource = null;
                lsbListaDePlacas.DataSource = listaAnalisis;
                lblNombreLista.Text = $"Placas segun consumo  {consumo}";
            }


        }



        private void button1_Click_2(object sender, EventArgs e)
        {

            rtbPlacasSegunRam.Text = this.sistem.AnalizarPlacaSegunRam((Marca.EMarca)cmbPlacasSegunRam.SelectedItem);
            
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            rtbSegunTipo.Text = this.sistem.AnalizarConsumoSegunTipoDeMemoria((PlacaVideo.ETipoMemoria)cmbSeguntTipo.SelectedItem);
        }

        /// <summary>
        /// invalida el combobox para que no se pueda escribir
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        /// <summary>
        /// invalida el combobox para que no se pueda escribir
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        /// <summary>
        /// invalida el combobox para que no se pueda escribir
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        /// <summary>
        /// invalida el combobox para que no se pueda escribir
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbConsumo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }


        /// <summary>
        /// invalida el combobox para que no se pueda escribir
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBox1_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        /// <summary>
        /// invalida el combobox para que no se pueda escribir
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBox2_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
    }
}
