USE Northwind
SET nocount on
GO

IF db_name() <> 'Northwind'
   RAISERROR('Database Northwind not found', 22, 1) WITH LOG
GO

IF object_id('procModifyProductInfo') is not null
   DROP PROCEDURE procModifyProductInfo
GO

CREATE PROCEDURE procModifyProductInfo
   @ProductID int = null,
   @ProductName nvarchar(40) = null,
   @UnitPrice money = null
AS 
BEGIN
   IF @ProductID is null
   BEGIN
      RAISERROR('Product ID not supplied.',10,1)
      RETURN 1
   END

   IF not exists (SELECT * 
                    FROM Products
                   WHERE ProductID = @ProductID)
   BEGIN
      RAISERROR('Product ID not on file.',10,1)
      RETURN 1
   END

   BEGIN TRANSACTION

   IF @ProductName is not null
      UPDATE Products 
         SET ProductName = @ProductName
         WHERE ProductID = @ProductID
   IF @@ERROR <> 0
   BEGIN
      ROLLBACK TRANSACTION
      RAISERROR('Unable to update Products table.',10,1)
      RETURN 1
   END

   IF @UnitPrice is not null
      UPDATE Products 
         SET UnitPrice = @UnitPrice
         WHERE ProductID = @ProductID
   IF @@ERROR <> 0
   BEGIN
      ROLLBACK TRANSACTION
      RAISERROR('Unable to update Products table.',10,1)
      RETURN 1
   END

	COMMIT TRANSACTION
   RETURN 0
END
GO

EXEC procModifyProductInfo 18, 'New Name', 100.00
EXEC procModifyProductInfo 18, 'Carnavon Tigers', 987.65
GO

SELECT ProductName FROM Products WHERE ProductID = 18
GO
