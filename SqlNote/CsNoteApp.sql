CREATE DATABASE SqlNote 
GO

USE SqlNote
GO

BEGIN TRANSACTION
		BEGIN TRY
			CREATE TABLE Notes (
				NoteId INT PRIMARY KEY IDENTITY NOT NULL,
				NoteHeader NVARCHAR(50) CHECK(LEN(NoteHeader) <= 50) NULL,
				NoteDescr NVARCHAR(MAX) CHECK(LEN(NoteDescr) > 1) NOT NULL,
				NoteDate DATE DEFAULT(GETDATE()) NOT NULL
			)
		
			DECLARE @NoteHeaderVar NVARCHAR(50) = '';
			DECLARE @NoteDescrVar NVARCHAR(MAX) = '';
		
			SELECT 
				@NoteHeaderVar = NoteHeader, 
				@NoteDescrVar = NoteDescr
			FROM Notes
		
			IF LEN(@NoteHeaderVar) > 50
				BEGIN;
					THROW 50000, 'Note Header too big!! Max 50 characters', 1; 
				END;
			IF LEN(@NoteDescrVar) <= 1
				BEGIN;
					THROW 50000, 'Description too small!! Min 2 characters', 1; 
				END;
			
			CREATE TABLE ErrorLog (
				ErrorId INT PRIMARY KEY IDENTITY NOT NULL,
				ErrorNumber INT NOT NULL,
				ErrorState TINYINT NOT NULL,
				ErrorSeverity TINYINT NOT NULL,
				ErrorProcedure VARCHAR(150) NOT NULL,
				ErrorMessage VARCHAR(MAX) NOT NULL,
				ErrorLine INT NOT NULL
			)
		
				INSERT INTO Notes (NoteHeader,NoteDescr,NoteDate)
				VALUES ('TestNote','TestNoteDescr',GETDATE());
			
			INSERT INTO Notes (NoteHeader,NoteDescr,NoteDate)
				VALUES ('TestNote2','TestNoteDescr2',GETDATE()),
					   ('TestNote3','TestNoteDescr3',GETDATE());
		END TRY
		BEGIN CATCH
			INSERT INTO ErrorLog (ErrorNumber,ErrorState,ErrorSeverity,ErrorProcedure,ErrorMessage,ErrorLine)
				VALUES (ERROR_NUMBER(),ERROR_STATE(),ERROR_SEVERITY(),ERROR_PROCEDURE(),ERROR_MESSAGE(),ERROR_LINE());
		END CATCH;
		GO
	EXEC sp_SelectedNotes
COMMIT TRANSACTION;
