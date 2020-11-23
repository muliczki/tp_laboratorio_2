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

namespace VistaForm
{
    public partial class FormVentas : Form
    {

        private Producto productoSeleccionado;
        private Local local;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="local">Instancia del local.</param>
        /// <param name="productoSeleccionado">Producto seleccionado por el usuario en el PrincipalForm.</param>
        public FormVentas(Local local, Producto productoSeleccionado)
        {
            InitializeComponent();
            this.local = local;
            this.productoSeleccionado = productoSeleccionado;
        }

        /// <summary>
        /// Manejador del evento OnLoad del formulario.
        /// Inicializará los controles.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormVentas_Load(object sender, EventArgs e)
        {
            this.lblDescripcion.Text = this.productoSeleccionado.Descripcion;
            ActualizarPrecio();
        }

 

        /// <summary>
        /// Actualiza el lblPrecioFinal de acuerdo a la cantidad seleccionada del producto.
        /// </summary>
        private void ActualizarPrecio()
        {
            int cantidadSeleccionada = Convert.ToInt32(this.numericUpDownCantidad.Value);
            double nuevoPrecioFinal = Venta.CalcularPrecioFinal(this.productoSeleccionado.Precio, cantidadSeleccionada);
            this.lblPrecioFinal.Text = String.Format("Precio Final: ${0:0.00}", nuevoPrecioFinal);
        }

    


        /// <summary>
        /// Manejador del evento OnChanged del numericUpDownCantidad.
        /// Actualizará el lblPrecioFinal de acuerdo a la cantidad seleccionada.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void numericUpDownCantidad_ValueChanged(object sender, EventArgs e)
        {
            ActualizarPrecio();
        }


        /// <summary>
        /// Manejador del evento OnClick del btnVender.
        /// Confirma y genera la venta del producto. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnVender_Click(object sender, EventArgs e)
        {
            int cantidadSeleccionada = Convert.ToInt32(this.numericUpDownCantidad.Value);

            if (productoSeleccionado.Stock >= cantidadSeleccionada)
            {
                this.local.Vender(this.productoSeleccionado, cantidadSeleccionada);

                
                this.DialogResult = DialogResult.OK;
                MessageBox.Show("Gracias por su compra!!", "Venta concretada", MessageBoxButtons.OK);
                this.Close();
            }
            else
            {
                MessageBox.Show("La cantidad indicada supera el stock disponible. Por favor, disminuya la cantidad.", "Stock Superado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        /// <summary>
        /// Manejador del evento click del botón cancelar.
        /// Cierra el formulario.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
