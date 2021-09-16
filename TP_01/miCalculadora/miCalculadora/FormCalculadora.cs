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


namespace miCalculadora
{
    public partial class FormCalculadora : Form
    {
        public FormCalculadora()
        {
            InitializeComponent();
        }

        List<string> resultados = new List<string>();


        /// <summary>
        /// FormClosing, pregunta si esta seguro de cerrar el formulario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormCalculadora_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("¿Seguro de querer salir?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Dispose();
            }
            else
            {
                e.Cancel = true;
            }
        }

        /// <summary>
        /// load del formulario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormCalculadora_Load(object sender, EventArgs e)
        {
            Limpiar();
        }


        /// <summary>
        /// invalida la modificacion del cmbOperador
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbOperador_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }




        /// <summary>
        /// Método para limpiar el formulario.
        /// </summary>
        private void Limpiar()
        {
            txtNumero1.Clear();
            txtNumero2.Clear();
            cmbOperador.ResetText();
            lblResultado.ResetText();
            btnConvertirABinario.Enabled = false;
            btnConvertirADecimal.Enabled = false;
            cmbOperador.Text = "Elija operacion";
            lblResultado.Text = "Resultado";
            
        }





        /// <summary>
        /// Funcion privada y estática para realizar calculos.
        /// </summary>
        /// <param name="numero1">Numero para operar</param>
        /// <param name="numero2">Numero para operar</param>
        /// <param name="operador">Tipo de operador</param>
        /// <returns>Retorno resultado de operación</returns>
        private static double Operar(string numero1, string numero2, string operador)
        {
            double retorno = 0;
            //Instancio los operadores con valores string
             Operando operando1= new Operando(numero1);
             Operando operando2 = new Operando(numero2);
            //Retorno directamente la operacion solicitada
           if (operador=="Elija operacion")
            {
                MessageBox.Show("error");
            }else
            {
                retorno = Calculadora.Operar(operando1, operando2, Convert.ToChar(operador));
            }
            return retorno;
        }


        /// <summary>
        /// Botón para Operar.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 
        private void btnOperar_Click(object sender, EventArgs e)
        {
            if(cmbOperador.Text =="Elija operacion" || (String.IsNullOrEmpty(txtNumero1.Text)) || (String.IsNullOrEmpty(txtNumero2.Text)))
            {
                MessageBox.Show("debe elegir una operacion");

            }
            else
            {
                lblResultado.Text = FormCalculadora.Operar(txtNumero1.Text, txtNumero2.Text, cmbOperador.Text).ToString();
                string numeros;

                if (cmbOperador.SelectedIndex == 0)
                {
                    numeros = $"{txtNumero1.Text} + {txtNumero2.Text} = {FormCalculadora.Operar(txtNumero1.Text, txtNumero2.Text, cmbOperador.Text).ToString()}";
                    resultados.Add(numeros);
                }
                if (cmbOperador.SelectedIndex == 1)
                {
                    numeros = $"{txtNumero1.Text} - {txtNumero2.Text} = {FormCalculadora.Operar(txtNumero1.Text, txtNumero2.Text, cmbOperador.Text).ToString()}";
                    resultados.Add(numeros);
                }
                if (cmbOperador.SelectedIndex == 2)
                {
                    numeros = $"{txtNumero1.Text} / {txtNumero2.Text} = {FormCalculadora.Operar(txtNumero1.Text, txtNumero2.Text, cmbOperador.Text).ToString()}";
                    resultados.Add(numeros);
                }
                if (cmbOperador.SelectedIndex == 3)
                {
                    numeros = $"{txtNumero1.Text} * {txtNumero2.Text} = {FormCalculadora.Operar(txtNumero1.Text, txtNumero2.Text, cmbOperador.Text).ToString()}";
                    resultados.Add(numeros);
                }

            }

            btnConvertirABinario.Enabled = true;
            btnConvertirADecimal.Enabled = false;

            lstOperaciones.DataSource = null;
            lstOperaciones.DataSource = resultados;

        }








        /// <summary>
        /// Botón para el cierre del formulario.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            FormCalculadora.ActiveForm.Close();
        }



        /// <summary>
        /// Boton binario a decimal.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 
        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            string resultado = Operando.DecimalBinario(lblResultado.Text);
            if (resultado != "Valor inválido")
                btnConvertirADecimal.Enabled = true;
            lblResultado.Text = resultado;
            btnConvertirABinario.Enabled = false;
        }



        /// <summary>
        /// Boton decimal a binario.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            
                lblResultado.Text = Operando.BinarioDecimal(lblResultado.Text);
                btnConvertirABinario.Enabled = true;
                btnConvertirADecimal.Enabled = false;
          
        }

        /// <summary>
        /// Botón para limpiar el formulario.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }


        //------------Entrada unicamente de numeros.---------------
        /// <summary>
        /// Permite al usuario ingresar solamente numeros dentro del textBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void txtNumero1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
            }
        }

        private void txtNumero2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
            }
        }
    }
}
