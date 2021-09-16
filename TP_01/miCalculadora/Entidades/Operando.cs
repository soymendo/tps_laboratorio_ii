using System;

namespace Entidades
{
    public class Operando
    {
        private double numero;



        /// <summary>
        /// Constructor sin parametro inicializa en cero.
        /// </summary>
        public Operando()
        {
            this.numero = 0;
        }


        /// <summary>
        /// Constructor que recibe un [double].
        /// </summary>
        /// <param name="dbNumero">Recibo un numero para inicializar el objeto.</param>
        public Operando(double numero)
             : this(numero.ToString())
        {
            this.numero = numero;
        }


        /// <summary>
        /// Constructor que recibe un string.
        /// Constructor por defecto.
        /// </summary>
        /// <param name="strNumero">Recibo un numero para inicializar el objeto.</param>
        public Operando(string strNumero)

        {
            this.Numero = strNumero;
        }




        /// <summary>
        /// Propiedad sólo escritura con validación.
        /// </summary>
        private string Numero
        {
            set
            {
                this.numero = ValidarOperando(value);
            }
        }







        /// <summary>
        /// validará que la cadena de caracteres esté compuesta SOLAMENTE por caracteres '0' o '1'.
        /// </summary>
        /// <param name="binario"> dato a validar</param>
        /// <returns></returns>

        private bool EsBinario(string binario)
        {
            if (binario == "0" || binario == "1")
                return true;
            else return false;
        }



        /// <summary>
        /// Valida que la cadena recibida sea un número binario. Si lo es lo convierte a decimal.
        /// Caso contrario retornará un texto avisando que no pudo ejecutar el pedido.
        /// </summary>
        /// <param name="unBinario">Texto a convertir en decimal.</param>
        /// <returns>Retorna el resultado de la operación o un mensanje avisando 
        /// que no pudo ejecutar el pedido.</returns>
        public static string BinarioDecimal(string binario)
        {
            for (int i = 0; i < binario.Length; i++)
            {
                if (binario[i] != '1' && binario[i] != '0')
                {
                    return "Valor inválido";
                }
            }
            double retorno = Convert.ToInt32(binario, 2);
            return retorno.ToString();
        }




        /// <summary>
        /// Método para convertir a decimal a binario [string]
        /// </summary>
        /// <param name="strResultado">Numero a convertir.</param>
        /// <returns>Retorno el numero convertido en binario (sólo parte entera).</returns>
        public static string DecimalBinario(string numero)
        {
            /* Se crea una instancia de Numero con el parametro strResultado.
             * Dejando asi solo la parte entera del numero
            */
            Operando aux = new Operando(numero);
            double dbNumero = Math.Floor(aux.numero);

            numero = "";
            if (dbNumero > 0)
            {
                while (dbNumero > 0)
                {
                    if (dbNumero % 2 == 0)
                        numero = "0" + numero;
                    else
                        numero = "1" + numero;
                    dbNumero = (int)(dbNumero / 2);
                }
            }
            else if (dbNumero == 0)
                numero = "0";
            else
                numero = "Valor inválido";
            return numero;
        }



        /// <summary>
        /// Recibe un numero decimal validado y lo convierte a binario.
        /// </summary>
        /// <param name="numero">Numero a convertir en binario.</param>
        /// <returns>Retorna un string con el número binario.</returns>
        public static string DecimalBinario(double numero)
        {
            int auxInt = Convert.ToInt32(numero);
            string retorno = Convert.ToString(auxInt, 2);
            Convert.ToInt32(numero);
            return retorno;
        }






        /// <summary>
        /// Método para validar numero, sino se inicializa en cero. 
        /// </summary>
        /// <param name="strNumero">Numero a validar.</param>
        /// <returns>Retorno número validado.</returns>

        public double ValidarOperando(string strNumero)
        {
            double.TryParse(strNumero, out double dbNumero);
            return dbNumero;
        }









        /// <summary>
        /// Operación resta [-]
        /// </summary>
        /// <param name="numero1">Operador para la división.</param>
        /// <param name="numero2">Operador para la división.</param>
        /// <returns>Retorno resultado de la </returns>        
        public static double operator -(Operando numero1, Operando numero2)
        {
            return numero1.numero - numero2.numero;
        }

        /// <summary>
        /// Operación división [/]
        /// </summary>
        /// <param name="numero1">Operador para la división.</param>
        /// <param name="numero2">Operador para la división.</param>
        /// <returns>Retorno resultado de la división.</returns>
        public static double operator /(Operando numero1, Operando numero2)
        {
            double resultado;
            if (numero2.numero == 0)
                resultado = double.MinValue;
            else
                resultado = numero1.numero / numero2.numero;
            return resultado;
        }

        /// <summary>
        /// Operación multiplicación [*]
        /// </summary>
        /// <param name="numero1">Operador para la multiplicación.</param>
        /// <param name="numero2">Operador para la multiplicación.</param>
        /// <returns>Retorno resultado de la multiplicación.</returns>
        public static double operator *(Operando numero1, Operando numero2)
        {
            return numero1.numero * numero2.numero;
        }


        /// <summary>
        /// Operación suma [+]
        /// </summary>
        /// <param name="numero1">Operador para la suma.</param>
        /// <param name="numero2">Operador para la suma.</param>
        /// <returns>Retorno resultado de la suma.</returns>


        public static double operator +(Operando numero1, Operando numero2)
        {
            return numero1.numero + numero2.numero;
        }















    }
}
