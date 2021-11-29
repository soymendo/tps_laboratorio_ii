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
    public partial class FormCargaDeDatos : Form
    {
        string ruta = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        Sistema sistem = new Sistema(1000);
        PlacaVideo placaCreada;
        PlacaVideo placaDatos = new PlacaVideo();
        PlacaVideo xml;
        
       
        public FormCargaDeDatos(Sistema sis)
        {
            InitializeComponent();
            Bitmap img = new Bitmap(Application.StartupPath + @"\img\FONDOHD2.jpg");
            this.BackgroundImage = img;


            this.sistem = sis;
            cmbMarca.DataSource = Enum.GetValues(typeof(Marca.EMarca));
            cmbTipoMemoria.DataSource = Enum.GetValues(typeof(PlacaVideo.ETipoMemoria));
            rtbDatosCargados.ReadOnly = true;
        }


        /// <summary>
        /// Boton para crar una placa
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void btnCrear_Click(object sender, EventArgs e)
        {
            try
            {
                this.placaCreada = new PlacaVideo(txtNombre.Text, (Marca.EMarca)cmbMarca.SelectedItem);

                if (txtNombre.Text == "" || cmbMarca.SelectedItem is null)
                {
                    MessageBox.Show("Nombre y marca son obligtorios", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    placaCreada.TipoDeMemoria = (PlacaVideo.ETipoMemoria)cmbTipoMemoria.SelectedItem;
                    if (!(txtCapacidaddeRam.Text == "")) { placaCreada.CapacidadDeRam = int.Parse(txtCapacidaddeRam.Text); }
                    if (!(txtFrecuencia.Text == "")) { placaCreada.FrecuenciaDeMemoria = int.Parse(txtFrecuencia.Text); }
                    if (!(txtConsumo.Text == "")) { placaCreada.Consumo = int.Parse(txtConsumo.Text); }
                    if (!(txtLongitud.Text == "")) { placaCreada.Longitud = int.Parse(txtLongitud.Text); }
                    if (!(txtInterfaz.Text == "")) { placaCreada.Interfaz = float.Parse(txtInterfaz.Text); }
                    if (!(txtBitcoin.Text == "")) { placaCreada.MineriaBitcoin = float.Parse(txtBitcoin.Text); }
                    if (!(txtEthereum.Text == "")) { placaCreada.MineriaEthereum = float.Parse(txtEthereum.Text); }


                    if (sistem.VerificarPlaca(placaCreada)) { MessageBox.Show("PLACA YA AGREGA", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    else
                    {
                        placaCreada.NuevosDatos = placaDatos.NuevosDatos;

                        sistem.ListaDePlacasACargarLado1.Add(placaCreada);
                        sistem.ListaDePlacasACargarLado2.Add(placaCreada);

                        MessageBox.Show("Agregado con exito!!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        rtbDatosCargados.Text = placaCreada.Informar();
                        xml = placaCreada;
                        placaCreada = null;
                        placaDatos = new PlacaVideo();


                    }

                }
            }
            catch (Exception exe)
            {

                MessageBox.Show(exe.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
               
            
        }

        /// <summary>
        /// Boton para agragar un dato nuevo a la placa en creacion
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDatoNuevo_Click(object sender, EventArgs e)
        {
          

            try
            {
                if (txtNuevoDato.Text == "")
                {
                    MessageBox.Show("dato nuevo no debe ser vacio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (Sistema.AgregarDatosNuevos(placaDatos, txtNuevoDato.Text, int.Parse(txtValor.Text)))
                    {

                        MessageBox.Show("datos agregados con exito!!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        string respaldo = txtNuevoDato.Text;
                        txtNuevoDato.Text = null;
                        txtValor.Text = null;
                        string dato1 = respaldo;
                        ComparaDatosNuevos cp1 = new ComparaDatosNuevos(placaDatos, placaDatos);
                        cp1.Dato = dato1;
                        if (!(sistem.VerificarIngresoDeDatosQueNoSeRepita(cp1))) { sistem.Comparaciones.Add(cp1); }

                    }
                    else
                    {
                        MessageBox.Show("dato ya agregado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                
            
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

            
            rtbDatosCargados.Text = null;

        }


        /// <summary>
        /// Boton para guardar l aplaca creada en formato XML
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnXml_Click(object sender, EventArgs e)
        {
            if(xml is not null)
            {
                xml.Guardar(ruta);
                MessageBox.Show("Placa guardada en escritorio", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                xml = null;
            }
            else if(rtbDatosCargados.Text=="")
            {
                MessageBox.Show("No hay datos para guardar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Placa ya guardada", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }



        /// <summary>
        /// Permite solo la entrada de numeros
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtCapacidaddeRam_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// Permite solo la entrada de numeros
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtFrecuencia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// Permite solo la entrada de numeros
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtConsumo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// Permite solo la entrada de numeros
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtLongitud_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// Permite solo la entrada de numeros y la tecla punto   " . "
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtInterfaz_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != (char)46))
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// Permite solo la entrada de numeros y la tecla punto   " . "
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtBitcoin_KeyPress(object sender, KeyPressEventArgs e)
        {
            
            if (!char.IsNumber(e.KeyChar) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != (char)46))
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// Permite solo la entrada de numeros y la tecla punto   " . "
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtEthereum_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != (char)46))
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// Permite solo la entrada de numeros 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtValor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// invalida el combobox para que no se pueda escribir en el .
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbMarca_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        /// <summary>
        /// invalida el combobox para que no se pueda escribir en el .
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbTipoMemoria_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
    }
}
