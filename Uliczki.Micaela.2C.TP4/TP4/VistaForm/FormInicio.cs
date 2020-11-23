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
    public partial class FormInicio : Form
    {
        private Local local;

        public FormInicio()
        {
            InitializeComponent();
            local = new Local();
        }


        /// <summary>
        /// Redirecciona a form de compra
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonComprar_Click(object sender, EventArgs e)
        {
            FormComprar fc = new FormComprar(local);
            fc.ShowDialog();
        }

        private void FormInicio_Load(object sender, EventArgs e)
        {
            // Para cargar por primera vez la BD

            //local.Productos.Add(new Camiseta(10, 'S', 5000f, "ROJO", 0, "CAMIS-ROJA-S"));
            //local.Productos.Add(new Camiseta(15, 'M', 5000f, "ROJO", 0, "CAMIS-ROJA-M"));
            //local.Productos.Add(new Camiseta(10, 'L', 5000f, "ROJO", 0, "CAMIS-ROJA-L"));

            //local.Productos.Add(new Camiseta(4, 'S', 6000f, "AZUL", 0, "CAMIS-AZUL-S"));
            //local.Productos.Add(new Camiseta(6, 'M', 6000f, "AZUL", 0, "CAMIS-AZUL-M"));
            //local.Productos.Add(new Camiseta(0, 'L', 6000f, "AZUL", 0, "CAMIS-AZUL-L"));


            //local.Productos.Add(new Camiseta(11, 'S', 6500f, "NEGRO", 0, "CAMIS-NEGRA-S"));
            //local.Productos.Add(new Camiseta(13, 'M', 6500f, "NEGRO", 0, "CAMIS-NEGRA-M"));
            //local.Productos.Add(new Camiseta(5, 'L', 6500f, "NEGRO", 0, "CAMIS-NEGRA-L"));

            //local.Productos.Add(new Buzo(1, 'S', 6000f, "ROJO", 0, "BUZO-ROJO-S"));
            //local.Productos.Add(new Buzo(0, 'M', 6000f, "ROJO", 0, "BUZO-ROJO-M"));
            //local.Productos.Add(new Buzo(5, 'L', 6000f, "ROJO", 0, "BUZO-ROJO-L"));

            //local.Productos.Add(new Buzo(5, 'S', 6500f, "NEGRO", 0, "BUZO-NEGRO-S"));
            //local.Productos.Add(new Buzo(10, 'M', 6500f, "NEGRO", 0, "BUZO-NEGRO-M"));
            //local.Productos.Add(new Buzo(11, 'L', 6500f, "NEGRO", 0, "BUZO-NEGRO-L"));


            //ProductoDAO p = new ProductoDAO();

            //foreach (Producto item in local.Productos)
            //{
            //    p.InsertarProducto(item);
            //}
        }

        /// <summary>
        /// Redirecciona a form estadistico
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonIngresar_Click(object sender, EventArgs e)
        {
            FormEmpleados fe = new FormEmpleados(local);
            fe.ShowDialog();
        }
    }
}
