using System;

namespace Entidades
{
    public class Operando
    {
        private double numero;

        public Operando()
        {
            numero = 0;
        }

        public Operando(double numero)
        {
            this.numero = numero;
        }

        public Operando(string strNumero)
        {
            Numero = strNumero;
        }

        private string Numero
        {
            set
            {
                double numeroValidado = ValidarOperando(value);
                if (numeroValidado != 0)
                {
                    numero = numeroValidado;
                }
            }
        }
        /// <summary>
        /// Valida que el valor recibido sea numerico
        /// </summary>
        /// <param name="strNumero"></param>
        /// <returns>Devuelve el operando en caso de poder convertirlo a double, caso contrario devuelve 0</returns>
        private double ValidarOperando(string strNumero)
        {
            double retorno = 0;
            if (!String.IsNullOrEmpty(strNumero))
            {
                double.TryParse(strNumero, out retorno);
            }
            return retorno;
        }

        /// <summary>
        /// Validara que la cadena de caractees este compuesta solamente por caracteres 0 o 1
        /// </summary>
        /// <param name="numero"></param>
        /// <returns>Retorna true en caso de que sea binario, false en caso de que no lo sea</returns>
        private bool EsBinario(string numero) ///FUNCIONA OK!!!
        {
            bool retorno = false;
            char[] array;
            array = numero.ToCharArray();
            foreach (char c in array)
            {
                if (c != '0' && c != '1')
                {
                    return retorno;
                }
            }
            retorno = true;
            return retorno;
        }

        /// <summary>
        /// Convierte el numero binario a decimal en caso de ser posible.
        /// </summary>
        /// <param name="binario"></param>
        /// <returns>Retorna el numero decimal si pudo convertir, caso contrario retorna "Valor invalido"</returns>
        public string BinarioDecimal(string binario) ///FUNCIONA OK!!
        {
            char[] array;
            int tamanio = binario.Length;
            double sumaPotencias = 0;
            array = binario.ToCharArray();
            double potencia;
            if (!(String.IsNullOrWhiteSpace(binario)) && EsBinario(binario))
            {
                int posiciones = tamanio - 1;

                foreach (char c in array)
                    {
                        potencia = Math.Pow(2, posiciones);

                        if (c == '0')
                        {
                            double multiplicacion = 0 * potencia;
                            sumaPotencias = multiplicacion + sumaPotencias;
                            posiciones--;
                        }
                        else if (c == '1')
                        {
                            double multiplicacion = 1 * potencia;
                            sumaPotencias = multiplicacion + sumaPotencias;
                            posiciones--;
                        }
                    }
                return sumaPotencias.ToString();
            }
            return "Valor invalido";
        }
        /// <summary>
        /// Convierte el numero decimal a binario en caso de ser posible.
        /// </summary>
        /// <param name="numero"></param>
        /// <returns>Retorna el numero binario si pudo convertir, caso contrario retorna "Valor invalido"</returns>
        public string DecimalBinario(double numero) /// FUNCIONA OK!!!!!
        {
            string numeroFormandose = "";
            int decimalActualizado = (int)Math.Abs(numero);
            int flagPrimerIngreso = 0;
            if (numero > 0)
            {
                do
                {
                    if (flagPrimerIngreso == 1)
                    {
                        decimalActualizado = decimalActualizado / 2;
                    }

                    flagPrimerIngreso = 1;

                    if ((decimalActualizado % 2) == 0)
                    {

                        numeroFormandose = "0" + numeroFormandose;
                    }
                    else if ((decimalActualizado % 2) == 1)
                    {
                        numeroFormandose = "1" + numeroFormandose;
                    }
                } while (decimalActualizado > 1);

                return numeroFormandose;
            }
            return "Valor invalido";
        }

        /// <summary>
        /// Convierte el numero decimal a binario en caso de ser posible.
        /// </summary>
        /// <param name="strNumero"></param>
        /// <returns>Retorna el numero binario si pudo convertir, caso contrario retorna "Valor invalido"</returns>
        public string DecimalBinario(string strNumero)
        {
            double numeroDecimal;
            if(!(String.IsNullOrEmpty(strNumero)) && double.TryParse(strNumero, out numeroDecimal))
            {
                return DecimalBinario(numeroDecimal);
            }
            return "Valor invalido";
        }
        /// <summary>
        /// Realiza la resta entre dos operando
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns>Retorna el resultado de la resta</returns>
        public static double operator-(Operando n1, Operando n2)
        {
            return n1.numero - n2.numero;
        }

        /// <summary>
        /// Realiza la suma entre dos operandos
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns>Retorna el resultado de la suma</returns>
        public static double operator +(Operando n1, Operando n2)
        {
            return n1.numero + n2.numero;
        }

        /// <summary>
        /// Realiza la multiplicacion entre dos operandos
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns>Retorna el resultado de la multiplicacion</returns>
        public static double operator *(Operando n1, Operando n2)
        {
            return n1.numero * n2.numero;
        }

        /// <summary>
        /// Realiza la division entre dos operandos
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns>Retorna el resultado de la division. Si el segundo operando es igual a cero, retorna la constante double.MinValue</returns>
        public static double operator /(Operando n1, Operando n2)
        {
            if (n2.numero == 0)
            {
                return double.MinValue;
            }
            return n1.numero / n2.numero;
        }

    }
}
