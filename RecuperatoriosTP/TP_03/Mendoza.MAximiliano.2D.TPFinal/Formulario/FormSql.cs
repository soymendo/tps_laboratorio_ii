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
    public partial class FormSql : Form
    {
        Sistema sistem = new Sistema(1000);
        PlacaVideo placaCreada;
        PlacaDao placaDao = new PlacaDao();
        List<PlacaVideo> listaSql = new List<PlacaVideo>();

        public FormSql(Sistema sis)
        {
            InitializeComponent();
            this.sistem = sis;
            cmbMarca.DataSource = Enum.GetValues(typeof(Marca.EMarca));
            cmbTipoMemoria.DataSource = Enum.GetValues(typeof(PlacaVideo.ETipoMemoria));
            rtbDobleClick.ReadOnly = true;
            this.listaSql = placaDao.LeerDB();

        }


        /// <summary>
        /// Boton para crear un placa en la DataBase
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


                    if (VerificarPlaca(placaCreada)) { MessageBox.Show("PLACA YA AGREGA", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    else
                    {
                       
                        placaDao.InsertarPlaca(placaCreada);
                        this.listaSql.Add(placaCreada);
                        MessageBox.Show("Agregado con exito en la DataBase!!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);


                        placaCreada = null;
                       


                    }

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
         
        }

        /// <summary>
        /// Boton para cargar las placas desde la DataBase
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCargar_Click(object sender, EventArgs e)
        {
            try
            {
                this.lsbLista.Items.Clear();
                List<PlacaVideo> placas = placaDao.LeerDB();
                foreach (PlacaVideo item in placas)
                {
                    this.lsbLista.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        /// <summary>
        /// Boton para eliminar la placa seleccionada en la DataBase
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                PlacaVideo pla;
                string nombre;

                if (lsbLista.SelectedItem == null)
                {
                    MessageBox.Show("Se debe seleccionar algun elemento de la lista", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else
                {
                    pla = (PlacaVideo)(this.lsbLista.SelectedItem);
                    nombre = pla.Nombre; 
                    placaDao.Borrar(nombre);
                    this.lsbLista.Items.Remove((PlacaVideo)(this.lsbLista.SelectedItem));
                    this.listaSql.Remove(pla);
                    MessageBox.Show("Eliminado  de la base de datos", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    rtbDobleClick.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
           

       }

        private void lsbLista_MouseDoubleClick(object sender, MouseEventArgs e)
        {          

            PlacaVideo pla;
            pla = (PlacaVideo)(this.lsbLista.SelectedItem);
            if (lsbLista.SelectedItem == null)
            {
                MessageBox.Show("Se debe seleccionar algun elemento de la lista", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                rtbDobleClick.Text = pla.Informar();

            }

        }

      /// <summary>
      /// Boton para guardar la placa seleccionada en el Sistema
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
        private void btnGuardar_Click(object sender, EventArgs e)
        {

          
            if(lsbLista.SelectedItem is null)
            {
                MessageBox.Show("Se debe seleccionar algun elemento", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (sistem.VerificarPlaca((PlacaVideo)lsbLista.SelectedItem)) { MessageBox.Show("PLACA YA AGREGA", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                else
                {
 
                    sistem.ListaDePlacasACargarLado1.Add((PlacaVideo)lsbLista.SelectedItem);
                    sistem.ListaDePlacasACargarLado2.Add((PlacaVideo)lsbLista.SelectedItem);

                    MessageBox.Show("Agregado con exito en el Sistema!!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    placaCreada = null;
 
                }
            }
        }


        /// <summary>
        /// verifica que la placa creada no se repita
        /// </summary>
        /// <param name="p1"></param>
        /// <returns></returns>
        private bool VerificarPlaca(PlacaVideo p1)
        {
            bool retorno = false;
            foreach (PlacaVideo item in this.listaSql)
            {
                if (item == p1)
                {
                    retorno = true;
                }
            }
            return retorno;
        }


    }
}
