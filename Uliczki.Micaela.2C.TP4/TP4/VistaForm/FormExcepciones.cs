using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VistaForm
{
    public partial class ExcepcionesForm : Form
    {
        private Exception exception;

        public ExcepcionesForm(Exception exception)
        {
            InitializeComponent();
            this.exception = exception;
            if (this.exception.InnerException == null)
            {
                this.btnDetalles.Enabled = false;
            }
        }

        /// <summary>
        /// cierra formulario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOk_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// muestra detalle de la pila de llamadas
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDetalles_Click_1(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            Exception innerException = this.exception.InnerException;
            while (innerException != null)
            {
                sb.AppendLine(innerException.Message);
                innerException = innerException.InnerException;
            }

            MessageBox.Show(sb.ToString(), "Detalle de Error", MessageBoxButtons.OK);
        }


        /// <summary>
        /// arroja el error de la excepcion
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExcepcionesForm_Load_1(object sender, EventArgs e)
        {
            this.lblMessage.Text = exception.Message;
        }
    }
}
