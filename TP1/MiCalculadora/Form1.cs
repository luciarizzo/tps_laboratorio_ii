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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            Operando numeroBinario = new Operando();
            string resultado = numeroBinario.DecimalBinario(156D);
            MessageBox.Show("El numero en binario es: " + resultado);
        }

        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            Operando numeroBinario = new Operando();
            string resultado = numeroBinario.BinarioDecimal("10011100");
            MessageBox.Show("El numero en decimal es: " + resultado);
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void cmbOperador_Click(object sender, EventArgs e)
        {

        }
    }
}
