using Notes.Library;

namespace Note.Services.Interfaces
{
    public interface IDataConnection
    {
        /// <summary>
        /// Returns all Notes from SQL database
        /// </summary>
        /// <returns></returns>
        public Task<List<NotesCS>> GetAllNotesAsync();
        /// <summary>
        /// Returns all Errors occured in Notes DB from SQL database
        /// </summary>
        /// <returns></returns>
        public Task<List<NotesErrorLog>> GetAllErrorLogAsync();
    }
}
