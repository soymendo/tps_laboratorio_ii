using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Calculadora
    {
        //-------------METODOS-----------------------

        /// <summary>
        /// Método privado para validar operador.
        /// <param name="operador">Operador a validar.</param>
        /// <returns>Retorno operador validado.</returns>

        private static char ValidarOperador(char operador)
        {
            switch (operador)
            {
                case '+'://Suma

                    break;
                case '-'://Resta

                    break;
                case '/'://Division

                    break;
                case '*'://Multiplicacion

                    break;
                default://Convierto a Suma
                    operador = '+';
                    break;
            }
            return operador;
        }


        /// <summary>
        /// Método estático para realizar operaciones.
        /// </summary>
        /// <param name="num1">Primero numero para operación</param>
        /// <param name="num2">Segundo numero para operación</param>
        /// <param name="operador">Tipo de operador</param>
        /// <returns>Retorno resultado de la operacion</returns>


        public static double Operar(Operando num1, Operando num2, char operador)
        {
            double resultado = 0;
            switch (ValidarOperador(operador))
            {
                case '+'://Suma
                    resultado = num1 + num2;
                    break;
                case '-'://Resta
                    resultado = num1 - num2;
                    break;
                case '/'://Division
                    resultado = num1 / num2;
                    break;
                case '*'://Multiplicacion
                    resultado = num1 * num2;
                    break;
            }
            return resultado;
        }




    }
}
