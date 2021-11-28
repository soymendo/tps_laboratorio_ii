using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;
using Entidades.Clases_especializadas;
using Entidades.Clases_generales;

namespace Formulario
{
    public partial class FormMenu : Form
    {
        Sistema sistema = new Sistema(1000);
        public FormMenu()
        {
            InitializeComponent();
            Bitmap img = new Bitmap(Application.StartupPath + @"\img\FONDOHD.jpg");
            this.BackgroundImage = img;


        }

        private void btnCargarDatos_Click(object sender, EventArgs e)
        {
            FormCargaDeDatos formCargaDeDatos = new FormCargaDeDatos(sistema);
            formCargaDeDatos.ShowDialog();
        }

        private void btnComparar_Click(object sender, EventArgs e)
        {
            FormComparar formComparar = new FormComparar(sistema);
            formComparar.ShowDialog();
        }

        private void btnImportar_Click(object sender, EventArgs e)
        {
            FormImporteDeDatos formImportarDatos = new FormImporteDeDatos(sistema);
            formImportarDatos.Show();
        }

        private void btnAnalisis_Click(object sender, EventArgs e)
        {
            FormAnalisis formAnalisis = new FormAnalisis(sistema);
            formAnalisis.ShowDialog();
        }

       


        /// <summary>
        /// Carga los datos a la lista de placas
        /// </summary>
        private void CargarDatos()
        {


            foreach (PlacaVideo item in sistema.ListaDePlacasACargarLado1)
            {
                Random plac = new Random();
                Random ram = new Random();
                Random frec = new Random();
                Random cons = new Random();
                Random longi = new Random();
                Random inter = new Random();
                Random bit = new Random();
                Random ethe = new Random();

                item.TipoDeMemoria = (PlacaVideo.ETipoMemoria)(plac.Next(0, 4));
                item.CapacidadDeRam = ram.Next(1, 17);
                item.FrecuenciaDeMemoria = frec.Next(1, 17);
                item.Consumo = cons.Next(10, 101);
                item.Longitud = longi.Next(10, 36);
                item.Interfaz = inter.NextDouble() + inter.Next(1, 4);
                item.MineriaEthereum = ethe.NextDouble() * 0.1;
                item.MineriaBitcoin = bit.NextDouble() * 0.1;

            }

        }




    }
}
