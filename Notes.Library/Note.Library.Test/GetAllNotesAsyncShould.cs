using Xunit;
using Note.Services;
using Notes.Library;
using System.Collections.Generic;
using System;

namespace Note.Library.Test
{
    public class GetAllNotesAsyncShould
    {
        [Fact]
        public async void Return_All_Notes_From_Database()
        {
            SqlDataConnector sqlDataConnector = new();

            List<NotesCS> expected = new()
            {
                new NotesCS()
                {
                    NoteId = 1,
                    NoteHeader = "TestNote",
                    NoteDescr = "TestNoteDescr",
                    NoteDate = DateTime.Now
                }
            };

            List<NotesCS> actual = await sqlDataConnector.GetAllNotesAsync();
        }
    }
}