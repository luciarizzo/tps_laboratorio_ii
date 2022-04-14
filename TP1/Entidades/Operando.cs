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
                    this.numero = numeroValidado;
                }
            }
        }

        private double ValidarOperando(string strNumero)
        {
            double retorno = 0;
            if (!String.IsNullOrEmpty(strNumero))
            {
                double.TryParse(strNumero, out retorno);
            }
            return retorno;
        }

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

        public string BinarioDecimal(string binario) ///FUNCIONA OK!!
        {
            char[] array;
            int tamanio = binario.Length;
            double sumaPotencias = 0;
            array = binario.ToCharArray();
            double potencia;
            if (EsBinario(binario))
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
            return "Valor Invalido";
        }

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

        public static double operator-(Operando n1, Operando n2)
        {
            return n1.numero - n2.numero;
        }

        public static double operator +(Operando n1, Operando n2)
        {
            return n1.numero + n2.numero;
        }

        public static double operator *(Operando n1, Operando n2)
        {
            return n1.numero * n2.numero;
        }

        public static double operator /(Operando n1, Operando n2)
        {
            return n1.numero / n2.numero;
        }

    }
}
