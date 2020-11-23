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

namespace VistaForm
{
    public partial class FormEmpleados : Form
    {

        private Local local;
        public FormEmpleados(Local local)
        {
            InitializeComponent();
            this.local = local;
        }


        /// <summary>
        /// Evento que lista la lista de ventas en el caso de ser posible
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonStock_Click(object sender, EventArgs e)
        {
            if(this.local.ListarVentas()!= "")
            {

                MessageBox.Show(this.local.ListarVentas());
            }
            else
            {
                MessageBox.Show("Todavia no hay ventas en el día :(","Aguarde",MessageBoxButtons.OK);

            }

        }
    }
}
