using System;
using System.Collections.Generic;

class Producto
{
    static void Main(string[] args)
    {
        // Lista de productos
        List<ProductoInfo> inventario = new List<ProductoInfo>();

        int opcion;

        do
        {
            Console.WriteLine("\n===== INVENTARIO DE PRODUCTOS =====");
            Console.WriteLine("1. Registrar producto");
            Console.WriteLine("2. Mostrar productos");
            Console.WriteLine("3. Buscar producto");
            Console.WriteLine("4. Salir");
            Console.Write("Seleccione una opcion: ");

            if (!int.TryParse(Console.ReadLine(), out opcion))
            {
                Console.WriteLine("Ingrese una opcion valida.");
                opcion = 0;
                continue;
            }

            switch (opcion)
            {
                case 1:
                    RegistrarProducto(inventario);
                    break;

                case 2:
                    MostrarProductos(inventario);
                    break;

                case 3:
                    BuscarProducto(inventario);
                    break;

                case 4:
                    Console.WriteLine("Saliendo del inventario...");
                    break;

                default:
                    Console.WriteLine("Opcion no valida.");
                    break;
            }

        } while (opcion != 4);
    }

    // Registrar un producto
    static void RegistrarProducto(List<ProductoInfo> inventario)
    {
        Console.WriteLine("\n===== REGISTRAR PRODUCTO =====");

        Console.Write("Ingrese el codigo: ");
        string codigo = Console.ReadLine();

        // Evitar codigos duplicados
        foreach (ProductoInfo producto in inventario)
        {
            if (producto.Codigo.Equals(codigo,
                StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("El codigo ya existe.");
                return;
            }
        }

        Console.Write("Ingrese el nombre: ");
        string nombre = Console.ReadLine();

        Console.Write("Ingrese el precio: ");

        if (!double.TryParse(Console.ReadLine(), out double precio)
            || precio < 0)
        {
            Console.WriteLine("Precio no valido.");
            return;
        }

        Console.Write("Ingrese la existencia: ");

        if (!int.TryParse(Console.ReadLine(), out int existencia)
            || existencia < 0)
        {
            Console.WriteLine("Existencia no valida.");
            return;
        }

        ProductoInfo nuevoProducto =
            new ProductoInfo(codigo, nombre, precio, existencia);

        inventario.Add(nuevoProducto);

        Console.WriteLine("\nProducto registrado correctamente.");
        nuevoProducto.MostrarInformacion();
    }

    // Mostrar todos los productos
    static void MostrarProductos(List<ProductoInfo> inventario)
    {
        Console.WriteLine("\n===== LISTA DE PRODUCTOS =====");

        if (inventario.Count == 0)
        {
            Console.WriteLine("No hay productos registrados.");
            return;
        }

        foreach (ProductoInfo producto in inventario)
        {
            producto.MostrarInformacion();
        }
    }

    // Buscar productos por codigo o nombre
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
public class ProductoInfo
{
    public string Codigo { get; set; }
    public string Nombre { get; set; }
    public double Precio { get; set; }
    public int Existencia { get; set; }

    public ProductoInfo(string codigo, string nombre,
                        double precio, int existencia)
    {
        Codigo = codigo;
        Nombre = nombre;
        Precio = precio;
        Existencia = existencia;
    }

    // Mostrar toda la informacion del producto
    public void MostrarInformacion()
    {
        Console.WriteLine("------------------------------");
        Console.WriteLine("Codigo: " + Codigo);
        Console.WriteLine("Nombre: " + Nombre);
        Console.WriteLine("Precio: $" + Precio.ToString("F2"));
        Console.WriteLine("Existencia: " + Existencia);
        Console.WriteLine("------------------------------");
    }
}
