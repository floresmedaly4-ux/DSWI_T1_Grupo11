USE InventarioBD;
GO
SELECT DB_NAME() AS BaseActual;
SELECT ProductoID, Nombre, Categoria FROM dbo.Productos ORDER BY ProductoID;
SELECT i.InventarioID, i.FechaIngreso, i.Cantidad, i.Ubicacion, i.Estado,
       i.ProductoID, p.Nombre AS NombreProducto
FROM dbo.Inventario AS i
LEFT JOIN dbo.Productos AS p ON p.ProductoID = i.ProductoID
ORDER BY i.InventarioID;
