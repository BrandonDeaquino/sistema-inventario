
using System;
using System.Collections.Generic;

class Producto
{
    static void Main(string[] args)
    {
        
    }

    // Funcion para buscar productos por codigo o nombre
    static void BuscarProducto(List<ProductoInfo> inventario)
    {
        Console.Write("\nIngrese el codigo o nombre del producto: ");
        string busqueda = Console.ReadLine();

        bool encontrado = false;

        foreach (ProductoInfo producto in inventario)
        {
            if (producto.Codigo.Equals(busqueda,
                StringComparison.OrdinalIgnoreCase) ||
                producto.Nombre.Contains(busqueda,
                StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("\nProducto encontrado:");
                producto.MostrarInformacion();
                encontrado = true;
            }
        }

        if (!encontrado)
        {
            Console.WriteLine("\nNo se encontro el producto.");
        }
    }
}

// Clase para representar los datos del producto
class ProductoInfo
{
    public string Codigo { get; set; }
    public string Nombre { get; set; }


    public void MostrarInformacion()
    {
        Console.WriteLine("\n===== INFORMACION DEL SErvivio =====");
        Console.WriteLine("Codigo: " + Codigo);
        Console.WriteLine("Nombre: " + Nombre);
        Console.WriteLine("Precio: $" + Precio);
        Console.WriteLine("Existencia: " + Existencia);
        Console.WriteLine("====================================");
    }
}
