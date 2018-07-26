using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public class Numero
    {
        private double numero;

        #region Properties
        public string SetNumero
        {
            set
            {

                this.numero = ValidarNumero(value);
            }
        }
        #endregion

        #region Contructors
        public Numero() { }

        public Numero(double numero)
        {
            this.numero = numero;
        }

        public Numero(string strNumero)
        {
            this.SetNumero = strNumero;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Valida que el valor sea numerico y lo retorna como tipo 'double', de lo contrario retorna cero.
        /// </summary>
        /// <param name="strNumero"></param>
        /// <returns></returns>
        private double ValidarNumero(string strNumero)
        {
            double result;

            if ( !(Double.TryParse( strNumero, out result ) ) )
            {
                result = 0;
            }

            return result;
        }

        /// <summary>
        /// Convierte un string que representa un numero binario, en un numero decimal
        /// </summary>
        /// <param name="binario"></param>
        /// <returns></returns>
        public string BinarioDecimal(string binario)
        {   
            foreach(var character in binario)
            {
                if ((character != '1') && (character != '0'))
                {
                    return "Valor inválido";
                }
            }

            return Convert.ToInt32(binario, 2).ToString();
        }

        /// <summary>
        /// Convierte un numero decimal en uno binario
        /// </summary>
        /// <param name="numero"></param>
        /// <returns></returns>
        public string DecimalBinario(string numero)
        {
            if (Double.TryParse(numero, out var auxDoble))
            {
                return  this.DecimalBinario(auxDoble);
            }
            else
            {
                return "Valor inválido";
            }
        }

        /// <summary>
        /// Convierte un numero decimal en uno binario
        /// </summary>
        /// <param name="numero"></param>
        /// <returns></returns>
        public string DecimalBinario(double numero)
        {
            return Convert.ToString((int)numero, 2);
        }

        /// <summary>
        /// Suma dos objetos de tipo Numero
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns></returns>
        public static double operator +(Numero n1, Numero n2) {
            return n1.numero + n2.numero;
        }

        /// <summary>
        /// Resta dos objetos del tipo Numero
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns></returns>
        public static double operator -(Numero n1, Numero n2) {
            return n1.numero - n2.numero;
        }

        /// <summary>
        /// Multiplica dos objetos del tipo Numero
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns></returns>
        public static double operator *(Numero n1, Numero n2) {
            return n1.numero * n2.numero;
        }

        /// <summary>
        /// Divide dos objetos del tipo Numero
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns></returns>
        public static double operator /(Numero n1, Numero n2) {
            return n1.numero / n2.numero;
        }
        #endregion



    }
}
