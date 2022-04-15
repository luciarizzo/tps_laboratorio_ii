using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Calculadora
    {
        /// <summary>
        /// Realiza la operacion pedida entre ambos numeros
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <param name="operador"></param>
        /// <returns>Retorna el resultado de la operacion (double)</returns>
        public static double Operar(Operando num1, Operando num2, char operador)
        {
            double resultado = 0;
            operador = ValidarOperador(operador);
            switch (operador)
            {
                case '+':
                    resultado = num1 + num2;
                    break;
                case '-':
                    resultado = num1 - num2;
                    break;
                case '*':
                    resultado = num1 * num2;
                    break;
                case '/':
                    resultado = num1 / num2;
                    break;
            }
            return resultado;
        }

        /// <summary>
        /// Valida que el operador recibido sea +, -, / o *. 
        /// </summary>
        /// <param name="operador"></param>
        /// <returns>Retorna el operador ingresado luego de validarlo. Caso contrario retornara +</returns>
        private static char ValidarOperador(char operador) //consultar que pasa si no uso static
        {
            if(operador == '+' || operador == '-' || operador == '*' || operador == '/')
            {
                return operador;
            }
            return '+';
        }
    }
}
