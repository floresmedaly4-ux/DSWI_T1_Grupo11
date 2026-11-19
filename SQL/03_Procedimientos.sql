USE InventarioBD;
GO

CREATE OR ALTER PROCEDURE dbo.usp_Producto_Listar
    
AS
BEGIN
    SET NOCOUNT ON;
    SELECT ProductoID, Nombre, Categoria
    FROM dbo.Productos
    ORDER BY ProductoID;
END;
GO

CREATE OR ALTER PROCEDURE dbo.usp_Producto_ObtenerPorId
    @Id int
AS
BEGIN
    SET NOCOUNT ON;
    SELECT ProductoID, Nombre, Categoria
    FROM dbo.Productos
    WHERE ProductoID = @Id;
END;
GO

CREATE OR ALTER PROCEDURE dbo.usp_Producto_Crear
    @Nombre nvarchar(100),
    @Categoria nvarchar(50)
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO dbo.Productos (Nombre, Categoria)
    OUTPUT inserted.ProductoID, inserted.Nombre, inserted.Categoria
    VALUES (@Nombre, @Categoria);
END;
GO

CREATE OR ALTER PROCEDURE dbo.usp_Producto_Editar
    @Id int,
    @Nombre nvarchar(100),
    @Categoria nvarchar(50)
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE dbo.Productos
    SET Nombre = @Nombre,
        Categoria = @Categoria
    OUTPUT inserted.ProductoID, inserted.Nombre, inserted.Categoria
    WHERE ProductoID = @Id;
END;
GO

CREATE OR ALTER PROCEDURE dbo.usp_Inventario_Listar
    
AS
BEGIN
    SET NOCOUNT ON;
    SELECT InventarioID, FechaIngreso, Cantidad, Ubicacion, Estado, ProductoID
    FROM dbo.Inventario
    ORDER BY InventarioID;
END;
GO

CREATE OR ALTER PROCEDURE dbo.usp_Inventario_ObtenerPorId
    @Id int
AS
BEGIN
    SET NOCOUNT ON;
    SELECT InventarioID, FechaIngreso, Cantidad, Ubicacion, Estado, ProductoID
    FROM dbo.Inventario
    WHERE InventarioID = @Id;
END;
GO

CREATE OR ALTER PROCEDURE dbo.usp_Inventario_Crear
    @FechaIngreso date,
    @Cantidad int,
    @Ubicacion nvarchar(100),
    @Estado nvarchar(50),
    @ProductoID int
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO dbo.Inventario (FechaIngreso, Cantidad, Ubicacion, Estado, ProductoID)
    OUTPUT inserted.InventarioID, inserted.FechaIngreso, inserted.Cantidad, inserted.Ubicacion, inserted.Estado, inserted.ProductoID
    VALUES (@FechaIngreso, @Cantidad, @Ubicacion, @Estado, @ProductoID);
END;
GO

CREATE OR ALTER PROCEDURE dbo.usp_Inventario_Editar
    @Id int,
    @FechaIngreso date,
    @Cantidad int,
    @Ubicacion nvarchar(100),
    @Estado nvarchar(50),
    @ProductoID int
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE dbo.Inventario
    SET FechaIngreso = @FechaIngreso,
        Cantidad = @Cantidad,
        Ubicacion = @Ubicacion,
        Estado = @Estado,
        ProductoID = @ProductoID
    OUTPUT inserted.InventarioID, inserted.FechaIngreso, inserted.Cantidad, inserted.Ubicacion, inserted.Estado, inserted.ProductoID
    WHERE InventarioID = @Id;
END;
GO
