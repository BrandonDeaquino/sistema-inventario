
using System;

class Producto
{
    static void Main(string[] args)
    {
        // Solicitar los datos del producto
        Console.WriteLine("===== INVENTARIO DE PRODUCTOS =====");

        Console.Write("Ingrese el codigo del producto: ");
        string codigo = Console.ReadLine();

        Console.Write("Ingrese el nombre del producto: ");
        string nombre = Console.ReadLine();

        Console.Write("Ingrese el precio del producto: ");
        double precio = Convert.ToDouble(Console.ReadLine());

        Console.Write("Ingrese la existencia en inventario: ");
        int existencia = Convert.ToInt32(Console.ReadLine());

        // Mostrar informacion del producto
        Console.WriteLine("\n===== INFORMACION DEL PRODUCTO =====");
        Console.WriteLine("Codigo: " + codigo);
        Console.WriteLine("Nombre: " + nombre);
        Console.WriteLine("Precio: $" + precio);
        Console.WriteLine("Existencia: " + existencia);
        Console.WriteLine("====================================");

        Console.WriteLine("\nPresione una tecla para salir...");
        Console.ReadKey();
    }
}
