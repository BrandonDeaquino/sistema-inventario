
using System;
using System.Collections.Generic;

class Producto
{
    static void Main(string[] args)
    {
        // Lista de productos
        List<ProductoInfo> inventario = new List<ProductoInfo>();

        // Productos de ejemplo
        inventario.Add(new ProductoInfo("P001", "Teclado", 450, 20));
        inventario.Add(new ProductoInfo("P002", "Mouse", 250, 15));
        inventario.Add(new ProductoInfo("P003", "Monitor", 3500, 10));
        inventario.Add(new ProductoInfo("P004", "Laptop", 12000, 5));

        int opcion;

        do
        {
            Console.WriteLine("\n===== INVENTARIO DE PRODUCTOS =====");
            Console.WriteLine("1. Mostrar productos");
            Console.WriteLine("2. Buscar producto");
            Console.WriteLine("3. Salir");
            Console.Write("Seleccione una opcion: ");

            opcion = Convert.ToInt32(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    foreach (ProductoInfo producto in inventario)
                    {
                        producto.MostrarInformacion();
                    }
                    break;

                case 2:
                    BuscarProducto(inventario);
                    break;

                case 3:
                    Console.WriteLine("Saliendo del inventario...");
                    break;

                default:
                    Console.WriteLine("Opcion no valida.");
                    break;
            }

        } while (opcion != 3);
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
