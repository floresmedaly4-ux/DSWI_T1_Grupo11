# DSWI_T1_Grupo11

Evaluación T1 de Desarrollo de Servicios Web I. La página de inicio permite abrir los ejercicios de descuento de moto y consumo eléctrico, además del mantenimiento de Productos e Inventario.

## Ejecutar el proyecto

1. En SQL Server Management Studio, abre `SQL/InventarioDB.txt` en una consulta y ejecútalo una sola vez para crear la base `InventarioBD` con los datos del profesor. Si ya creaste la base con ese archivo, continúa con el paso 2.
2. Ejecuta `SQL/Procedimientos.sql` en la misma instancia. Instala los ocho procedimientos para listar, buscar, crear y editar productos y registros de inventario.
3. Abre `DSWI_T1_Grupo11/DSWI_T1_Grupo11.slnx` en Visual Studio con .NET 10. La conexión `ConexionSQL` en `appsettings.json` usa LocalDB. Si ejecutaste los scripts en otra instancia, cambia el valor de `Server` por el nombre de esa instancia.
4. Restaura los paquetes NuGet e inicia el proyecto. Desde la página principal, abre **Productos** para registrar o editar un producto y **Inventario** para registrar su ingreso.

## Ingeniería inversa con Entity Framework

Los modelos de `Models` y el contexto de `Data` se generaron desde las tablas del profesor. Para reproducir la generación en una copia limpia, selecciona el proyecto web en la Consola del Administrador de paquetes y ejecuta lo siguiente.

```powershell
Scaffold-DbContext "Name=ConnectionStrings:ConexionSQL" Microsoft.EntityFrameworkCore.SqlServer -Tables dbo.Productos,dbo.Inventario -OutputDir Models -ContextDir Data -Context InventarioContext -UseDatabaseNames -DataAnnotations -NoOnConfiguring -Force
```

El parámetro `-Force` reemplaza las clases generadas. Para ejecutar la aplicación basta con los archivos incluidos en el repositorio.
