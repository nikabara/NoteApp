using Notes.Library;

namespace Note.Services.Interfaces
{
    internal interface IDataConnection
    {
        public Task<List<NotesCS>> GetAllNotes();
    }
}
