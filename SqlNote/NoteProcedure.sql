CREATE PROCEDURE sp_SelectedNotes
AS
BEGIN
	SELECT TOP (1000) [NoteId]
	      ,[NoteHeader]
	      ,[NoteDescr]
	      ,[NoteDate]
	  FROM [SqlNote].[dbo].[Notes]
END