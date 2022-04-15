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

        private void Limpiar()
        {
            txtNumero1.Clear();
            txtNumero2.Clear();
            lblResultado.Text = "";
            cmbOperador.SelectedIndex = 0;
        }

        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            Operando numeroDecimal = new Operando();
            if (!(String.IsNullOrWhiteSpace(lblResultado.Text)))
            {
                lblResultado.Text = numeroDecimal.DecimalBinario(lblResultado.Text);
            }
        }

        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            Operando numeroBinario = new Operando();
            if (!(String.IsNullOrWhiteSpace(lblResultado.Text)))
            {
                lblResultado.Text = numeroBinario.BinarioDecimal(lblResultado.Text);

            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbOperador_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }


        public static double Operar(string numero1, string numero2, string operador)
        {
            Operando operando1 = new Operando(numero1);
            Operando operando2 = new Operando(numero2);
            char operadorElegido;

            //parseo a char porque operar recibe char
            char.TryParse(operador, out operadorElegido);

            return Calculadora.Operar(operando1, operando2, operadorElegido);
        }

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

        private void FormCalculadora_FormClosing(Object sender, FormClosingEventArgs e)
        {

            if (MessageBox.Show("Seguro que desea salir?", "Salir",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
    }
}
