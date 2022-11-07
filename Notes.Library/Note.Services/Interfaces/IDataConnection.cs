using Notes.Library;

namespace Note.Services.Interfaces
{
    public interface IDataConnection
    {
        public Task<List<NotesCS>> GetAllNotesAsync();
    }
}
