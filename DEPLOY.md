# Procedimiento de Despliegue — Sistema de Inventario

## 1. Requisitos del entorno
- Sistema operativo: Windows, Linux o macOS.
- Entorno de ejecución: **.NET 10.0 Runtime** (o .NET 10.0 SDK).
  - Verificación: `dotnet --version` o `dotnet --list-runtimes`.
- Herramienta para descomprimir archivos `.zip`.

## 2. Versión a instalar
- Versión estable actual: **`v1.0.2`**
- Artefacto oficial: `sistema-inventario-v1.0.2.zip`

## 3. Descarga del paquete
1. Ingresar a la sección **Releases** del repositorio en GitHub:
   `https://github.com/BrandonDeaquino/sistema-inventario/releases/tag/v1.0.2`
2. Descargar el archivo `sistema-inventario-v1.0.2.zip` desde la sección **Assets**.
3. Guardarlo en el directorio de despliegue (por ejemplo, `despliegue-inventario/`).

## 4. Extracción de archivos
En Windows (PowerShell):
```powershell
Expand-Archive -Path .\sistema-inventario-v1.0.2.zip -DestinationPath .\v1.0.2 -Force
```
En Linux / macOS:
```bash
unzip -o sistema-inventario-v1.0.2.zip -d v1.0.2
```

## 5. Configuración necesaria
No requiere configuración adicional ni base de datos externa. Solo se debe verificar que en la carpeta `publish/` existan los archivos:
- `InventarioProductos.dll`
- `InventarioProductos.deps.json`
- `InventarioProductos.runtimeconfig.json`

## 6. Comando para ejecutar el sistema
```powershell
dotnet .\v1.0.2\publish\InventarioProductos.dll
```

## 7. Comprobación de funcionamiento
1. Verificar que se muestre el menú `===== INVENTARIO DE PRODUCTOS =====`.
2. Seleccionar la opción `1` para registrar un producto de prueba.
3. Seleccionar la opción `2` para listar los productos y confirmar que se muestra correctamente.
4. Seleccionar la opción `3` para buscar el producto por código o nombre.
5. Seleccionar la opción `4` para salir sin errores.

## 8. Problemas comunes y soluciones
- **`dotnet` no se reconoce como comando**: Instalar .NET 10.0 Runtime desde el sitio oficial de Microsoft y reiniciar la terminal.
- **Error de versión de runtime faltante**: Verificar con `dotnet --list-runtimes` que esté instalado `Microsoft.NETCore.App 10.0.x`.
- **Archivo `InventarioProductos.runtimeconfig.json` dañado o faltante**: Eliminar la carpeta extraída y volver a extraer el paquete `.zip` original descargado desde GitHub Releases.
