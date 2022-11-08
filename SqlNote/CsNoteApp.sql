CREATE DATABASE SqlNote 
GO

USE SqlNote

CREATE TABLE Notes (
	NoteId INT PRIMARY KEY IDENTITY NOT NULL,
	NoteHeader NVARCHAR(50) CHECK(LEN(NoteHeader) <= 50) NULL,
	NoteDescr NVARCHAR(MAX) CHECK(LEN(NoteDescr) > 1) NOT NULL,
	NoteDate DATE DEFAULT(GETDATE()) NOT NULL
)
GO

INSERT INTO Notes (NoteHeader,NoteDescr,NoteDate)
	VALUES ('TestNote','TestNoteDescr',GETDATE());
		GO

INSERT INTO Notes (NoteHeader,NoteDescr,NoteDate)
	VALUES ('TestNote2','TestNoteDescr2',GETDATE()),
		   ('TestNote3','TestNoteDescr3',GETDATE());
		GO

	EXEC sp_SelectedNotes