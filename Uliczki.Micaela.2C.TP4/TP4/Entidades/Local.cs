using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Local
    {
        private List<Producto> productos;
        private List<Venta> ventas;
        public event Action productosListChanged;

        /// <summary>
        /// Constructor, instancia los campos de tipo lista. 
        /// Asocia el evento de cambios en la tabla de productos para actualizar la lista.
        /// </summary>
        public Local()
        {
            ProductoDAO p = new ProductoDAO();
            productos = p.Leer();

            ProductoDAO.ProductosDBChanged += ActualizarListaProductos;
            this.ventas = new List<Venta>();
        }



        /// <summary>
        /// Devuelve o carga la lista de productos.
        /// </summary>
        public List<Producto> Productos
        {
            get
            {
                return this.productos;
            }
            set
            {
                this.productos = value;
                this.productosListChanged();
            }
        }

        /// <summary>
        /// Verifica si un producto se encuentra en la lista de productos.
        /// </summary>
        /// <param name="comiqueria"></param>
        /// <param name="producto"></param>
        /// <returns></returns>
        public static bool operator ==(Local local, Producto producto)
        {
            foreach (Producto prod in local.productos)
            {
                if (prod.Codigo == producto.Codigo)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Verifica si un producto NO se encuentra en la lista de productos. 
        /// </summary>
        /// <param name="comiqueria"></param>
        /// <param name="producto"></param>
        /// <returns></returns>
        public static bool operator !=(Local local, Producto producto)
        {
            return !(local == producto);
        }

        /// <summary>
        /// Genera una nueva venta.
        /// </summary>
        /// <param name="producto">Producto a Vender.</param>
        /// <param name="cantidad">Cantidad solicitada del producto.</param>
        public void Vender(Producto producto, int cantidad)
        {
            Venta nuevaVenta = new Venta(producto, cantidad);
            this.ventas.Add(nuevaVenta);

            string ruta = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), String.Format(@"Venta_{0}.bin", nuevaVenta.Fecha.ToString("ddMMyyyy_HHmmss")));


            Serializador<Venta> ser = new Serializador<Venta>();

            ser.SerializarBinario(nuevaVenta, ruta);

        }

        /// <summary>
        /// Devuelve un string conteniendo la descripción breve de cada venta en la lista de ventas. 
        /// </summary>
        /// <returns></returns>
        public string ListarVentas()
        {

            StringBuilder sb = new StringBuilder();
            foreach (Venta venta in this.ventas)
            {
                sb.AppendLine(venta.ObtenerDescripcionBreve());
            }

            return sb.ToString();
        }

        /// <summary>
        /// Metodo que maneja el evento. Mantiene actualizada la lista de productos
        /// </summary>
        private void ActualizarListaProductos()
        {
            ProductoDAO p = new ProductoDAO();
            this.Productos = p.Leer();
        }

        /// <summary>
        /// Sobrecarga del metodo tostring, devuelve los productos disponibles
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder stb = new StringBuilder();

            foreach (Producto item in this.productos)
            {
                stb.AppendLine(item.ToString());
            }

            return stb.ToString();
        }
    }
}
