using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    [Serializable]
    public abstract class Producto
    {
        public enum ETalle { S, M, L }
        public enum EColor { ROJO, NEGRO, AZUL }

        private int stock;
        private double precio;
        private int codigo;
        private string descripcion;
        private char talle;
        private string color;



        public Producto()
        {

        }

        /// <summary>
        /// Constructor. Inicializa los atributos del producto. 
        /// </summary>
        /// <param name="codigo">Codigo único (PK) del producto en la base de datos.</param>
        /// <param name="descripcion">Descripción del producto.</param>
        /// <param name="stock">Stock disponible del producto.</param>
        /// <param name="precio">Precio del producto.</param>
        /// <param name="talle">Talle del producto.</param>
        /// <param name="color">Color del producto.</param>

        public Producto(int stock, char talle, double precio, string color, int codigo, string descripcion)
        {
            this.stock = stock;
            this.precio = precio;
            this.codigo = codigo;
            this.descripcion = descripcion;
            this.talle = talle;
            this.color = color;
        }

        /// <summary>
        /// Stock del producto. Debe ser mayor a cero. 
        /// </summary>
        public int Stock
        {
            get
            {
                return this.stock;
            }
            set
            {
                if (value >= 0)
                {
                    this.stock = value;
                }
            }
        }

        /// <summary>
        /// Precio del producto. Debe ser mayor a 1. 
        /// </summary>
        public double Precio
        {
            get
            {
                return this.precio;
            }
            set
            {
                if (value >= 1)
                {
                    this.precio = value;
                }
            }
        }

        /// <summary>
        /// Descripción del producto. 
        /// </summary>
        public string Descripcion
        {
            get
            {
                return this.descripcion;
            }
            set
            {
                this.descripcion = value;
            }
        }

        /// <summary>
        /// Talle del producto. 
        /// </summary>
        public char Talle
        {
            get
            {
                return this.talle;
            }

            set
            {
                this.talle = value;
            }
        }

        /// <summary>
        /// Color del producto. 
        /// </summary>
        public string Color
        {
            get
            {
                return this.color;
            }

            set
            {
                this.color = value;
            }
        }

        /// <summary>
        /// Código del producto en la base de datos (PK). 
        /// Propiedad de sólo lectura. 
        /// </summary>
        public int Codigo
        {
            get
            {
                return this.codigo;
            }
        }

        /// <summary>
        /// Devuelve un string con los datos de un producto: código, descripción, precio y stock. 
        /// </summary>
        /// <returns></returns>
        protected virtual string Mostrar()
        {
            StringBuilder stb = new StringBuilder();
            stb.AppendLine($"{this.Descripcion}");
            stb.AppendLine($"CODIGO: {this.Codigo}");
            stb.AppendLine($"COLOR: {this.Color}");
            stb.AppendLine($"TALLE: {this.Talle}");
            stb.AppendLine($"PRECIO SIN IVA: {this.Precio.FormatearPrecio()}");
            stb.AppendLine($"STOCK: {this.Stock}");

            return stb.ToString();
        }

        /// <summary>
        /// Invoca al método mostrar, y retorna string con los datos de un producto: código, descripción, color, talle, precio y stock. 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.Mostrar();
        }
    }
}
