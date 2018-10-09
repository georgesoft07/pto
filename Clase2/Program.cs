using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using Clase2.DAL;

namespace Clase2
{
    class Program
    {
        static void Main(string[] args)
        {
            ServicioDeProductos servicioProducto = new ServicioDeProductos();
            NuevoProducto nuevoProducto = new NuevoProducto();
            nuevoProducto.Nombre = "produto 2";
            nuevoProducto.CantidadMinima = 10;
            nuevoProducto.StockActual = 20;
            servicioProducto.CrearUnNuevoProducto(nuevoProducto);

            servicioProducto.ListarTodosLosProductos().ForEach(producto => Console.WriteLine(producto.Nombre));
            Console.ReadKey();
        }
    }
}
