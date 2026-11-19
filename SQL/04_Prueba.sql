USE InventarioBD;
GO
SET XACT_ABORT ON;
BEGIN TRY
    BEGIN TRANSACTION;
    DECLARE @p TABLE (id int, nombre nvarchar(100), categoria nvarchar(50));
    DECLARE @i TABLE (id int, fecha date, cantidad int, ubicacion nvarchar(100), estado nvarchar(50), producto int);
    INSERT @p EXEC dbo.usp_Producto_Crear N'Prueba T1', N'Prueba';
    DECLARE @pid int = (SELECT id FROM @p);
    IF @pid IS NULL THROW 51000, 'No se creó el producto.', 1;
    EXEC dbo.usp_Producto_Editar @pid, N'Producto editado', N'Prueba';
    DELETE FROM @p;
    INSERT @p EXEC dbo.usp_Producto_ObtenerPorId @pid;
    IF NOT EXISTS (SELECT 1 FROM @p WHERE nombre = N'Producto editado') THROW 51001, 'Falló la edición del producto.', 1;
    DELETE FROM @p;
    INSERT @p EXEC dbo.usp_Producto_Listar;
    IF NOT EXISTS (SELECT 1 FROM @p WHERE id = @pid) THROW 51002, 'Falló el listado de productos.', 1;

    INSERT @i EXEC dbo.usp_Inventario_Crear '20250101', 4, N'Almacén', N'Disponible', @pid;
    DECLARE @iid int = (SELECT id FROM @i);
    IF @iid IS NULL THROW 51003, 'No se creó el inventario.', 1;
    EXEC dbo.usp_Inventario_Editar @iid, '20250101', 6, N'Almacén', N'Disponible', @pid;
    DELETE FROM @i;
    INSERT @i EXEC dbo.usp_Inventario_ObtenerPorId @iid;
    IF NOT EXISTS (SELECT 1 FROM @i WHERE cantidad = 6 AND producto = @pid) THROW 51004, 'Falló la edición del inventario.', 1;
    DELETE FROM @i;
    INSERT @i EXEC dbo.usp_Inventario_Listar;
    IF NOT EXISTS (SELECT 1 FROM @i WHERE id = @iid) THROW 51005, 'Falló el listado de inventario.', 1;
    ROLLBACK TRANSACTION;
    PRINT N'Prueba correcta. Se revirtieron los registros temporales.';
END TRY
BEGIN CATCH
    IF XACT_STATE() <> 0 ROLLBACK TRANSACTION;
    THROW;
END CATCH;
