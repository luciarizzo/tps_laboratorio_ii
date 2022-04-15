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

namespace MiCalculadora
{
    public partial class FormCalculadora : Form
    {
        public FormCalculadora()
        {
            InitializeComponent();
        }
        private void FormCalculadora_Load(object sender, EventArgs e)
        {
            Limpiar();
        }

        /// <summary>
        /// Limpia los TextBox, ComboBox, Label
        /// </summary>
        private void Limpiar()
        {
            txtNumero1.Clear();
            txtNumero2.Clear();
            lblResultado.Text = "";
            cmbOperador.SelectedIndex = 0;
        }

        /// <summary>
        /// Presionando el boton se convierte el numero decimal a binario en caso de ser posible
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            Operando numeroDecimal = new Operando();
            if (!(String.IsNullOrWhiteSpace(lblResultado.Text)))
            {
                lblResultado.Text = numeroDecimal.DecimalBinario(lblResultado.Text);
            }
        }

        /// <summary>
        /// Presionando el boton se convierte el numero binario a decimal en caso de ser posible
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            Operando numeroBinario = new Operando();
            if (!(String.IsNullOrWhiteSpace(lblResultado.Text)))
            {
                lblResultado.Text = numeroBinario.BinarioDecimal(lblResultado.Text);
            }
        }

        /// <summary>
        /// Presionando el boton se cierra la ventana
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Realiza la operacion correspondiente de los numeros por parametro
        /// </summary>
        /// <param name="numero1"></param>
        /// <param name="numero2"></param>
        /// <param name="operador"></param>
        /// <returns></returns>
        public static double Operar(string numero1, string numero2, string operador)
        {
            Operando operando1 = new Operando(numero1);
            Operando operando2 = new Operando(numero2);
            char operadorElegido;

            //parseo a char porque operar recibe char
            char.TryParse(operador, out operadorElegido);

            return Calculadora.Operar(operando1, operando2, operadorElegido);
        }

        /// <summary>
        /// Presionando se realiza la operacion segun los numeros ingresados y operacion elegida
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOperar_Click(object sender, EventArgs e)
        {
            double resultado;
            string operando1 = txtNumero1.Text;
            string operando2 = txtNumero2.Text;
            string operadorElegido = cmbOperador.Text;
            resultado = Operar(txtNumero1.Text, txtNumero2.Text, operadorElegido);
            if (!String.IsNullOrWhiteSpace(operando1) && !String.IsNullOrWhiteSpace(operando1))
            { 
                if(String.IsNullOrWhiteSpace(operadorElegido))
                {
                    lstOperaciones.Items.Add(operando1 + "+" + operando2 + " = " + resultado.ToString());

                }
                else
                {
                    lstOperaciones.Items.Add(operando1 + operadorElegido + operando2 + " = " + resultado.ToString());
                }
            }
            lblResultado.Text = resultado.ToString();
        }

        /// <summary>
        /// Permite mostrar el mensaje de confirmacion para salir de la ventana
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormCalculadora_FormClosing(Object sender, FormClosingEventArgs e)
        {

            if (MessageBox.Show("Seguro que desea salir?", "Salir",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        /// <summary>
        /// Presionandolo borra los datos de TextBox, ComboBox y Label de la pantalla
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
    }
}
