using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;
using VistaForm.Properties;

namespace VistaForm
{
    public partial class FormComprar : Form
    {
        private Local local;
        private Producto productoSeleccionado;
        private Thread hiloSecundario;

        public FormComprar(Local local)
        {
            InitializeComponent();
            this.local = local;
            this.local.productosListChanged += ActualizarLista;

            hiloSecundario = new Thread(AnimarEscudo);
            hiloSecundario.Start();
        }

        private void FormComprar_Load(object sender, EventArgs e)
        {
            this.ActualizarLista();
        }


        /// <summary>
        /// Actualiza el ListBox de productos y la lista de ventas.
        /// </summary>
        private void ActualizarLista()
        {
            try
            {
                this.listBoxProductos.DataSource = null;
                this.listBoxProductos.Refresh();
                this.listBoxProductos.DataSource = this.local.Productos;
                this.listBoxProductos.DisplayMember = "Descripcion";

                if (this.local.Productos != null && this.local.Productos.Count > 0)
                {
                    this.listBoxProductos.SelectedIndex = 0;
                    this.ActualizarProductoSeleccionado();
                }
            }
            catch (Exception ex)
            {
                this.ManejarExcepciones(ex);
            }
        }


        /// <summary>
        /// Actualiza el campo ProductoSeleccionado cuando se selecciona otro producto de la lista.
        /// </summary>
        private void ActualizarProductoSeleccionado()
        {
            try
            {
                this.productoSeleccionado = (Producto)this.listBoxProductos.SelectedValue;
                if (productoSeleccionado != null)
                {
                    this.richTextBoxDetalle.Text = this.productoSeleccionado.ToString();
                }
            }
            catch (Exception ex)
            {
                this.ManejarExcepciones(ex);
            }
        }



        /// <summary>
        /// Abre el ExcepcionesForm para mostrar el error al usuario.
        /// </summary>
        /// <param name="ex"></param>
        private void ManejarExcepciones(Exception ex)
        {
            ExcepcionesForm form = new ExcepcionesForm(ex);
            form.ShowDialog();
        }


        /// <summary>
        /// Manejador del evento SelectedIndexChanged del ListBox de productos. 
        /// Mantendrá el campo "productoSeleccionado" actualizado con el producto seleccionado actualmente por el usuario.
        /// Y actualizará el texto del richTextBox de detalle y las imagenes del pictureboxproducto. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listBoxProductos_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActualizarProductoSeleccionado();

            if (this.productoSeleccionado.Descripcion.Contains("CAMIS"))
            {
                switch (this.productoSeleccionado.Color)
                {
                    case "ROJO":
                    this.pictureBoxImagenProducto.Image = Resources.camiseta_roja;
                        break;

                    case "AZUL":
                        this.pictureBoxImagenProducto.Image = Resources.camiseta_azul;
                        break;

                    case "NEGRO":
                        this.pictureBoxImagenProducto.Image = Resources.camiseta_negra;
                        break;

                }

            }
            else
            {
                switch (this.productoSeleccionado.Color)
                {
                    case "ROJO":
                        this.pictureBoxImagenProducto.Image = Resources.buzo_rojo;
                        break;

                    case "NEGRO":
                        this.pictureBoxImagenProducto.Image = Resources.buzo_negro;
                        break;

                }
            }
        }


        /// <summary>
        /// Metodo que corre en el hilo secundario para hacer titilar el escudo
        /// </summary>
        private void AnimarEscudo()
        {
            while(true)
            {

                this.pictureBoxEscudo.Image = Resources.escudo;
                Thread.Sleep(1000);
                this.pictureBoxEscudo.Image = null;
                Thread.Sleep(1000);
            }
        }

        /// <summary>
        /// Chequear que se aborte el hilo secundario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormComprar_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(this.hiloSecundario != null && this.hiloSecundario.IsAlive)
            {
                this.hiloSecundario.Abort();
            }
        }


        /// <summary>
        /// Genera una nueva instancia del formulario de venta
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonComprar_Click(object sender, EventArgs e)
        {
            try
            {
                Form ventasForm = new FormVentas(this.local, productoSeleccionado);
                DialogResult result = ventasForm.ShowDialog();

            }
            catch (Exception ex)
            {
                this.ManejarExcepciones(ex);
            }
        }
    }
}
