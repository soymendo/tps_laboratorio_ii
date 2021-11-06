using Entidades.Archivos;
using Entidades.Clases_especializadas;
using Entidades.Clases_generales;
using Entidades.Exepciones;
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
    public partial class FormImporteDeDatos : Form
    {
        Sistema sistem = new Sistema(1000);
        private OpenFileDialog openFileDialog;
        string ruta = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        PlacaVideo placa;

        public FormImporteDeDatos(Sistema sis)
        {
            InitializeComponent();
            this.sistem = sis;
            lstListaDePlacas.DataSource = sis.ListaDePlacasACargarLado1;
            openFileDialog = new OpenFileDialog();
            placa = new PlacaVideo();
        }


        /// <summary>
        /// Boton que carga los datos a la lista de datos del sistema
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCargar_Click(object sender, EventArgs e)
        {
            try
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    placa = placa.Leer<PlacaVideo>(openFileDialog.FileName);
                    rtbInfoDatosCargados.Text = placa.Informar();
                    MessageBox.Show("Datos cargados");
                    this.btnAgregarLista.Text = $"Agregar {placa.Nombre} a la lista";
                }
                
            }
            catch (NoAgregaDatosException exe)
            {

                MessageBox.Show(exe.Message);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }


        /// <summary>
        /// Boton que agrega la placa cargada a la lista de placas del sistema
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAgregarLista_Click(object sender, EventArgs e)
        {

            if (sistem.VerificarPlaca(placa) )
            {
                MessageBox.Show("PLACA YA AGREGA", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if(rtbInfoDatosCargados.Text=="")
            {
                MessageBox.Show("Cargue datos primero", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {

                sistem.ListaDePlacasACargarLado1.Add(placa);
                sistem.ListaDePlacasACargarLado2.Add(placa);



                for (int i = 0; i < placa.NuevosDatos.Count; i++)
                {
                    ComparaDatosNuevos cp = new ComparaDatosNuevos(placa, placa);
                    cp.Dato = placa.NuevosDatos[i].Dato;
                    if (!(sistem.VerificarIngresoDeDatosQueNoSeRepita(cp))) { sistem.Comparaciones.Add(cp); }

                   
                }

                MessageBox.Show("Datos guardados");

                lstListaDePlacas.DataSource = null;
                lstListaDePlacas.DataSource = sistem.ListaDePlacasACargarLado1;
                this.btnAgregarLista.Text = "Placa Cargada";
            }

        }

        
    }
}
