using System;

namespace Entidades
{
    public class Calculadora
    {
        /// <summary>
        /// Valida que el operador sea valido y lo retorna, si no es ningun operador valido devuelve "+".
        /// </summary>
        /// <param name="operador"></param>
        /// <returns></returns>
        private static string ValidarOperador (string operador)
        {
            if ( operador != "+" && operador != "-" && operador != "*" && operador != "/" )
            {
                return "+";
            }
            else
            {
                return operador;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <param name="operador"></param>
        /// <returns></returns>
        public double Operar (Numero num1, Numero num2, string operador)
        {
            operador = Calculadora.ValidarOperador(operador);
            double result = 0;

            switch (operador)
            {
                case "+":
                    result = num1 + num2;
                    break;
                case "-":
                    result = num1 - num2;
                    break;
                case "*":
                    result = num1 * num2;
                    break;
                case "/":
                    result = num1 / num2;
                    break;                
            }

            return result;
        }
    }
}
