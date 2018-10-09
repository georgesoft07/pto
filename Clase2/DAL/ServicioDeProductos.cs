using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clase2.DAL
{
    public class ServicioDeProductos
    {
        public void CrearUnNuevoProducto(NuevoProducto producto) {
            SqlConnection conection = this.iniciarConexion();
            SqlCommand comando = new SqlCommand("CrearProducto", conection);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Add(new SqlParameter("@Nombre", producto.Nombre));
            comando.Parameters.Add(new SqlParameter("@CantidadMinima", producto.CantidadMinima));
            comando.Parameters.Add(new SqlParameter("@StockActual", producto.StockActual));
            conection.Open();
            comando.ExecuteNonQuery();
            conection.Close();
        }

        public List<ProductoGenerico> ListarTodosLosProductos() {
            SqlConnection conection = this.iniciarConexion();
            SqlCommand comando = new SqlCommand("ListarTodosLosProductos", conection);
            comando.CommandType = CommandType.StoredProcedure;
            conection.Open();
            SqlDataReader lectorDeDatos = comando.ExecuteReader();
            List<ProductoGenerico> productos = new List<ProductoGenerico>();
            while (lectorDeDatos.Read())
            {
                ProductoGenerico producto = new ProductoGenerico();
                producto.Id = (int)lectorDeDatos.GetInt32(0);
                producto.Nombre = lectorDeDatos.GetString(1);
                producto.StockActual = (int)lectorDeDatos.GetInt32(2);
                producto.StockActual = (int)lectorDeDatos.GetInt32(3);
                productos.Add(producto);
            }
            conection.Close();
            return productos;
        }

        private SqlConnection iniciarConexion() {
            SqlConnection conection = new SqlConnection();
            conection.ConnectionString = ConfigurationManager.ConnectionStrings["Tienda"].ConnectionString;
            return conection;
        }


    }
}
