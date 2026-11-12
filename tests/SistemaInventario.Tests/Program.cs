
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

class Program
{
    static int pruebasCorrectas = 0;
    static int pruebasIncorrectas = 0;

    static List<string> resultados = new List<string>();

    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        Console.WriteLine();
        Console.WriteLine("==============================================");
        Console.WriteLine("          EJECUTOR DE PRUEBAS");
        Console.WriteLine("          SISTEMA DE INVENTARIO");
        Console.WriteLine("==============================================");

        // Ejecutar los siete casos de prueba
        EjecutarPrueba("CP01 - Crear producto", CP01);
        EjecutarPrueba("CP02 - Mostrar código", CP02);
        EjecutarPrueba("CP03 - Mostrar nombre", CP03);
        EjecutarPrueba("CP04 - Mostrar precio", CP04);
        EjecutarPrueba("CP05 - Mostrar existencia", CP05);
        EjecutarPrueba("CP06 - Mostrar información", CP06);
        EjecutarPrueba("CP07 - Crear segundo producto", CP07);

        // Mostrar reporte final
        Console.WriteLine();
        Console.WriteLine("==============================================");
        Console.WriteLine("           RESULTADOS DE LAS PRUEBAS");
        Console.WriteLine("==============================================");
        Console.WriteLine();

        foreach (string resultado in resultados)
        {
            Console.WriteLine(resultado);
        }

        Console.WriteLine();
        Console.WriteLine("----------------------------------------------");
        Console.WriteLine(
            $"Pruebas correctas:   {pruebasCorrectas}");

        Console.WriteLine(
            $"Pruebas incorrectas: {pruebasIncorrectas}");

        Console.WriteLine("----------------------------------------------");

        Console.WriteLine(
            $"Resultado: {pruebasCorrectas} de 7 pruebas satisfactorias.");

        Console.WriteLine("==============================================");

        if (pruebasIncorrectas > 0)
        {
            Environment.ExitCode = 1;
        }
    }

    // Método encargado de ejecutar y registrar cada prueba
    static void EjecutarPrueba(string nombre, Action prueba)
    {
        try
        {
            prueba();

            pruebasCorrectas++;

            resultados.Add($"{nombre,-35} CORRECTO");
        }
        catch (Exception ex)
        {
            pruebasIncorrectas++;

            resultados.Add($"{nombre,-35} INCORRECTO");

            Console.WriteLine();
            Console.WriteLine($"Error en {nombre}: {ex.Message}");
        }
    }

    // Crear producto de prueba
    static ProductoInfo CrearProducto()
    {
        return new ProductoInfo("P001", "Teclado", 350, 10);
    }

    // Comprobar que un valor sea igual al esperado
    static void Verificar<T>(T esperado, T obtenido, string campo)
    {
        if (!EqualityComparer<T>.Default.Equals(esperado, obtenido))
        {
            throw new Exception(
                $"{campo}: se esperaba '{esperado}', pero se obtuvo '{obtenido}'.");
        }
    }

    // Capturar la información mostrada en consola
    static string CapturarInformacion(ProductoInfo producto)
    {
        TextWriter salidaOriginal = Console.Out;
        CultureInfo culturaOriginal = CultureInfo.CurrentCulture;

        using StringWriter escritor = new StringWriter();

        try
        {
            Console.SetOut(escritor);
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

            producto.MostrarInformacion();

            return escritor.ToString();
        }
        finally
        {
            Console.SetOut(salidaOriginal);
            CultureInfo.CurrentCulture = culturaOriginal;
        }
    }

    // CP01: Crear producto
    static void CP01()
    {
        ProductoInfo producto = CrearProducto();

        Verificar("P001", producto.Codigo, "Código");
        Verificar("Teclado", producto.Nombre, "Nombre");
        Verificar(350.0, producto.Precio, "Precio");
        Verificar(10, producto.Existencia, "Existencia");
    }

    // CP02: Mostrar código
    static void CP02()
    {
        ProductoInfo producto = CrearProducto();

        string resultado = CapturarInformacion(producto);

        if (!resultado.Contains("Codigo: P001"))
            throw new Exception("No se mostró el código P001.");
    }

    // CP03: Mostrar nombre
    static void CP03()
    {
        ProductoInfo producto = CrearProducto();

        string resultado = CapturarInformacion(producto);

        if (!resultado.Contains("Nombre: Teclado"))
            throw new Exception("No se mostró el nombre Teclado.");
    }

    // CP04: Mostrar precio
    static void CP04()
    {
        ProductoInfo producto = CrearProducto();

        string resultado = CapturarInformacion(producto);

        if (!resultado.Contains("Precio: $350.00"))
            throw new Exception("El precio mostrado no es correcto.");
    }

    // CP05: Mostrar existencia
    static void CP05()
    {
        ProductoInfo producto = CrearProducto();

        string resultado = CapturarInformacion(producto);

        if (!resultado.Contains("Existencia: 10"))
            throw new Exception("La existencia mostrada no es correcta.");
    }

    // CP06: Mostrar toda la información
    static void CP06()
    {
        ProductoInfo producto = CrearProducto();

        string resultado = CapturarInformacion(producto);

        if (!resultado.Contains("Codigo: P001") ||
            !resultado.Contains("Nombre: Teclado") ||
            !resultado.Contains("Precio: $350.00") ||
            !resultado.Contains("Existencia: 10"))
        {
            throw new Exception(
                "La información completa del producto no coincide.");
        }
    }

    // CP07: Crear segundo producto sin alterar el primero
    static void CP07()
    {
        ProductoInfo producto1 =
            new ProductoInfo("P001", "Teclado", 350, 10);

        ProductoInfo producto2 =
            new ProductoInfo("P002", "Mouse", 180, 5);

        Verificar("P001", producto1.Codigo, "Código del primer producto");
        Verificar("Teclado", producto1.Nombre, "Nombre del primer producto");
        Verificar(350.0, producto1.Precio, "Precio del primer producto");
        Verificar(10, producto1.Existencia, "Existencia del primer producto");

        Verificar("P002", producto2.Codigo, "Código del segundo producto");
        Verificar("Mouse", producto2.Nombre, "Nombre del segundo producto");
        Verificar(180.0, producto2.Precio, "Precio del segundo producto");
        Verificar(5, producto2.Existencia, "Existencia del segundo producto");
    }
}
