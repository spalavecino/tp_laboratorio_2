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
    public partial class LaCalculadora : Form
    {
        public LaCalculadora()
        {
            InitializeComponent();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.Limpiar();
        }

        private void Limpiar()
        {
            txtNumero1.Text = "";
            txtNumero2.Text = "";
            lblResultado.Text = "0";
            cmbOperador.SelectedIndex = -1;
        }

        private static double Operar(string numero1, string numero2, string operador)
        {
            Numero num1 = new Numero(numero1);
            Numero num2 = new Numero(numero2);
            Calculadora calculadora = new Calculadora();

            return calculadora.Operar(num1, num2, operador);
        }

        private void btnOperar_Click(object sender, EventArgs e)
        {
            double result = LaCalculadora.Operar(txtNumero1.Text, txtNumero2.Text, cmbOperador.Text);
            lblResultado.Text = result.ToString();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            Numero auxNumber = new Numero();
            lblResultado.Text = auxNumber.DecimalBinario(lblResultado.Text);
        }

        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            Numero auxNumber = new Numero();
            lblResultado.Text = auxNumber.BinarioDecimal(lblResultado.Text);
        }
    }
}
