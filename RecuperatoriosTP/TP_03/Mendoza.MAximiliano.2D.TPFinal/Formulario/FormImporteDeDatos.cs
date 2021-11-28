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
using System.Threading;
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
            Bitmap img = new Bitmap(Application.StartupPath + @"\img\FONDOHD6.jpg");
            this.BackgroundImage = img;
            this.sistem = sis;
            lstListaDePlacas.DataSource = sis.ListaDePlacasACargarLado1;
            openFileDialog = new OpenFileDialog();
            placa = new PlacaVideo();
            rtbInfoDatosCargados.ReadOnly = true;
           

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
        /// metodo para la task
        /// </summary>
        public void Guardar()
        {

            if (rtbInfoDatosCargados.InvokeRequired)
            {
                Action delegado = Guardar;
                Invoke(delegado);
            }
            else
            {
                try
                {
                    if (rtbInfoDatosCargados.Text == "")
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



                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }

            }

        }





        /// <summary>
        /// Boton que agrega la placa cargada a la lista de placas del sistema
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAgregarLista_Click(object sender, EventArgs e)
        {
            if (sistem.VerificarPlaca(placa))
            {
                MessageBox.Show("PLACA YA AGREGA", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {

                try
                {
                    if (rtbInfoDatosCargados.Text == "")
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
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }


            }

        }


     

        /// <summary>
        /// FormClosing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormImporteDeDatos_FormClosing(object sender, FormClosingEventArgs e)
        {

            if ((MessageBox.Show("¿Está seguro de querer salir?, Los datos que no se guardaron, no se cargaran en el Sistema", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No))
            {

                e.Cancel = true;

            }

        }
    }
}
