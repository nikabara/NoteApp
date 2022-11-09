CREATE PROCEDURE sp_SelectedErrors
AS
BEGIN
	SELECT TOP (1000) [ErrorId]
	      ,[ErrorNumber]
	      ,[ErrorState]
	      ,[ErrorSeverity]
	      ,[ErrorMessage]
	      ,[ErrorLine]
	  FROM [SqlNote].[dbo].[ErrorLog]
END