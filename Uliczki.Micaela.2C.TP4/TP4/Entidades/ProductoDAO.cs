using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class ProductoDAO
    {
        public delegate void ProductoDBDelegate();
        private SqlConnection sqlConnection;
        public static event ProductoDBDelegate ProductosDBChanged;


        public ProductoDAO()
        {
            string connectionString = "Server=.;Database=TodoRojo;Trusted_Connection=True;";
            this.sqlConnection = new SqlConnection(connectionString);
        }

        /// <summary>
        /// se agrega el producto a la BD, pasando los parametros aperturados
        /// </summary>
        /// <param name="stock"></param>
        /// <param name="precio"></param>
        /// <param name="descripcion"></param>
        /// <param name="color"></param>
        /// <param name="talle"></param>
        public void InsertarProducto(int stock, double precio, string descripcion, Producto.EColor color, Producto.ETalle talle)
        {
            try
            {

                string command = $"INSERT INTO Productos(stock, precio, descripcion, color, talle)" +
                $"VALUES(@stock, @precio, @descripcion, @color, @talle)";

                SqlCommand sqlCommand = new SqlCommand(command, this.sqlConnection);

                sqlCommand.Parameters.Clear();
                sqlCommand.Parameters.AddWithValue("precio", precio);
                sqlCommand.Parameters.AddWithValue("stock", stock);
                sqlCommand.Parameters.AddWithValue("descripcion", descripcion);
                sqlCommand.Parameters.AddWithValue("color", color);
                sqlCommand.Parameters.AddWithValue("talle", talle);
                this.sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new TodoRojoException("Ocurrió un error al tratar de guardar producto en la BD.", ex);
            }
            finally
            {
                if (sqlConnection != null && this.sqlConnection.State == System.Data.ConnectionState.Open)
                {
                    this.sqlConnection.Close();
                }


            }
        }


        /// <summary>
        /// se agrega el producto a la BD, pasando el producto
        /// </summary>
        /// <param name="p"></param>
        public void InsertarProducto(Producto p)
        {
            try
            {

                string command = $"INSERT INTO Productos(stock, precio, descripcion, color, talle)" +
                $"VALUES(@stock, @precio, @descripcion, @color, @talle)";

                SqlCommand sqlCommand = new SqlCommand(command, this.sqlConnection);

                sqlCommand.Parameters.Clear();
                sqlCommand.Parameters.AddWithValue("precio", p.Precio);
                sqlCommand.Parameters.AddWithValue("stock", p.Stock);
                sqlCommand.Parameters.AddWithValue("descripcion", p.Descripcion);
                sqlCommand.Parameters.AddWithValue("color", p.Color);
                sqlCommand.Parameters.AddWithValue("talle", p.Talle);
                this.sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new TodoRojoException("Ocurrió un error al tratar de guardar el producto de la BD.", ex);
            }
            finally
            {
                if (sqlConnection != null && this.sqlConnection.State == System.Data.ConnectionState.Open)
                {
                    this.sqlConnection.Close();
                }


            }
        }

        /// <summary>
        /// Borra un producto de la BD segun el codigo
        /// </summary>
        /// <param name="codigo"></param>
        public void BorrarProductoPorId(int codigo)
        {
            try
            {
                string command = $"DELETE FROM Productos " +
                $"WHERE codigo=@codigo;";

                SqlCommand sqlCommand = new SqlCommand(command, this.sqlConnection);
                sqlCommand.Parameters.Clear();
                sqlCommand.Parameters.AddWithValue("codigo", codigo);
                this.sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
                ProductosDBChanged.Invoke();
            }
            catch (Exception ex)
            {
                throw new TodoRojoException("Ocurrió un error al tratar de borrar el producto de la BD.", ex);
            }
            finally
            {
                if (sqlConnection != null && this.sqlConnection.State == System.Data.ConnectionState.Open)
                {
                    this.sqlConnection.Close();
                }


            }
        }

        /// <summary>
        /// Modifica el precio de un prodcuto segun el codigo
        /// </summary>
        /// <param name="codigo"></param>
        /// <param name="precio"></param>
        public void ModificarProductoPorId(int codigo, float precio)
        {
            try
            {
                string command = $"UPDATE Productos SET precio=@nuevoPrecio " +
                $"WHERE codigo=@codigo;";

                SqlCommand sqlCommand = new SqlCommand(command, this.sqlConnection);
                sqlCommand.Parameters.Clear();
                sqlCommand.Parameters.AddWithValue("codigo", codigo);
                sqlCommand.Parameters.AddWithValue("codigo", precio);
                this.sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
                ProductosDBChanged.Invoke();
            }
            catch (Exception ex)
            {
                throw new TodoRojoException("Ocurrió un error al tratar de modificar el producto de la BD.", ex);
            }
            finally
            {
                if (sqlConnection != null && this.sqlConnection.State == System.Data.ConnectionState.Open)
                {
                    this.sqlConnection.Close();
                }


            }
        }

        /// <summary>
        /// Devuelve una lista de productos leida de la BD
        /// </summary>
        /// <returns></returns>
        public List<Producto> Leer()
        {
            try
            {
                string command = $"SELECT * FROM Productos;";

                string connectionString = "Server=.;Database=TodoRojo;Trusted_Connection=True;";
                this.sqlConnection = new SqlConnection(connectionString);
                this.sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand(command, this.sqlConnection);
                SqlDataReader reader = sqlCommand.ExecuteReader();

                List<Producto> productos = new List<Producto>();

                while (reader.Read())
                {
                    int codigo = (int)reader["Codigo"];
                    string desc = (string)reader["Descripcion"];
                    double precio = Convert.ToSingle(reader["Precio"]);
                    int stock = (int)reader["Stock"];
                    string color = (string)reader["color"];
                    char talle = ((string)(reader["talle"]))[0];
                    Producto p;

                    if (desc.Contains("Buzo"))
                    {
                        p = new Buzo(stock, talle, precio, color, codigo, desc, "ALGODON");
                    }
                    else
                    {
                        p = new Camiseta(stock, talle, precio, color, codigo, desc);
                    }
                    productos.Add(p);
                }

                return productos;
            }
            catch (Exception ex)
            {
                throw new TodoRojoException("Ocurrió un error al tratar de leer la lista de productos de la BD.", ex);
            }
            finally
            {
                if (sqlConnection != null && this.sqlConnection.State == System.Data.ConnectionState.Open)
                {
                    this.sqlConnection.Close();
                }

            }


        }

    }
}
