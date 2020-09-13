using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiCalculadora
{
    public partial class FormCalculadora : Form
    {
        public FormCalculadora()
        {
            this.InitializeComponent();
        }



        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.Limpiar(); 
        }


        private void Limpiar ()
        {
            this.txtNumero1.Clear();
            this.txtNumero2.Clear();
            this.lblResultado.ResetText(); //VERRRRRRRR
            this.cmbOperador.ResetText();
            this.btnConvertirADecimal.Enabled = false;
            this.btnConvertirABinario.Enabled = false;
        }


        public static double Operar (string numero1, string numero2, string operador)
        {
            Numero n1 = new Numero(numero1);
            Numero n2 = new Numero(numero2);

            return Calculadora.Operar(n1, n2, operador);
        }

        private void btnOperar_Click(object sender, EventArgs e)
        {
            this.lblResultado.Text =  FormCalculadora.Operar(this.txtNumero1.Text, this.txtNumero2.Text, this.cmbOperador.Text).ToString();
            this.btnConvertirABinario.Enabled = true;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            this.lblResultado.Text = Numero.DecimalBinario(this.lblResultado.Text).ToString();
            this.btnConvertirADecimal.Enabled = true;
            this.btnConvertirABinario.Enabled = false;



        }

        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            this.lblResultado.Text = Numero.BinarioDecimal(this.lblResultado.Text).ToString();
            this.btnConvertirABinario.Enabled = true;
            this.btnConvertirADecimal.Enabled = false;
        }
    }
}
