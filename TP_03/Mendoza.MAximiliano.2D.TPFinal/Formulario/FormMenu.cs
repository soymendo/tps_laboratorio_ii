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
using Entidades.Clases_generales;

namespace Formulario
{
    public partial class FormMenu : Form
    {
        Sistema sistema = new Sistema(1000);
        public FormMenu()
        {
            InitializeComponent();
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
            formImportarDatos.ShowDialog();
        }
    }
}
