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
    /// <summary>
    /// Clase de formulario que permite realizar las funciones básicas de una calculadora (+, -, *, /) entre dos numeros decimales.
    /// Además, permite convertir los numeros de decimal a binario y viceversa, siempre que sea posible.
    /// </summary>
    public partial class FormCalculadora : Form
    {
        /// <summary>
        /// Constructor que inicializa los componentes.
        /// </summary>
        public FormCalculadora()
        {
            this.InitializeComponent();
        }


        /// <summary>
        /// Evento que llama al método Limpiar().
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.Limpiar(); 
        }

        /// <summary>
        /// Borra los datos de los TextBox, ComboBox y Label de la pantalla. Y desactiva los botones de conversión.
        /// </summary>
        private void Limpiar ()
        {
            this.txtNumero1.Clear();
            this.txtNumero2.Clear();
            this.lblResultado.ResetText(); 
            //this.cmbOperador.ResetText();
            this.cmbOperador.SelectedIndex = -1;
            this.btnConvertirADecimal.Enabled = false;
            this.btnConvertirABinario.Enabled = false;
        }

        /// <summary>
        /// Convierte los string ingresados por teclado en tipo Numero y llama al método Calculadora.Operar().
        /// Se realiza la operación según el operador ingresado. Devuelve el resultado en double.
        /// </summary>
        /// <param name="numero1">Cadena a ser convetida en Numero.</param>
        /// <param name="numero2">Cadena a ser convetida en Numero.</param>
        /// <param name="operador">Operador ingresado para realizar la operación.</param>
        /// <returns>El resultado de la operación en double.</returns>
        public static double Operar (string numero1, string numero2, string operador)
        {
            Numero n1 = new Numero(numero1);
            Numero n2 = new Numero(numero2);

            return Calculadora.Operar(n1, n2, operador);
        }


        /// <summary>
        /// Evento que llama al método de clase Operar(). 
        /// Le pasa como parámetros el texto de los TextBox y el operador del ComboBox, convierte el retorno en string.
        /// Muestra el resultado en el Label. Habilita botón de decimal a binario. Deshabilita botón de binario a decimal.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOperar_Click(object sender, EventArgs e)
        {
            this.lblResultado.Text =  FormCalculadora.Operar(this.txtNumero1.Text, this.txtNumero2.Text, this.cmbOperador.Text).ToString();
            this.btnConvertirABinario.Enabled = true;
            this.btnConvertirADecimal.Enabled = false;
        }

        /// <summary>
        /// Evento que cierra el formulario y finaliza el programa.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        /// <summary>
        /// Evento que toma el resultado en el Label e intenta convertirlo a binario para mostrarlo por el Label.
        /// Deshabilita botón de decimal a binario. Habilita botón de binario a decimal.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            this.lblResultado.Text = Numero.DecimalBinario(this.lblResultado.Text).ToString();
            this.btnConvertirADecimal.Enabled = true;
            this.btnConvertirABinario.Enabled = false;

        }


        /// <summary>
        /// Evento que toma el resultado en el Label e intenta convertirlo a binario para mostrarlo por el Label.
        /// Habilita botón de decimal a binario. Deshabilita botón de binario a decimal.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            this.lblResultado.Text = Numero.BinarioDecimal(this.lblResultado.Text).ToString();
            this.btnConvertirABinario.Enabled = true;
            this.btnConvertirADecimal.Enabled = false;
        }
    }
}
