USE Northwind
SET nocount on
GO

IF db_name() <> 'Northwind'
   RAISERROR('Database Northwind not found', 22, 1) WITH LOG
GO

IF object_id('procModifyCategoryInfo') is not null
   DROP PROCEDURE procModifyCategoryInfo
GO

CREATE PROCEDURE procModifyCategoryInfo
   @CategoryID int = null,
   @CategoryName nvarchar(40) = null
AS 
BEGIN
   IF @CategoryID is null
   BEGIN
      RAISERROR('Category ID not supplied.',10,1)
      RETURN 1
   END

   IF not exists (SELECT * 
                    FROM Categories
                   WHERE CategoryID = @CategoryID)
   BEGIN
      RAISERROR('Category ID not on file.',10,1)
      RETURN 1
   END

   BEGIN TRANSACTION

   IF @CategoryName is not null
      UPDATE Categories 
         SET CategoryName = @CategoryName
         WHERE CategoryID = @CategoryID
   IF @@ERROR <> 0
   BEGIN
      ROLLBACK TRANSACTION
      RAISERROR('Unable to update Categories table.',10,1)
      RETURN 1
   END

	COMMIT TRANSACTION
   RETURN 0
END
GO

EXEC procModifyCategoryInfo 9, 'New Name'
EXEC procModifyCategoryInfo 9, 'Beer/Wine'
GO

SELECT CategoryName FROM Categories WHERE CategoryID = 9
GO
